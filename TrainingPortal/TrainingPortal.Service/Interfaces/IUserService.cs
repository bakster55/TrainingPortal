using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using TrainingPortal.Service.Dto;

namespace TrainingPortal.Service
{
	[ServiceContract]
	public interface IUserService
	{

		[OperationContract]
		IList<UserDto> GetList();

		[OperationContract]
		UserDto Get(string id, string email, string name);

		[OperationContract]
		void Update(UserDto user);

		[OperationContract]
		string Create(UserDto user);

		[OperationContract]
		void Delete(string id);
	}
}
