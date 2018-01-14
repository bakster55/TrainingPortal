using TrainingPortal.Web.Data.TestOptionService;
using TrainingPortal.Data.Interfaces;
using TrainingPortal.Web.Business.Models;
using System.Linq;
using TrainingPortal.Web.Data.Converters;

namespace TrainingPortal.Data.Repositories
{
	public class TestOptionRepository : ITestOptionRepository
	{
		private TestOptionServiceClient testOptionServiceClient;

		public TestOptionRepository()
		{
			testOptionServiceClient = new TestOptionServiceClient();
			testOptionServiceClient.Open();
		}

		~TestOptionRepository()
		{
			if (testOptionServiceClient != null)
			{
				testOptionServiceClient.Close();
			}
		}

		public void Create(TestOption test, string testId)
		{
			testOptionServiceClient.Create(test.Convert(), testId);
		}

		public void Delete(string id)
		{
			testOptionServiceClient.Delete(id);
		}

		public TestOption Get(string id)
		{
			TestOptionDto option = testOptionServiceClient.Get(id);

			return option.Convert();
		}

		public TestOption[] GetList(string testId)
		{
			TestOptionDto[] options = testOptionServiceClient.GetList(testId);

			return options.Select((c) => c.Convert()).ToArray(); ;
		}

		public void Update(TestOption option)
		{
			testOptionServiceClient.Update(option.Convert());
		}
	}
}