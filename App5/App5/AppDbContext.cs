using App5.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace App5
{
	public class AppDbContext: IdentityDbContext<SystemUser, UserRole, Guid>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			//Debugger.Launch();
			base.OnModelCreating(builder);

			builder.Entity<SystemUser>().ToTable("users");
			builder.Entity<UserRole>().ToTable("roles");
		}
	}
}
