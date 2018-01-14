using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Models.Stores
{
	public partial class UserStore : IUserPasswordStore<ApplicationUser>
	{
		public Task<string> GetPasswordHashAsync(ApplicationUser user)
		{
			return Task.FromResult<string>(user.PasswordHash);
		}

		public Task<bool> HasPasswordAsync(ApplicationUser user)
		{
			return Task.FromResult(user.PasswordHash != null);
		}

		public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
		{
			user.PasswordHash = passwordHash;
			return Task.FromResult(0);
		}
	}
}