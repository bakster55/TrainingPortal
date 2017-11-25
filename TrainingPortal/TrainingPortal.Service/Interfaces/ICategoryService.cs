using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using TrainingPortal.Service.Dto;

namespace TrainingPortal.Service
{
	[ServiceContract]
	public interface ICategoryService
	{
		[OperationContract]
		IList<CategoryDto> GetList();

		[OperationContract]
		CategoryDto Get(string id);

		[OperationContract]
		void Update(CategoryDto category);

		[OperationContract]
		void Create(CategoryDto category);

		[OperationContract]
		void Delete(string id);
	}
}
