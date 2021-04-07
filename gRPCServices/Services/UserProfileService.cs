using Grpc.Net.Client;
using GrpcUserProfileService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GrpcUserProfileService.UserProfile;

namespace Client.Models.Services
{
    public static class UserProfileService
    {
        static GrpcChannel chanel;
        static UserProfileClient client;
        static UserProfileService()
        {
            chanel = GrpcChannel.ForAddress("https://localhost:5001");
            client = new UserProfileClient(chanel);
        }
        public static async Task<bool> IsExistNicknameAsync(string Nickname)
        {
            IsExistNicknameResponse response = await client.IsExistNicknameAsync(new IsExistNicknameRequest() { Nickname = Nickname });
            return response.Response;
        }
    }
}
