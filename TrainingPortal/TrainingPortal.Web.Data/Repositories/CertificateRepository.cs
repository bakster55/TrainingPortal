using TrainingPortal.Web.Data.CertificateService;
using TrainingPortal.Data.Interfaces;
using TrainingPortal.Web.Business.Models;
using TrainingPortal.Web.Data.Converters;

namespace TrainingPortal.Data.Repositories
{
	public class CertificateRepository : ICertificateRepository
	{
		private CertificateServiceClient certificateServiceClient;

		public CertificateRepository()
		{
			certificateServiceClient = new CertificateServiceClient();
			certificateServiceClient.Open();
		}

		~CertificateRepository()
		{
			if (certificateServiceClient != null)
			{
				certificateServiceClient.Close();
			}
		}

		public void Create(Certificate certificate)
		{
			certificateServiceClient.Create(certificate.Convert());
		}

		public void Delete(string id)
		{
			certificateServiceClient.Delete(id);
		}

		public Certificate Get(string userId, string courseId)
		{
			CertificateDto certificate = certificateServiceClient.Get(userId, courseId);

			return certificate.Convert();
		}
	}
}