using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace TrainingPortal.Models
{
	public partial class RoleStore : IRoleStore<Role, string>
	{
		public Task CreateAsync(Role role)
		{
			string id = RoleRepository.CreateAsync(role.Name);
			role.Id = id;

			return Task.FromResult(0);
		}

		public Task DeleteAsync(Role role)
		{
			RoleRepository.DeleteRole(role.Id);

			return Task.FromResult(0);
		}

		public void Dispose()
		{

		}

		public Task<Role> FindByIdAsync(string roleId)
		{
			Role role = RoleRepository.GetRole(roleId);

			return Task.FromResult(role);
		}

		public Task<Role> FindByNameAsync(string roleName)
		{
			Role role = RoleRepository.GetRole(name: roleName);

			return Task.FromResult(role);
		}

		public Task UpdateAsync(Role role)
		{
			RoleRepository.UpdateAsync(role);

			return Task.FromResult(0);
		}
	}

	public partial class RoleStore : IQueryableRoleStore<Role>
	{
		public IQueryable<Role> Roles
		{
			get { return RoleRepository.GetRoles().AsQueryable(); }
		}
	}
}