using TrainingPortal.Web.Data.UserService;
using TrainingPortal.Web.Business.Models;
using TrainingPortal.Web.Data.Converters;
using TrainingPortal.Data.Interfaces;
using System.Linq;

namespace TrainingPortal.Data.Repositories
{
	public class UserRepository : IUserRepository
	{
		private UserServiceClient userServiceClient;

		public UserRepository()
		{
			userServiceClient = new UserServiceClient();
			userServiceClient.Open();
		}

		~UserRepository()
		{
			if (userServiceClient != null)
			{
				userServiceClient.Close();
			}
		}

		public string Create(ApplicationUser user)
		{
			string id = userServiceClient.Create(user.Convert());

			return id;
		}

		public void Delete(string id)
		{
			userServiceClient.Delete(id);
		}

		public ApplicationUser Get(string id = null, string email = null, string name = null)
		{
			UserDto user = userServiceClient.Get(id, email, name);

			return user.Convert();
		}

		public ApplicationUser[] GetList()
		{
			UserDto[] users = userServiceClient.GetList();

			return users.Select((au) => au.Convert()).ToArray();
		}

		public void Update(ApplicationUser user)
		{
			userServiceClient.Update(user.Convert());
		}
	}
}