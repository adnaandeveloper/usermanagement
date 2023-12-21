using System;
using System.Security.Claims;
using backend_dot_net_core.Core.Dtos.Log;

namespace backend_dot_net_core.Core.Interfaces
{
	public interface ILogService
	{
        Task SaveNewLog(string Username, string Description);
        Task <IEnumerable<GetLogDto>> GetLogsAync();
        Task<IEnumerable<GetLogDto>> GetMyLogsAync(ClaimsPrincipal User);

    }
}

