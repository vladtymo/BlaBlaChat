using Grpc.Net.Client;
using GrpcChatService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GrpcChatService.Authentication;
using static GrpcChatService.CheckConfirmCodeResponse.Types;

namespace Client.Models.Services
{
    public static  class AuthenticationServise
    {
        static GrpcChannel chanel;
        static AuthenticationClient client;
        static AuthenticationServise()
        {
            chanel = GrpcChannel.ForAddress("https://localhost:5001");
            client = new AuthenticationClient(chanel);
        }
        public static async Task<TimeSpan> SendConfirmCodeAsync(string email)
        {
            SendConfirmCodeResponse response = await client.SendConfirmCodeAsync(new SendConfirmCodeRequest() { Email = email });
            TimeSpan result = new TimeSpan(0, 1, 0) - (DateTime.UtcNow - response.TimeSendConfirmCode.ToDateTime());
            return result;
        }
        public static async Task<StatusCheckCode> CheckConfirmCodeAsync(string code)
        {
            CheckConfirmCodeResponse response = await client.CheckConfirmCodeAsync(new CheckConfirmCodeRequest() { Code = code });
            return response.Status;
        }
        public static async Task<int> Registration(RegistrationRequest registrationRequest)
        {
            RegistrationResponse response = await client.RegistrationAsync(registrationRequest);
            return response.IdUser;
        }
    }
}
