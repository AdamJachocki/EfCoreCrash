using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace App5.Models
{
	public enum PricingPlan
	{
		Free,
		Medium,
		High
	}

	public enum ActivationStates
	{
		ActivationPending,
		Activated,
		RemovePending
	}

	public class SystemUser : IdentityUser<Guid>
	{
		public virtual PricingPlan Plan { get; set; }
		public virtual DateTimeOffset PlanPaidTo { get; set; }

		public virtual ActivationStates ActivationState { get; set; }
		public virtual bool ActivationMailSentSuccessfully { get; set; } = false;
		public virtual DateTimeOffset? AccountCreationTime { get; set; }

		public SystemUser()
		{

		}

		/// <summary>
		/// Creates DEEP clone of other
		/// </summary>
		/// <param name="other"></param>
		public SystemUser(SystemUser other)
		{
			this.AccessFailedCount = other.AccessFailedCount;
			this.AccountCreationTime = other.AccountCreationTime;
			this.ActivationMailSentSuccessfully = other.ActivationMailSentSuccessfully;
			this.ActivationState = other.ActivationState;
			this.ConcurrencyStamp = other.ConcurrencyStamp == null ? null : string.Copy(other.ConcurrencyStamp);
			this.Email = other.Email == null ? null : string.Copy(other.Email);
			this.EmailConfirmed = other.EmailConfirmed;
			this.Id = new Guid(other.Id.ToByteArray());
			this.LockoutEnabled = other.LockoutEnabled;
			this.LockoutEnd = other.LockoutEnd;
			this.NormalizedEmail = other.NormalizedEmail == null ? null : string.Copy(other.NormalizedEmail);
			this.NormalizedUserName = other.NormalizedUserName == null ? null : string.Copy(other.NormalizedUserName);
			this.PasswordHash = other.PasswordHash == null ? null : string.Copy(other.PasswordHash);
			this.PhoneNumber = other.PhoneNumber == null ? null : string.Copy(other.PhoneNumber);
			this.PhoneNumberConfirmed = other.PhoneNumberConfirmed;
			this.Plan = other.Plan;
			this.PlanPaidTo = other.PlanPaidTo;
			this.SecurityStamp = other.SecurityStamp == null ? null : string.Copy(other.SecurityStamp);
			this.TwoFactorEnabled = other.TwoFactorEnabled;
			this.UserName = other.UserName == null ? null : string.Copy(other.UserName);
		}


	}
}
