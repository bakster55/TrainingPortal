using System;
using System.Collections.Generic;
using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Web.Models.Services
{
	public interface ITestService
	{
		int GetTrueAnswersCount(List<Test> tests, string courseId);
	}
}