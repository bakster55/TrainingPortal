using TrainingPortal.Client.RoleService;

namespace TrainingPortal.Data.Repositories
{
	public class RoleRepository : IRoleService
	{
		private RoleServiceClient roleServiceClient;

		public RoleRepository()
		{
			roleServiceClient = new RoleServiceClient();
			roleServiceClient.Open();
		}

		~RoleRepository()
		{
			roleServiceClient.Close();
		}

		public string Create(RoleDto role)
		{
			string id = roleServiceClient.Create(role);

			return id;
		}

		public void Delete(string id)
		{
			roleServiceClient.Delete(id);
		}

		public RoleDto Get(string id = null, string name = null)
		{
			RoleDto role = roleServiceClient.Get(id, name);

			return role;
		}

		public RoleDto[] GetList()
		{
			RoleDto[] roles = roleServiceClient.GetList();

			return roles;
		}

		public void Update(RoleDto role)
		{
			roleServiceClient.Update(role);
		}
	}
}