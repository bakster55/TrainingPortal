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
	public partial class UserStore : IUserRoleStore<ApplicationUser>
	{
		public Task AddToRoleAsync(ApplicationUser user, string roleName)
		{
			UserRoleRepository.AddToRoleAsync(user, roleName);
			return Task.FromResult(0);
		}

		public Task<IList<string>> GetRolesAsync(ApplicationUser user)
		{
			IList<string> roles = UserRoleRepository.GetRolesAsync(user);
			return Task.FromResult(roles);
		}

		public Task<bool> IsInRoleAsync(ApplicationUser user, string roleName)
		{
			bool isInRole = UserRoleRepository.IsInRoleAsync(user, roleName);
			return Task.FromResult(isInRole);
		}

		public Task RemoveFromRoleAsync(ApplicationUser user, string roleName)
		{
			UserRoleRepository.RemoveFromRoleAsync(user, roleName);
			return Task.FromResult(0);
		}
	}
}