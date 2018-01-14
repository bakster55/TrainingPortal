using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Data.Interfaces
{
	public interface IUserRepository
	{
		string Create(ApplicationUser user);
		void Delete(string id);
		ApplicationUser Get(string id = null, string email = null, string name = null);
		ApplicationUser[] GetList();
		void Update(ApplicationUser user);
	}
}