using System.Collections.Generic;

namespace TrainingPortal.Web.Business.Models
{
	public class Test
	{
		public string Id { get; set; }
		public string Question { get; set; }
		public List<TestOption> Options { get; set; }
	}
}