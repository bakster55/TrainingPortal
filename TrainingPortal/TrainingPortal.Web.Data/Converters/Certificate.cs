using System;
using TrainingPortal.Web.Data.CertificateService;
using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Web.Data.Converters
{
	public static partial class Converter
	{
		public static Certificate Convert(this CertificateDto certificate)
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

		public static CertificateDto Convert(this Certificate certificate)
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