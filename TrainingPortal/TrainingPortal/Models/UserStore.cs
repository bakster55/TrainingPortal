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
	public partial class UserStore : IUserStore<ApplicationUser>
	{
		private string _connectionString = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;

		public Task CreateAsync(ApplicationUser user)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("AddUser", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						Direction = ParameterDirection.Output,
						DbType = DbType.Int32,
						ParameterName = "@id",
					});
					sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = user.UserName;
					sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = user.Email;
					sqlCommand.Parameters.Add("@passwordHash", SqlDbType.NVarChar, -1).Value = user.PasswordHash;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();

					user.Id = sqlCommand.Parameters["@id"].Value.ToString();

					return Task.FromResult(0);
				}
			}
		}

		public Task DeleteAsync(ApplicationUser user)
		{
			throw new NotImplementedException();
		}

		public void Dispose()
		{

		}

		public Task<ApplicationUser> FindByIdAsync(string userId)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("GetUser", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						DbType = DbType.Int32,
						ParameterName = "@id",
						Value = userId,
					});

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						Direction = ParameterDirection.Output,
						DbType = DbType.String,
						ParameterName = "@email",
						Size = 50,
					});

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						Direction = ParameterDirection.Output,
						DbType = DbType.String,
						ParameterName = "@name",
						Size = 50,
					});

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();

					ApplicationUser applicationUser = new ApplicationUser()
					{
						Id = sqlCommand.Parameters["@id"].Value.ToString(),
						UserName = sqlCommand.Parameters["@name"].Value.ToString(),
						Email = sqlCommand.Parameters["@email"].Value.ToString()
					};

					return Task.FromResult(applicationUser);
				}
			}
		}

		public Task<ApplicationUser> FindByNameAsync(string userName)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("GetUser", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						Direction = ParameterDirection.Output,
						DbType = DbType.Int32,
						ParameterName = "@id",
					});

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						Direction = ParameterDirection.Output,
						DbType = DbType.String,
						ParameterName = "@email",
						Size = 50,
					});

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						DbType = DbType.String,
						ParameterName = "@name",
						Value = userName,
						Size = 50,
					});

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();

					ApplicationUser applicationUser = new ApplicationUser()
					{
						Id = sqlCommand.Parameters["@id"].Value.ToString(),
						UserName = userName,
						Email = sqlCommand.Parameters["@email"].Value.ToString()
					};

					return String.IsNullOrEmpty(applicationUser.Id) ? Task.FromResult((ApplicationUser)null) : Task.FromResult(applicationUser);
				}
			}
		}

		public Task UpdateAsync(ApplicationUser user)
		{
			throw new NotImplementedException();
		}
	}

	public partial class UserStore : IUserPasswordStore<ApplicationUser>
	{
		public Task<string> GetPasswordHashAsync(ApplicationUser user)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("GetUser", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						DbType = DbType.Int32,
						ParameterName = "@id",
						Value = user.Id
					});

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						Direction = ParameterDirection.Output,
						DbType = DbType.String,
						ParameterName = "@passwordHash",
						Size = -1,
					});

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();

					string passwordHash = sqlCommand.Parameters["@passwordHash"].Value.ToString();

					return Task.FromResult(passwordHash);
				}
			}
		}

		public Task<bool> HasPasswordAsync(ApplicationUser user)
		{
			throw new NotImplementedException();
		}

		public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
		{
			user.PasswordHash = passwordHash;
			return Task.FromResult(0);
		}
	}

	public partial class UserStore : IUserEmailStore<ApplicationUser>
	{
		public Task<ApplicationUser> FindByEmailAsync(string email)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("GetUser", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						Direction = ParameterDirection.Output,
						DbType = DbType.Int32,
						ParameterName = "@id"
					});

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						DbType = DbType.String,
						ParameterName = "@email",
						Value = email,
						Size = 50,
					});

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						Direction = ParameterDirection.Output,
						DbType = DbType.String,
						ParameterName = "@name",
						Size = 50,
					});

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();

					ApplicationUser applicationUser = new ApplicationUser()
					{
						Id = sqlCommand.Parameters["@id"].Value.ToString(),
						UserName = sqlCommand.Parameters["@name"].Value.ToString(),
						Email = sqlCommand.Parameters["@email"].Value.ToString()
					};

					return String.IsNullOrEmpty(applicationUser.Id) ? Task.FromResult((ApplicationUser)null) : Task.FromResult(applicationUser);
				}
			}
		}

		public Task<string> GetEmailAsync(ApplicationUser user)
		{
			return String.IsNullOrEmpty(user.Id) ? Task.FromResult(user.Email) : Task.FromResult(user.Email);
		}

		public Task<bool> GetEmailConfirmedAsync(ApplicationUser user)
		{
			throw new NotImplementedException();
		}

		public Task SetEmailAsync(ApplicationUser user, string email)
		{
			throw new NotImplementedException();
		}

		public Task SetEmailConfirmedAsync(ApplicationUser user, bool confirmed)
		{
			throw new NotImplementedException();
		}
	}

	public partial class UserStore : IUserLockoutStore<ApplicationUser, string>
	{
		public Task<int> GetAccessFailedCountAsync(ApplicationUser user)
		{
			return Task.FromResult(0);
		}

		public Task<bool> GetLockoutEnabledAsync(ApplicationUser user)
		{
			return Task.FromResult(false);
		}

		public Task<DateTimeOffset> GetLockoutEndDateAsync(ApplicationUser user)
		{
			return Task.FromResult(new DateTimeOffset());
		}

		public Task<int> IncrementAccessFailedCountAsync(ApplicationUser user)
		{
			return Task.FromResult(0);
		}

		public Task ResetAccessFailedCountAsync(ApplicationUser user)
		{
			return Task.FromResult(0);
		}

		public Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled)
		{
			return Task.FromResult(0);
		}

		public Task SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset lockoutEnd)
		{
			return Task.FromResult(0);
		}
	}

	public partial class UserStore : IUserTwoFactorStore<ApplicationUser, string>
	{
		public Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user)
		{
			return Task.FromResult(false);
		}

		public Task SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled)
		{
			return Task.FromResult(0);
		}
	}
}