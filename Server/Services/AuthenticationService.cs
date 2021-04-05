using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Threading;
using MimeKit;
using MailKit.Net.Smtp;
using AutoMapper;
using Dal;

namespace GrpcChatService
{
    public class Client
    {
        static Random rnd = new Random();
        const int MaxTimeConfirmCode = 60;//seconds
        static readonly ChatDatabaseModel chatDatabaseModel = new ChatDatabaseModel();

        public Timestamp TimeSendConfirmationCode { get; private set; }
        public string Email { get; set; }
        string _confirmationCode = null;
        string ConfirmationCode
        {
            get
            {
                if (_confirmationCode == null)
                    return _confirmationCode = rnd.Next(1000, 9999).ToString();
                return _confirmationCode;
            }
            set
            {
                _confirmationCode = value;
            }
        }
        IMapper mapper;
        public Client(string email)
        {
            Email = email;
            AutoMapper.IConfigurationProvider config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegistrationRequest, Dal.User>()
                   .ForMember(dst=>dst.BirthDate,opt=>opt.MapFrom(src=>src.BirthDate.ToDateTime()));
            });
            mapper = new AutoMapper.Mapper(config);
        }
        public void SendConfirmationCode()
        {
            Console.WriteLine(Email);
            Console.WriteLine(ConfirmationCode);
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("BlaBlaChat", "Temp.Seletskyi.Mykola@gmail.com"));
                message.To.Add(new MailboxAddress("Mykola", Email));
                message.Subject = "Confirmation code";
                message.Body = new TextPart("plain") { Text = ConfirmationCode };
                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 465);
                    ////Note: only needed if the SMTP server requires authentication
                    client.Authenticate("Temp.Seletskyi.Mykola@gmail.com", "rMtb2JEX8xmcgSKxCB7aZPDyzyVhbM2RzV");
                    client.Send(message);
                    client.Disconnect(true);
                }
                TimeSendConfirmationCode = Timestamp.FromDateTime(DateTime.UtcNow);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Send Code:{ex.Message}");
            }
        }
        public CheckConfirmCodeResponse.Types.StatusCheckCode CheckConfirmationCode(string code)
        {
            CheckConfirmCodeResponse.Types.StatusCheckCode status = CheckConfirmCodeResponse.Types.StatusCheckCode.Incorrect;
            Console.WriteLine(code);
            Console.WriteLine(ConfirmationCode);
            if (ConfirmationCode == code &&
                Timestamp.FromDateTime(DateTime.UtcNow).Seconds - TimeSendConfirmationCode.Seconds <= MaxTimeConfirmCode)
            {
                if (false/* функція пошуту юзера в базі*/)
                {
                    status = CheckConfirmCodeResponse.Types.StatusCheckCode.Authenticated;
                }
                else
                {
                    status = CheckConfirmCodeResponse.Types.StatusCheckCode.UserNotFound;
                }
            }
            return status;
        }
        public int Registration(RegistrationRequest registrationRequest)
        {
            Dal.User user= chatDatabaseModel.Users.Add(mapper.Map<Dal.User>(registrationRequest));
            chatDatabaseModel.SaveChanges();
            return user.Id;
        }
        public void Clear()
        {
            ConfirmationCode = null;
            Email = null;
        }
    }
    class Clients
    {
        Dictionary<string, Client> clients = new Dictionary<string, Client>();

        public Client this[string key]
        {
            get
            {
                return clients[key];
            }
            set
            {
                clients[key] = value;
            }
        }
        public bool Remove(string peer)
        {
            return clients.Remove(peer);
        }
        public bool ContainsKey(string peer)
        {
            return clients.ContainsKey(peer);
        }
        public Client Add(string peer, string email)
        {
            if (clients.ContainsKey(peer))
            {
                clients[peer].Clear();
                clients[peer].Email = email;
                return clients[peer];
            }
                clients.Add(peer, new Client(email));
            return clients[peer];
        }
    }
    public class AuthenticationService : Authentication.AuthenticationBase
    {
        static readonly Clients clients = new Clients();
        public AuthenticationService()
        {
            Console.WriteLine("CTOR");
        }
        public override Task<SendConfirmCodeResponse> SendConfirmCode(SendConfirmCodeRequest request, ServerCallContext context)
        {
            Client tmp = clients.Add(context.Peer, request.Email);
            tmp.SendConfirmationCode();
            return Task.FromResult(new SendConfirmCodeResponse
            {
                TimeSendConfirmCode = tmp.TimeSendConfirmationCode
            });
        }
        public override Task<CheckConfirmCodeResponse> CheckConfirmCode(CheckConfirmCodeRequest request, ServerCallContext context)
        {
            CheckConfirmCodeResponse.Types.StatusCheckCode status;
            if (clients.ContainsKey(context.Peer))
            {
                Client tmp = clients[context.Peer];
                status = tmp.CheckConfirmationCode(request.Code);
                return Task.FromResult(new CheckConfirmCodeResponse
                {
                    Status = status
                });
            }
            else
            {
                throw new Exception("Client not found");
            }
        }
        public override Task<FindNicknameResponse> FindNickname(FindNicknameRequest request, ServerCallContext context)
        {
            return base.FindNickname(request, context);
        }
        public override Task<RegistrationResponse> Registration(RegistrationRequest request, ServerCallContext context)
        {
            if (clients.ContainsKey(context.Peer))
            {
                return Task.FromResult(new RegistrationResponse
                {
                    IdUser = clients[context.Peer].Registration(request)
                });
            }
            else
            {
                throw new Exception("Client not found");
            }
        }
    }
}
