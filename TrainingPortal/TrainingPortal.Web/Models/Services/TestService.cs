using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingPortal.Web.Business.Models;
using TrainingPortal.Web.Data.TestService;
using TrainingPortal.Web.Data.TestOptionService;
using TrainingPortal.Data.Interfaces;

namespace TrainingPortal.Web.Models.Services
{
	public class TestService : ITestService
	{
		private ITestRepository _testRepository;

		public TestService(
			ITestRepository testRepository
			)
		{
			_testRepository = testRepository;
		}

		public int GetTrueAnswersCount(List<Test> tests, string courseId)
		{
			List<Test> testsAnswers = _testRepository.GetList(courseId).ToList();

			int count = 0;

			for (int i = 0; i < tests.Count; i++)
			{
				bool result = true;
				Test testAnswers = testsAnswers[i];
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