using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.Service.Dto;

namespace TrainingPortal.Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserRoleService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select UserRoleService.svc or UserRoleService.svc.cs at the Solution Explorer and start debugging.
	public class UserRoleService : IUserRoleService
	{
		private string _connectionString = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;

		public void Create(string userId, string roleName)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("AddUserToRole", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						Direction = ParameterDirection.Input,
						DbType = DbType.Int32,
						ParameterName = "@userId",
						Value = userId,
					});

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						Direction = ParameterDirection.Input,
						DbType = DbType.String,
						ParameterName = "@roleName",
						Value = roleName,
						Size = 50,
					});

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
				}
			}
		}

		public void Delete(string userId, string roleName)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("DeleteUserFromRole", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						Direction = ParameterDirection.Input,
						DbType = DbType.Int32,
						ParameterName = "@userId",
						Value = userId,
					});

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						Direction = ParameterDirection.Input,
						DbType = DbType.String,
						ParameterName = "@roleName",
						Size = 50,
						Value = roleName,
					});

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
				}
			}
		}

		public bool Exist(string userId, string roleName)
		{
			bool exist = false;

			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("IsUserInRole", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						Direction = ParameterDirection.Input,
						DbType = DbType.Int32,
						ParameterName = "@userId",
						Value = userId,
					});

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						Direction = ParameterDirection.Input,
						DbType = DbType.String,
						ParameterName = "@roleName",
						Size = 50,
						Value = roleName,
					});

					sqlConnection.Open();

					exist = sqlCommand.ExecuteReader().HasRows;
				}
			}

			return exist;
		}

		public IList<string> GetList(string userId)
		{
			List<string> roleNames = new List<string>();

			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("GetUserRoles", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						Direction = ParameterDirection.Input,
						DbType = DbType.Int32,
						ParameterName = "@userId",
						Value = userId,
					});

					sqlConnection.Open();

					using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
					{
						while (sqlDataReader.Read())
						{
							string roleName = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Name"));
							roleNames.Add(roleName);
						}

						sqlDataReader.Close();
					}
				}
			}

			return roleNames;
		}
	}
}
