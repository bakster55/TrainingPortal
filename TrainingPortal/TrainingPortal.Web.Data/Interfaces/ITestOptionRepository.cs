using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Data.Interfaces
{
	public interface ITestOptionRepository
	{
		void Create(TestOption test, string testId);
		void Delete(string id);
		TestOption Get(string id);
		TestOption[] GetList(string testId);
		void Update(TestOption option);
	}
}