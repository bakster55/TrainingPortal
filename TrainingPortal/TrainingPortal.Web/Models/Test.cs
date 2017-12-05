using System.Collections.Generic;
using System.Linq;
using TrainingPortal.Web.Data.TestService;

namespace TrainingPortal.Models
{
	public class Test
	{
		public string Id { get; set; }
		public string Question { get; set; }
		public List<TestOption> Options { get; set; }

		public static implicit operator Test(TestDto test)
		{
			if (test != null)
			{
				return new Test()
				{
					Id = test.Id,
					Question = test.Question,
					//Options = test.Options.Cast<TestOption>().ToList(),
				};
			}

			return null;
		}

		public static implicit operator TestDto(Test test)
		{
			if (test != null)
			{
				return new TestDto()
				{
					Id = test.Id,
					Question = test.Question,
					//Options = test.Options.Cast<TestOptionDto>().ToArray(),
				};
			}

			return null;
		}
	}
}