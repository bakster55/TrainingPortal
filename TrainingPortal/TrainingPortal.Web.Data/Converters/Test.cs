using System.Collections.Generic;
using System.Linq;
using TrainingPortal.Web.Data.TestService;
using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Web.Data.Converters
{
	public static partial class Converter
	{
		public static Test Convert(this TestDto test, List<TestOption> testOptions)
		{
			if (test != null)
			{
				return new Test()
				{
					Id = test.Id,
					Question = test.Question,
					Options = testOptions
				};
			}

			return null;
		}

		public static TestDto Convert(this Test test)
		{
			if (test != null)
			{
				return new TestDto()
				{
					Id = test.Id,
					Question = test.Question,
				};
			}

			return null;
		}
	}
}