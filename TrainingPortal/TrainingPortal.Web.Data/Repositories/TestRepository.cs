using TrainingPortal.Web.Data.TestService;

namespace TrainingPortal.Data.Repositories
{
	public class TestRepository : ITestService
	{
		private TestServiceClient testServiceClient;

		public TestRepository()
		{
			testServiceClient = new TestServiceClient();
			testServiceClient.Open();
		}

		~TestRepository()
		{
			testServiceClient.Close();
		}

		public void Create(TestDto test, string courseId)
		{
			testServiceClient.Create(test, courseId);
		}

		public void Delete(string id)
		{
			testServiceClient.Delete(id);
		}

		public TestDto Get(string id)
		{
			TestDto test = testServiceClient.Get(id);

			return test;
		}

		public TestDto[] GetList(string courseId)
		{
			TestDto[] tests = testServiceClient.GetList(courseId);

			return tests;
		}

		public void Update(TestDto test)
		{
			testServiceClient.Update(test);
		}
	}
}