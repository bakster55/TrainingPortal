using TrainingPortal.Web.Data.TestService;
using TrainingPortal.Data.Interfaces;
using System.Linq;
using TrainingPortal.Web.Business.Models;
using TrainingPortal.Web.Data.Converters;
using System.Collections.Generic;

namespace TrainingPortal.Data.Repositories
{
	public class TestRepository : ITestRepository
	{
		private TestServiceClient testServiceClient;
		private ITestOptionRepository _testOptionRepository;

		public TestRepository(ITestOptionRepository testOptionRepository)
		{
			_testOptionRepository = testOptionRepository;
			testServiceClient = new TestServiceClient();
			testServiceClient.Open();
		}

		~TestRepository()
		{
			if (testServiceClient != null)
			{
				testServiceClient.Close();
			}
		}

		public void Create(Test test, string courseId)
		{
			testServiceClient.Create(test.Convert(), courseId);
		}

		public void Delete(string id)
		{
			testServiceClient.Delete(id);
		}

		public Test Get(string id)
		{
			List<TestOption> testOptions = _testOptionRepository.GetList(id).ToList();
			Test test = testServiceClient.Get(id).Convert(testOptions);

			return test;
		}

		public Test[] GetList(string courseId)
		{
			Test[] tests = testServiceClient.GetList(courseId).Select((t) =>
			{
				List<TestOption> testOptions = _testOptionRepository.GetList(t.Id).ToList();
				Test test = t.Convert(testOptions);

				return test;
			}).ToArray();

			return tests;
		}

		public void Update(Test test)
		{
			testServiceClient.Update(test.Convert());
		}
	}
}