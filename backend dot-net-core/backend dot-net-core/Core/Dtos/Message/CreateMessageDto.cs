using System;
namespace backend_dot_net_core.Core.Dtos.Message
{
	public class CreateMessageDto
	{
		public string ReceiverUserName { get; set; }
		public string Text { get; set; }
    }
}

