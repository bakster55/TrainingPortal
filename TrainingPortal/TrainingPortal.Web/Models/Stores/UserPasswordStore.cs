using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TrainingPortal.Models
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