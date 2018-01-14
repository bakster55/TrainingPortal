using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Data.Interfaces
{
	public interface ICourseRepository
	{
		void Create(Course course);
		void Delete(string id);
		Course Get(string id);
		Course[] GetList();
		void Update(Course course);
	}
}