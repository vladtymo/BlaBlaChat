using DAL.Services;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcUserProfileService
{
    public class UserProfileService : UserProfile.UserProfileBase
    {
        static UserService UserService = new UserService();
        public override Task<IsExistNicknameResponse> IsExistNickname(IsExistNicknameRequest request, ServerCallContext context)
        {
            IsExistNicknameResponse response = new IsExistNicknameResponse() { Response = UserService.IsExistNickName(request.Nickname) };
            return Task.FromResult(response);
        }
    }
}
