using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using TrainingPortal.Service.Dto;

namespace TrainingPortal.Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITestOptionService" in both code and config file together.
	[ServiceContract]
	public interface ITestOptionService
	{
		[OperationContract]
		IList<TestOptionDto> GetList(string testId);

		[OperationContract]
		TestOptionDto Get(string id);

		[OperationContract]
		void Update(TestOptionDto testOption);

		[OperationContract]
		void Create(TestOptionDto testOption, string testId);

		[OperationContract]
		void Delete(string id);
	}
}
