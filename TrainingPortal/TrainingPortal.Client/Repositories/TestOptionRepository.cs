using TrainingPortal.Client.TestOptionService;

namespace TrainingPortal.Data.Repositories
{
	public class TestOptionRepository : ITestOptionService
	{
		private TestOptionServiceClient testOptionServiceClient;

		public TestOptionRepository()
		{
			testOptionServiceClient = new TestOptionServiceClient();
			testOptionServiceClient.Open();
		}

		~TestOptionRepository()
		{
			testOptionServiceClient.Close();
		}

		public void Create(TestOptionDto test, string testId)
		{
			testOptionServiceClient.Create(test, testId);
		}

		public void Delete(string id)
		{
			testOptionServiceClient.Delete(id);
		}

		public TestOptionDto Get(string id)
		{
			TestOptionDto option = testOptionServiceClient.Get(id);

			return option;
		}

		public TestOptionDto[] GetList(string testId)
		{
			TestOptionDto[] options = testOptionServiceClient.GetList(testId);

			return options;
		}

		public void Update(TestOptionDto option)
		{
			testOptionServiceClient.Update(option);
		}
	}
}