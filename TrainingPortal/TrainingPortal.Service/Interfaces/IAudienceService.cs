using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using TrainingPortal.Service.Dto;

namespace TrainingPortal.Service
{
	[ServiceContract]
	public interface IAudienceService
	{
		[OperationContract]
		IList<AudienceDto> GetList();

		[OperationContract]
		AudienceDto Get(string id);

		[OperationContract]
		void Update(AudienceDto audience);

		[OperationContract]
		void Create(AudienceDto audience);

		[OperationContract]
		void Delete(string id);
	}
}
