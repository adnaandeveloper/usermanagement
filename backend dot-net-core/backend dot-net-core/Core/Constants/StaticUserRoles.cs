using System;
namespace backend_dot_net_core.Core.Constants
{

	// This class will be used to avaoid typing errors
	public static class StaticUserRoles
	{
		public const String OWNER = "OWNER";
        public const String ADMIN = "ADMIN";
        public const String MANAGER = "MANAGER";
        public const String USER = "USER";
        public const String OwnerAdmin = "OWNER,ADMIN";
        public const String OwnerAdminManager = "OWNER,ADMIN,MANAGER";
        public const String OwnerAdminManagerUser = "OWNER,ADMIN,MANAGER,USER";
    }
}

