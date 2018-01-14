using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Data.Interfaces
{
	public interface ICategoryRepository
	{
		void Create(Category category);
		void Delete(string id);
		Category Get(string id);
		Category[] GetList();
		void Update(Category category);
	}
}