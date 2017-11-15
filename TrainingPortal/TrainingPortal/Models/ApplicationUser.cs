﻿using System;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace TrainingPortal.Models
{
	// You can add profile data for the user by adding more properties to your ApplicationUser class, 
	//please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

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