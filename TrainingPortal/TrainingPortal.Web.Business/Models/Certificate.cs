using System;

namespace TrainingPortal.Web.Business.Models
{
	public class Certificate
	{
		public string Id { get; set; }

		public string UserId { get; set; }

		public int Result { get; set; }

		public string CourseId { get; set; }

		public DateTime Date { get; set; }
	}
}