using System.Collections.Generic;
using System.ServiceModel;
using TrainingPortal.Service.Dto;

namespace TrainingPortal.Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRoleService" in both code and config file together.
	[ServiceContract]
	public interface IRoleService
	{
		[OperationContract]
		IList<RoleDto> GetList();

		[OperationContract]
		RoleDto Get(string id, string name);

		[OperationContract]
		void Update(RoleDto role);

		[OperationContract]
		string Create(RoleDto role);

		[OperationContract]
		void Delete(string id);
	}
}
