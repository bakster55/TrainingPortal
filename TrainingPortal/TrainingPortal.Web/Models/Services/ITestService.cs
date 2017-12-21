using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TrainingPortal.Models;

namespace TrainingPortal.Web.Models.Services
{
	public interface ITestService
	{
		IList<Test> GetList(string courseId);

		Test Get(string id);

		void Update(Test test);

		void Create(Test test, string courseId);

		void Delete(string id);

		int GetTrueAnswersCount(List<Test> tests, string courseId);
	}
}