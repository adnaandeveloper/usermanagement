using System;
using System.Security.Claims;
using backend_dot_net_core.Core.Dtos.Auth;
using backend_dot_net_core.Core.Dtos.General;

namespace backend_dot_net_core.Core.Interfaces
{
	public interface IAuthService
	{
		Task<GeneralServiceResponseDto> SeedRolesAsync();
        Task<GeneralServiceResponseDto> RegisterAsync(RegisterDto registerDto);
        Task<LoginServiceResponseDto> LoginAsync(LoginDtos loginDto);
        Task<GeneralServiceResponseDto> UpdateRoleAsync(ClaimsPrincipal User, UpdateRoleDto updateRoleDto);
        Task<LoginServiceResponseDto> MeAsync(MeDto meDto);
        Task<IEnumerable<UserInfoResult>> GetUsersListAsync();
        Task<UserInfoResult> GetUserDetailsByUserName(string userName);
        Task<IEnumerable<string>> GetUserNamesListAsync();
    }
}

