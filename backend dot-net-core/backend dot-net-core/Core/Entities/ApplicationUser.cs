using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace backend_dot_net_core.Core.Entities
{
	public class ApplicationUser: IdentityUser
	{
		public string FirsName { get; set; }
		public string LastName { get; set; }
        public string Address { get; set; }
		public DateTime  CreatedAt { get; set; } = DateTime.Now;

		[NotMapped]
		public IList<string> Roles { get; set; } 
    }
}

