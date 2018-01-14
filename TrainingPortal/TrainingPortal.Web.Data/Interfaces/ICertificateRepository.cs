using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Data.Interfaces
{
	public interface ICertificateRepository
	{
		void Create(Certificate certificate);
		void Delete(string id);
		Certificate Get(string userId, string courseId);
	}
}