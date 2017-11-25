using System.Collections.Generic;
using System.ServiceModel;
using TrainingPortal.Service.Dto;

namespace TrainingPortal.Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ILessonService" in both code and config file together.
	[ServiceContract]
	public interface ILessonService
	{
		[OperationContract]
		IList<LessonDto> GetList(string courseId);

		[OperationContract]
		LessonDto Get(string id);

		[OperationContract]
		void Update(LessonDto lesson);

		[OperationContract]
		void Create(LessonDto lesson, string courseId);

		[OperationContract]
		void Delete(string id);
	}
}
