using TrainingPortal.Web.Data.UserRoleService;

namespace TrainingPortal.Data.Repositories
{
	public class UserRoleRepository : IUserRoleService
	{
		private UserRoleServiceClient userRoleServiceClient;

		public UserRoleRepository()
		{
			userRoleServiceClient = new UserRoleServiceClient();
			userRoleServiceClient.Open();
		}

		~UserRoleRepository()
		{
			userRoleServiceClient.Close();
		}

		public void Create(string userId, string roleName)
		{
			userRoleServiceClient.Create(userId, roleName);
		}

		public void Delete(string userId, string roleName)
		{
			userRoleServiceClient.Delete(userId, roleName);
		}

		public bool Exist(string userId, string roleName)
		{
			bool exist = userRoleServiceClient.Exist(userId, roleName);

			return exist;
		}

		public string[] GetList(string userId)
		{
			string[] roleNames = userRoleServiceClient.GetList(userId);

			return roleNames;
		}
	}
}