using System;
using System.Security.Claims;
using backend_dot_net_core.Core.Dtos.General;
using backend_dot_net_core.Core.Dtos.Message;

namespace backend_dot_net_core.Core.Interfaces
{
	public interface IMessageService
	{
		Task<GeneralServiceResponseDto> CreateNewMessageAsync(ClaimsPrincipal User, CreateMessageDto createMessage);
        Task<IEnumerable<GetMessageDto>> GetMessagesAsync();
        Task<IEnumerable<GetMessageDto>> GetMyMessagesAsync(ClaimsPrincipal User);
	}
}

