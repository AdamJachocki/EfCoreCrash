using Microsoft.AspNetCore.Identity;
using System;

namespace App5.Models
{
	public static class RoleNames
	{
		public const string SUPERADMIN = "Roles_Superadmin";
		public const string ADMIN = "Roles_Admin";
		public const string USER = "Roles_User";
		public const string PLAN_LIMITS_ADMIN = "Roles_PlanLimitsAdmin";
	}

	public enum RoleTypes
	{
		SuperAdmin,
		Admin,
		User,
		PlanLimitsAdmin
	}

	public class UserRole : IdentityRole<Guid>
	{
		public static RoleTypes GetRoleType(string roleName)
		{
			switch (roleName)
			{
				case RoleNames.SUPERADMIN: return RoleTypes.SuperAdmin;
				case RoleNames.ADMIN: return RoleTypes.Admin;
				case RoleNames.USER: return RoleTypes.User;
				case RoleNames.PLAN_LIMITS_ADMIN: return RoleTypes.PlanLimitsAdmin;
				default:
					throw new ArgumentOutOfRangeException("Unknown role: " + roleName);
			}
		}
	}
}
