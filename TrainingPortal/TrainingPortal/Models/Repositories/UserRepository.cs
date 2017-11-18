using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using TrainingPortal.Models;

namespace TrainingPortal.Models
{
	public static class UserRepository
	{
		private static string _connectionString = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;

		public static ApplicationUser GetUser(string id = null, string email = null, string name = null)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("GetUser", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						Direction = ParameterDirection.InputOutput,
						DbType = DbType.Int32,
						ParameterName = "@id",
						Value = id,
					});

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						Direction = ParameterDirection.InputOutput,
						DbType = DbType.String,
						ParameterName = "@email",
						Value = email,
						Size = 50,
					});

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						Direction = ParameterDirection.InputOutput,
						DbType = DbType.String,
						ParameterName = "@name",
						Value = name,
						Size = 50,
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

					ApplicationUser applicationUser = new ApplicationUser()
					{
						Id = sqlCommand.Parameters["@id"].Value.ToString(),
						UserName = sqlCommand.Parameters["@name"].Value.ToString(),
						Email = sqlCommand.Parameters["@email"].Value.ToString(),
						PasswordHash = sqlCommand.Parameters["@passwordHash"].Value.ToString()
					};

					return String.IsNullOrEmpty(applicationUser.Id) ? null : applicationUser;
				}
			}
		}

		internal static string UpdateUser(ApplicationUser user)
		{
			throw new NotImplementedException();
		}

		public static string CreateUser(string email, string name, string passwordHash)
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
					sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;
					sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;
					sqlCommand.Parameters.Add("@passwordHash", SqlDbType.NVarChar, -1).Value = passwordHash;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();

					string id = sqlCommand.Parameters["@id"].Value.ToString();

					return id;
				}
			}
		}
	}
}