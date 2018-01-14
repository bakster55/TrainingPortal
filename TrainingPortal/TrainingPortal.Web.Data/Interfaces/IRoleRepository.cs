using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Data.Interfaces
{
	public interface IRoleRepository
	{
		string Create(Role role);
		void Delete(string id);
		Role Get(string id = null, string name = null);
		Role[] GetList();
		void Update(Role role);
	}
}