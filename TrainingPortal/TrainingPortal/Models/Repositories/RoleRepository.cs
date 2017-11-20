using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace TrainingPortal.Models
{
	public class RoleRepository 
	{
		private static string _connectionString = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;

		internal static string CreateAsync(string name)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("AddRole", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add(new SqlParameter()
					{
						Direction = ParameterDirection.Output,
						DbType = DbType.Int32,
						ParameterName = "@id",
					});
					sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();

					string id = sqlCommand.Parameters["@id"].Value.ToString();

					return id;
				}
			}
		}

		internal static void DeleteRole(string id)
		{

		}

		internal static IList<Role> GetRoles()
		{
			List<Role> roles = new List<Role>();

			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("GetRoles", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlConnection.Open();

					using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
					{
						while (sqlDataReader.Read())
						{
							string id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")).ToString();
							string roleName = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Name"));

							roles.Add(new Role() { Id = id, Name = roleName });
						}

						sqlDataReader.Close();
					}
				}
			}

			return roles;
		}

		internal static Role GetRole(string id = null, string name = null)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("GetRole", sqlConnection))
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
						ParameterName = "@name",
						Value = name,
						Size = 50,
					});

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();

					Role role = new Role()
					{
						Id = sqlCommand.Parameters["@id"].Value.ToString(),
						Name = sqlCommand.Parameters["@name"].Value.ToString(),
					};

					return String.IsNullOrEmpty(role.Id) ? null : role;
				}
			}
		}

		internal static void UpdateAsync(Role role)
		{
			
		}
	}
}