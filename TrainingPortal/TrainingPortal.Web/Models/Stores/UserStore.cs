using Microsoft.AspNet.Identity;
using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TrainingPortal.Models;
using TrainingPortal.Data.Repositories;
using TrainingPortal.Web.Data.UserService;
using TrainingPortal.Web.Data.UserRoleService;

namespace TrainingPortal.Models.Stores
{
	public partial class UserStore : IUserStore<ApplicationUser>
	{
		private IUserService _userRepository;

		public UserStore(IUserService userRepository, IUserRoleService userRoleRepository)
		{
			_userRepository = userRepository;
			_userRoleRepository = userRoleRepository;
		}

		public Task CreateAsync(ApplicationUser user)
		{
			string id = _userRepository.Create(user);
			user.Id = id;

			return Task.FromResult(0);
		}

		public Task DeleteAsync(ApplicationUser user)
		{
			_userRepository.Delete(user.Id);

			return Task.FromResult(0);
		}

		public void Dispose()
		{

		}

		public Task<ApplicationUser> FindByIdAsync(string userId)
		{
			ApplicationUser applicationUser = _userRepository.Get(userId, null, null);

			return Task.FromResult(applicationUser);
		}

		public Task<ApplicationUser> FindByNameAsync(string userName)
		{
			ApplicationUser applicationUser = _userRepository.Get(null, null, userName);

			return Task.FromResult(applicationUser);
		}

		public Task UpdateAsync(ApplicationUser user)
		{
			_userRepository.Update(user);

			return Task.FromResult(0);
		}
	}

	public partial class UserStore : IQueryableUserStore<ApplicationUser>
	{
		public IQueryable<ApplicationUser> Users
		{
			get
			{
				return _userRepository.GetList().Select(u => (ApplicationUser)u).AsQueryable();
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