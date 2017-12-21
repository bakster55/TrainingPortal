using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingPortal.Models;
using TrainingPortal.Web.Data.TestService;
using TrainingPortal.Web.Data.TestOptionService;

namespace TrainingPortal.Web.Models.Services
{
	public class TestService : ITestService
	{
		private TrainingPortal.Web.Data.TestService.ITestService _testRepository;
		private ITestOptionService _testOptionRepository;

		public TestService(
			TrainingPortal.Web.Data.TestService.ITestService testRepository,
			ITestOptionService testOptionRepository
			)
		{
			_testRepository = testRepository;
			_testOptionRepository = testOptionRepository;
		}

		public void Create(Test test, string courseId)
		{
			_testRepository.Create(test, courseId);
		}

		public void Delete(string id)
		{
			_testRepository.Delete(id);
		}

		public Test Get(string id)
		{
			Test test = _testRepository.Get(id);
			test.Options = _testOptionRepository.GetList(id).Select((to) => (TestOption)to).ToList();

			return test;
		}

		public IList<Test> GetList(string courseId)
		{
			List<Test> tests = _testRepository.GetList(courseId).Select((t) =>
			{
				Test test = (Test)t;
				test.Options = _testOptionRepository.GetList(test.Id).Select((to) => (TestOption)to).ToList();

				return test;
			}
			).ToList();

			return tests;
		}

		public int GetTrueAnswersCount(List<Test> tests, string courseId)
		{
			List<Test> testsAnswers = _testRepository.GetList(courseId).Select(test => (Test)test).ToList();

			int count = 0;

			for (int i = 0; i < tests.Count; i++)
			{
				bool result = true;
				Test testAnswers = testsAnswers[i];
				testAnswers.Options = _testOptionRepository.GetList(testAnswers.Id).Select(to => (TestOption)to).ToList();
				Test test = tests[i];

				if (testAnswers.Options != null)
				{
					for (int j = 0; j < testAnswers.Options.Count; j++)
					{
						TestOption option = testAnswers.Options[j];

						if (testAnswers.Options[j].IsChecked != test.Options[j].IsChecked)
						{
							result = false;
							break;
						}
					}
				}

				if (result)
				{
					count++;
				}
			}

			return count;
		}

		public void Update(Test test)
		{
			_testRepository.Update(test);
		}
	}
}