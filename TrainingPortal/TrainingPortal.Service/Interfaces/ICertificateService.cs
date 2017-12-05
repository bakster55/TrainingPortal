using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using TrainingPortal.Service.Dto;

namespace TrainingPortal.Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICertificateService" in both code and config file together.
	[ServiceContract]
	public interface ICertificateService
	{
		[OperationContract]
		CertificateDto Get(string userId, string courseId);

		[OperationContract]
		void Create(CertificateDto certificate);

		[OperationContract]
		void Delete(string id);
	}
}
