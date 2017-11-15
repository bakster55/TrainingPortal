using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace TrainingPortal.Models
{
	public class UserStore : IUserStore<ApplicationUser>, IUserPasswordStore<ApplicationUser>, IUserEmailStore<ApplicationUser>
	{
		public Task CreateAsync(ApplicationUser user)
		{
			user.Id = "5";
			return Task.FromResult(0);
		}

		public Task DeleteAsync(ApplicationUser user)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{

		}

		public Task<ApplicationUser> FindByEmailAsync(string email)
		{
			return Task.FromResult((ApplicationUser)null);
		}

		public Task<ApplicationUser> FindByIdAsync(string userId)
		{
			throw new NotImplementedException();
		}

		public Task<ApplicationUser> FindByNameAsync(string userName)
		{
			return Task.FromResult((ApplicationUser)null);
		}

		public Task<string> GetEmailAsync(ApplicationUser user)
		{
			return Task.FromResult(user.Email);
		}

		public Task<bool> GetEmailConfirmedAsync(ApplicationUser user)
		{
			throw new NotImplementedException();
		}

		public Task<string> GetPasswordHashAsync(ApplicationUser user)
		{
			throw new NotImplementedException();
		}

		public Task<bool> HasPasswordAsync(ApplicationUser user)
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

		public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
		{
			user.PasswordHash = passwordHash;
			return Task.FromResult(0);
		}

		public Task UpdateAsync(ApplicationUser user)
		{
			throw new NotImplementedException();
		}
	}
}