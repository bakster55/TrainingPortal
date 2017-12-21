using System;
using TrainingPortal.Web.Data.CertificateService;

namespace TrainingPortal.Models
{
	public class Certificate
	{
		public string Id { get; set; }

		public string UserId { get; set; }

		public int Result { get; set; }

		public string CourseId { get; set; }

		public DateTime Date { get; set; }

		public static implicit operator Certificate(CertificateDto certificate)
		{
			if (certificate != null)
			{
				return new Certificate()
				{
					Id = certificate.Id.ToString(),
					CourseId = certificate.CourseId,
					UserId = certificate.UserId,
					Result = certificate.Result,
					Date = certificate.Date
				};
			}

			return null;
		}

		public static implicit operator CertificateDto(Certificate certificate)
		{
			if (certificate != null)
			{
				return new CertificateDto()
				{
					Id = Guid.Parse(certificate.Id),
					CourseId = certificate.CourseId,
					UserId = certificate.UserId,
					Result = certificate.Result,
					Date = certificate.Date
				};
			}

			return null;
		}
	}
}