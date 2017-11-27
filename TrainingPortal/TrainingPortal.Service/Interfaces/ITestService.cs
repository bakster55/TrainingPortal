using System.Collections.Generic;
using System.ServiceModel;
using TrainingPortal.Service.Dto;

namespace TrainingPortal.Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITestService" in both code and config file together.
	[ServiceContract]
	public interface ITestService
	{
		[OperationContract]
		IList<TestDto> GetList(string courseId);

		[OperationContract]
		TestDto Get(string id);

		[OperationContract]
		void Update(TestDto test);

		[OperationContract]
		void Create(TestDto test, string courseId);

		[OperationContract]
		void Delete(string id);
	}
}
