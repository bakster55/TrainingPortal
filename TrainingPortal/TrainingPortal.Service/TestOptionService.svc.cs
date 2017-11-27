using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.Service.Dto;

namespace TrainingPortal.Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TestOptionService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select TestOptionService.svc or TestOptionService.svc.cs at the Solution Explorer and start debugging.
	public class TestOptionService : ITestOptionService
	{
		private string _connectionString = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;

		public void Create(TestOptionDto testOption, string testId)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("AddTestOption", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@testId", SqlDbType.Int).Value = testId;
					sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = testOption.Name;
					sqlCommand.Parameters.Add("@isChecked", SqlDbType.Bit).Value = testOption.IsChecked;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
				}
			}
		}

		public void Delete(string id)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("DeleteTestOption", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
				}
			}
		}

		public TestOptionDto Get(string id)
		{
			TestOptionDto testOption = null;

			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("GetTestOption", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

					sqlConnection.Open();

					using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
					{
						while (sqlDataReader.Read())
						{
							string name = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Name"));
							bool isChecked = sqlDataReader.GetBoolean(sqlDataReader.GetOrdinal("IsChecked"));

							testOption = new TestOptionDto()
							{
								Id = id,
								IsChecked = isChecked,
								Name = name,
							};
						}

						sqlDataReader.Close();
					}
				}
			}

			return testOption;
		}

		public IList<TestOptionDto> GetList(string testId)
		{
			List<TestOptionDto> testOptions = new List<TestOptionDto>();

			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("GetTestOptions", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@testId", SqlDbType.Int).Value = testId;

					sqlConnection.Open();

					using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
					{
						while (sqlDataReader.Read())
						{
							string id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")).ToString();
							string name = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Name"));
							bool isChecked = sqlDataReader.GetBoolean(sqlDataReader.GetOrdinal("IsChecked"));

							testOptions.Add(
								new TestOptionDto()
								{
									Id = id.ToString(),
									IsChecked = isChecked,
									Name = name,
								});
						}

						sqlDataReader.Close();
					}
				}
			}

			return testOptions;
		}

		public void Update(TestOptionDto testOption)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("UpdateTestOption", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = testOption.Id;
					sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = testOption.Name;
					sqlCommand.Parameters.Add("@isChecked", SqlDbType.Bit).Value = testOption.IsChecked;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
				}
			}
		}
	}
}
