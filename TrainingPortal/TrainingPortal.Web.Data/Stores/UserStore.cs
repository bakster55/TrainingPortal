using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TrainingPortal.Data.Models;
using TrainingPortal.Data.Repositories;

namespace TrainingPortal.Data.Stores
{
	public partial class UserStore : IUserStore<ApplicationUser>
	{
		private UserRepository userRepository;

		public UserStore()
		{
			userRepository = new UserRepository();
			userRoleRepository = new UserRoleRepository();
		}

		public Task CreateAsync(ApplicationUser user)
		{
			string id = userRepository.Create(user);
			user.Id = id;

			return Task.FromResult(0);
		}

		public Task DeleteAsync(ApplicationUser user)
		{
			userRepository.Delete(user.Id);

			return Task.FromResult(0);
		}

		public void Dispose()
		{

		}

		public Task<ApplicationUser> FindByIdAsync(string userId)
		{
			ApplicationUser applicationUser = userRepository.Get(userId);

			return Task.FromResult(applicationUser);
		}

		public Task<ApplicationUser> FindByNameAsync(string userName)
		{
			ApplicationUser applicationUser = userRepository.Get(name: userName);

			return Task.FromResult(applicationUser);
		}

		public Task UpdateAsync(ApplicationUser user)
		{
			userRepository.Update(user);

			return Task.FromResult(0);
		}
	}

	public partial class UserStore : IQueryableUserStore<ApplicationUser>
	{
		public IQueryable<ApplicationUser> Users
		{
			get
			{
				return userRepository.GetList().Select(u => (ApplicationUser)u).AsQueryable();
			}
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