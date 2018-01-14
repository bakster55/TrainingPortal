﻿using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace TrainingPortal.Web.Business.Models
{
	public class ApplicationUser : IUser
	{
		public string Id { get; set; }

		public string UserName { get; set; }

		public string Email { get; set; }

		public string PasswordHash { get; set; }

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}
	}
}