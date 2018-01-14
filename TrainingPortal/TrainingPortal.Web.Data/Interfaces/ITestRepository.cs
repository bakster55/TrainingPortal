using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Data.Interfaces
{
	public interface ITestRepository
	{
		void Create(Test test, string courseId);
		void Delete(string id);
		Test Get(string id);
		Test[] GetList(string courseId);
		void Update(Test test);
	}
}