using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using TrainingPortal.Data.Repositories;

namespace TrainingPortal.Models
{
	public partial class RoleStore : IRoleStore<Role, string>
	{
		private RoleRepository roleRepository;

		public RoleStore()
		{
			roleRepository = new RoleRepository();
		}

		public Task CreateAsync(Role role)
		{
			string id = roleRepository.Create(role);
			role.Id = id;

			return Task.FromResult(0);
		}

		public Task DeleteAsync(Role role)
		{
			roleRepository.Delete(role.Id);

			return Task.FromResult(0);
		}

		public void Dispose()
		{

		}

		public Task<Role> FindByIdAsync(string roleId)
		{
			Role role = roleRepository.Get(roleId);

			return Task.FromResult(role);
		}

		public Task<Role> FindByNameAsync(string roleName)
		{
			Role role = roleRepository.Get(name: roleName);

			return Task.FromResult(role);
		}

		public Task UpdateAsync(Role role)
		{
			roleRepository.Update(role);

			return Task.FromResult(0);
		}
	}

	public partial class RoleStore : IQueryableRoleStore<Role>
	{
		public IQueryable<Role> Roles
		{
			get { return roleRepository.GetList().Select(r => (Role)r).AsQueryable(); }
		}
	}
}