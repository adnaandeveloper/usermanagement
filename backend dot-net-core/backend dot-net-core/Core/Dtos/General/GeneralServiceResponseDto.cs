using System;
namespace backend_dot_net_core.Core.Dtos.General
{
	public class GeneralServiceResponseDto
	{
		public bool IsSucceed { get; set; }
		public int StatusCode { get; set; }
		public string Message { get; set; }
	}
}

