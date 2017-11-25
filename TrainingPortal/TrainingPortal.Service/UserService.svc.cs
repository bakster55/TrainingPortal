using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.Service.Dto;

namespace TrainingPortal.Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "UserService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select UserService.svc or UserService.svc.cs at the Solution Explorer and start debugging.
	public class UserService : IUserService
	{
		private string _connectionString = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;

		public IList<UserDto> GetList()
		{
			List<UserDto> users = new List<UserDto>();

			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("GetUsers", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlConnection.Open();

					using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
					{
						while (sqlDataReader.Read())
						{
							string id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")).ToString();
							string email = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Email"));
							string passwordHash = sqlDataReader.GetString(sqlDataReader.GetOrdinal("PasswordHash"));
							string userName = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Name"));

							users.Add(new UserDto() { Id = id, Email = email, PasswordHash = passwordHash, UserName = userName });
						}

						sqlDataReader.Close();
					}
				}
			}

			return users;
		}

		public UserDto Get(string id = null, string email = null, string name = null)
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

					UserDto user = new UserDto()
					{
						Id = sqlCommand.Parameters["@id"].Value.ToString(),
						UserName = sqlCommand.Parameters["@name"].Value.ToString(),
						Email = sqlCommand.Parameters["@email"].Value.ToString(),
						PasswordHash = sqlCommand.Parameters["@passwordHash"].Value.ToString()
					};

					return String.IsNullOrEmpty(user.Id) ? null : user;
				}
			}
		}

		public void Update(UserDto user)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("UpdateUser", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = user.Id;
					sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = user.UserName;
					sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = user.Email;
					sqlCommand.Parameters.Add("@passwordHash", SqlDbType.NVarChar, -1).Value = user.PasswordHash;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
				}
			}
		}

		public string Create(UserDto user)
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

					string id = sqlCommand.Parameters["@id"].Value.ToString();

					return id;
				}
			}
		}

		public void Delete(string id)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("DeleteUser", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
				}
			}
		}
	}
}
