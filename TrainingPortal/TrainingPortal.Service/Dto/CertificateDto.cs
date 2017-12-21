using System;

namespace TrainingPortal.Service.Dto
{
	public class CertificateDto
	{
		public Guid Id { get; set; }

		public string UserId { get; set; }

		public string CourseId { get; set; }

		public int Result { get; set; }

		public DateTime Date { get; set; }
	}
}