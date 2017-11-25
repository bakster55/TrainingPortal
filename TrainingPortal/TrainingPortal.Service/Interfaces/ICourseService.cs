using System.Collections.Generic;
using System.ServiceModel;
using TrainingPortal.Service.Dto;

namespace TrainingPortal.Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICourseService" in both code and config file together.
	[ServiceContract]
	public interface ICourseService
	{
		[OperationContract]
		IList<CourseDto> GetList();

		[OperationContract]
		CourseDto Get(string id);

		[OperationContract]
		void Update(CourseDto course);

		[OperationContract]
		void Create(CourseDto course);

		[OperationContract]
		void Delete(string id);
	}
}
