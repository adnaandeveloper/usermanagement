using System;
namespace backend_dot_net_core.Core.Entities
{
	public class Log: BaseEntity<long>
	{
		public string? UserName { get; set; }
        public string Description { get; set; }
    }
}

