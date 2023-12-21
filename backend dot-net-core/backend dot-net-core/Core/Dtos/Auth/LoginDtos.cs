﻿using System;
using System.ComponentModel.DataAnnotations;

namespace backend_dot_net_core.Core.Dtos.Auth
{
	public class LoginDtos
	{
		[Required (ErrorMessage = "UserName is required")]
		public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public  string Password { get; set; }

    }
}
 