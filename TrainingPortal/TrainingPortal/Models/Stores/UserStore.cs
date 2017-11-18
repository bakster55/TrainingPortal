using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TrainingPortal.Models
{
	public partial class UserStore : IUserStore<ApplicationUser>
	{
		private string _connectionString = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;

		public Task CreateAsync(ApplicationUser user)
		{
			string id = UserRepository.CreateUser(user.Email, user.UserName, user.PasswordHash);
			user.Id = id;

			return Task.FromResult(0);
		}

		public Task DeleteAsync(ApplicationUser user)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{

		}

		public Task<ApplicationUser> FindByIdAsync(string userId)
		{
			ApplicationUser applicationUser = UserRepository.GetUser(userId);

			return Task.FromResult(applicationUser);
		}

		public Task<ApplicationUser> FindByNameAsync(string userName)
		{
			ApplicationUser applicationUser = UserRepository.GetUser(name: userName);

			return Task.FromResult(applicationUser);
		}

		public Task UpdateAsync(ApplicationUser user)
		{
			string id = UserRepository.UpdateUser(user);

			return Task.FromResult(0);
		}
	}

	public partial class UserStore : IUserLockoutStore<ApplicationUser, string>
	{
		public Task<int> GetAccessFailedCountAsync(ApplicationUser user)
		{
			return Task.FromResult(0);
		}

		public Task<bool> GetLockoutEnabledAsync(ApplicationUser user)
		{
			return Task.FromResult(false);
		}

		public Task<DateTimeOffset> GetLockoutEndDateAsync(ApplicationUser user)
		{
			return Task.FromResult(new DateTimeOffset());
		}

		public Task<int> IncrementAccessFailedCountAsync(ApplicationUser user)
		{
			return Task.FromResult(0);
		}

		public Task ResetAccessFailedCountAsync(ApplicationUser user)
		{
			return Task.FromResult(0);
		}

		public Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled)
		{
			return Task.FromResult(0);
		}

		public Task SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset lockoutEnd)
		{
			return Task.FromResult(0);
		}
	}

	public partial class UserStore : IUserTwoFactorStore<ApplicationUser, string>
	{
		public Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user)
		{
			return Task.FromResult(false);
		}

		public Task SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled)
		{
			return Task.FromResult(0);
		}
	}
}