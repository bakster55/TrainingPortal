﻿using Microsoft.AspNet.Identity;
using System;
using System.Threading.Tasks;
using TrainingPortal.Data.Repositories;

namespace TrainingPortal.Models
{
	public partial class UserStore : IUserEmailStore<ApplicationUser>
	{
		public Task<ApplicationUser> FindByEmailAsync(string email)
		{
			ApplicationUser applicationUser = userRepository.Get(email: email);

			return Task.FromResult(applicationUser);
		}

		public Task<string> GetEmailAsync(ApplicationUser user)
		{
			return Task.FromResult(user.Email);
		}

		public Task<bool> GetEmailConfirmedAsync(ApplicationUser user)
		{
			throw new NotImplementedException();
		}

		public Task SetEmailAsync(ApplicationUser user, string email)
		{
			throw new NotImplementedException();
		}

		public Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed)
		{
			throw new NotImplementedException();
		}
	}
}