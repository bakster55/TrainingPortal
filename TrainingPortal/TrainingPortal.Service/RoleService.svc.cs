using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.Service.Dto;

namespace TrainingPortal.Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RoleService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select RoleService.svc or RoleService.svc.cs at the Solution Explorer and start debugging.
	public class RoleService : IRoleService
	{
		private string _connectionString = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;

		public string Create(RoleDto role)
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
					sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = role.Name;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();

					string id = sqlCommand.Parameters["@id"].Value.ToString();

					return id;
				}
			}
		}

		public void Delete(string id)
		{
			throw new NotImplementedException();
		}

		public RoleDto Get(string id, string name)
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

					RoleDto role = new RoleDto()
					{
						Id = sqlCommand.Parameters["@id"].Value.ToString(),
						Name = sqlCommand.Parameters["@name"].Value.ToString(),
					};

					return String.IsNullOrEmpty(role.Id) ? null : role;
				}
			}
		}

		public IList<RoleDto> GetList()
		{
			List<RoleDto> roles = new List<RoleDto>();

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

							roles.Add(new RoleDto() { Id = id, Name = roleName });
						}

						sqlDataReader.Close();
					}
				}
			}

			return roles;
		}

		public void Update(RoleDto course)
		{
			throw new NotImplementedException();
		}
	}
}
