using System.Collections.Generic;
using System.ServiceModel;
using TrainingPortal.Service.Dto;

namespace TrainingPortal.Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserRoleService" in both code and config file together.
	[ServiceContract]
	public interface IUserRoleService
	{
		[OperationContract]
		IList<string> GetList(string userId);

		[OperationContract]
		bool Exist(string userId, string roleName);

		[OperationContract]
		void Create(string userId, string roleName);

		[OperationContract]
		void Delete(string userId, string roleName);
	}
}
