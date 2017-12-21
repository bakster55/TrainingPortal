using TrainingPortal.Web.Data.CertificateService;

namespace TrainingPortal.Data.Repositories
{
	public class CertificateRepository : ICertificateService
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

		public void Create(CertificateDto certificate)
		{
			certificateServiceClient.Create(certificate);
		}

		public void Delete(string id)
		{
			certificateServiceClient.Delete(id);
		}

		public CertificateDto Get(string userId, string courseId)
		{
			CertificateDto certificate = certificateServiceClient.Get(userId, courseId);

			return certificate;
		}
	}
}