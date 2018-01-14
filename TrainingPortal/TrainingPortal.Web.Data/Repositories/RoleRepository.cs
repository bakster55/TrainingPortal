using TrainingPortal.Web.Data.RoleService;
using TrainingPortal.Data.Interfaces;
using TrainingPortal.Web.Business.Models;
using System.Linq;
using TrainingPortal.Web.Data.Converters;

namespace TrainingPortal.Data.Repositories
{
	public class RoleRepository : IRoleRepository
	{
		private RoleServiceClient roleServiceClient;

		public RoleRepository()
		{
			roleServiceClient = new RoleServiceClient();
			roleServiceClient.Open();
		}

		~RoleRepository()
		{
			if (roleServiceClient != null)
			{
				roleServiceClient.Close();
			}
		}

		public string Create(Role role)
		{
			string id = roleServiceClient.Create(role.Convert());

			return id;
		}

		public void Delete(string id)
		{
			roleServiceClient.Delete(id);
		}

		public Role Get(string id = null, string name = null)
		{
			RoleDto role = roleServiceClient.Get(id, name);

			return role.Convert();
		}

		public Role[] GetList()
		{
			RoleDto[] roles = roleServiceClient.GetList();

			return roles.Select((r) => r.Convert()).ToArray();
		}

		public void Update(Role role)
		{
			roleServiceClient.Update(role.Convert());
		}
	}
}