using System.Collections.Generic;

namespace TrainingPortal.Models
{
	public class Course
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public List<Category> Categories { get; set; }
	}
}