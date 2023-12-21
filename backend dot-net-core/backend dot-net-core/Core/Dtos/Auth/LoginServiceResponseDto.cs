using System;
namespace backend_dot_net_core.Core.Dtos.Auth
{
	public class LoginServiceResponseDto
	{
		public string NewToken { get; set; }
		//This Would be returned to front-end
        public UserInfoResult UserInfo{ get; set; }

    }
}

