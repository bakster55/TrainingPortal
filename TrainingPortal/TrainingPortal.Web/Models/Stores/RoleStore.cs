using Microsoft.AspNet.Identity;
using System.Linq;
using System.Threading.Tasks;
using TrainingPortal.Models;
using TrainingPortal.Data.Repositories;
using TrainingPortal.Web.Data.RoleService;

namespace TrainingPortal.Models.Stores
{
	public partial class RoleStore : IRoleStore<Role, string>
	{
		private IRoleService _roleRepository;

		public RoleStore(IRoleService roleRepository)
		{
			_roleRepository = roleRepository;
		}

		public Task CreateAsync(Role role)
		{
			string id = _roleRepository.Create(role);
			role.Id = id;

			return Task.FromResult(0);
		}

		public Task DeleteAsync(Role role)
		{
			_roleRepository.Delete(role.Id);

			return Task.FromResult(0);
		}

		public void Dispose()
		{

		}

		public Task<Role> FindByIdAsync(string roleId)
		{
			Role role = _roleRepository.Get(roleId, null);

			return Task.FromResult(role);
		}

		public Task<Role> FindByNameAsync(string roleName)
		{
			Role role = _roleRepository.Get(null, roleName);

			return Task.FromResult(role);
		}

		public Task UpdateAsync(Role role)
		{
			_roleRepository.Update(role);

			return Task.FromResult(0);
		}
	}

	public partial class RoleStore : IQueryableRoleStore<Role>
	{
		public IQueryable<Role> Roles
		{
			get { return _roleRepository.GetList().Select(r => (Role)r).AsQueryable(); }
		}
	}
}