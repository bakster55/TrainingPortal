using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TrainingPortal.Models
{
	public class UserRoleRepository
	{
		private static string _connectionString = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;

		internal static void AddToRoleAsync(ApplicationUser user, string roleName)
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
						Value = user.Id,
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

		internal static IList<string> GetRolesAsync(ApplicationUser user)
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
						Value = user.Id,
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

		internal static bool IsInRoleAsync(ApplicationUser user, string roleName)
		{
			bool isInRole = false;

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
						Value = user.Id,
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

					isInRole = sqlCommand.ExecuteReader().HasRows;
				}
			}

			return isInRole;
		}

		internal static void RemoveFromRoleAsync(ApplicationUser user, string roleName)
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
						Value = user.Id,
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
	}
}