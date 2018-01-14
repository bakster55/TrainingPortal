namespace TrainingPortal.Data.Interfaces
{
	public interface IUserRoleRepository
	{
		void Create(string userId, string roleName);
		void Delete(string userId, string roleName);
		bool Exist(string userId, string roleName);
		string[] GetList(string userId);
	}
}