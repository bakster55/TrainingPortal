using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrainingPortal.Data.Interfaces;
using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Models.Stores
{
	public partial class UserStore : IUserRoleStore<ApplicationUser>
	{
		private IUserRoleRepository _userRoleRepository;

		public Task AddToRoleAsync(ApplicationUser user, string roleName)
		{
			_userRoleRepository.Create(user.Id, roleName);
			return Task.FromResult(0);
		}

		public Task<IList<string>> GetRolesAsync(ApplicationUser user)
		{
			IList<string> roles = _userRoleRepository.GetList(user.Id);
			return Task.FromResult(roles);
		}

		public Task<bool> IsInRoleAsync(ApplicationUser user, string roleName)
		{
			bool isInRole = _userRoleRepository.Exist(user.Id, roleName);
			return Task.FromResult(isInRole);
		}

		public Task RemoveFromRoleAsync(ApplicationUser user, string roleName)
		{
			_userRoleRepository.Delete(user.Id, roleName);
			return Task.FromResult(0);
		}
	}
}