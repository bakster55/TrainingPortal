using TrainingPortal.Web.Data.UserService;

namespace TrainingPortal.Data.Repositories
{
	public class UserRepository : IUserService
	{
		private UserServiceClient userServiceClient;

		public UserRepository()
		{
			userServiceClient = new UserServiceClient();
			userServiceClient.Open();
		}

		~UserRepository()
		{
			userServiceClient.Close();
		}

		public string Create(UserDto user)
		{
			string id = userServiceClient.Create(user);

			return id;
		}

		public void Delete(string id)
		{
			userServiceClient.Delete(id);
		}

		public UserDto Get(string id = null, string email = null, string name = null)
		{
			UserDto user = userServiceClient.Get(id, email, name);

			return user;
		}

		public UserDto[] GetList()
		{
			UserDto[] users = userServiceClient.GetList();

			return users;
		}

		public void Update(UserDto user)
		{
			userServiceClient.Update(user);
		}
	}
}