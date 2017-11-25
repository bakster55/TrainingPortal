using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using TrainingPortal.Data.Repositories;

namespace TrainingPortal.Models
{
	public partial class UserStore : IUserRoleStore<ApplicationUser>
	{
		private UserRoleRepository userRoleRepository;

		public Task AddToRoleAsync(ApplicationUser user, string roleName)
		{
			userRoleRepository.Create(user.Id, roleName);
			return Task.FromResult(0);
		}

		public Task<IList<string>> GetRolesAsync(ApplicationUser user)
		{
			IList<string> roles = userRoleRepository.GetList(user.Id);
			return Task.FromResult(roles);
		}

		public Task<bool> IsInRoleAsync(ApplicationUser user, string roleName)
		{
			bool isInRole = userRoleRepository.Exist(user.Id, roleName);
			return Task.FromResult(isInRole);
		}

		public Task RemoveFromRoleAsync(ApplicationUser user, string roleName)
		{
			userRoleRepository.Delete(user.Id, roleName);
			return Task.FromResult(0);
		}
	}
}