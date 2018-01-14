namespace TrainingPortal.Web.Business.Models
{
	public class Course
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public Category Category { get; set; }
		public Audience Audience { get; set; }
	}
}