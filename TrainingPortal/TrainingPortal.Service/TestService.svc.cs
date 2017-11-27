using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.Service.Dto;

namespace TrainingPortal.Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TestService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select TestService.svc or TestService.svc.cs at the Solution Explorer and start debugging.
	public class TestService : ITestService
	{
		private string _connectionString = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;

		public void Create(TestDto test, string courseId)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("AddTest", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@question", SqlDbType.NVarChar, -1).Value = test.Question;
					sqlCommand.Parameters.Add("@courseId", SqlDbType.Int).Value = courseId;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
				}
			}
		}

		public void Delete(string id)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("DeleteTest", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
				}
			}
		}

		public TestDto Get(string id)
		{
			TestDto test = null;

			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("GetTest", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

					sqlConnection.Open();

					using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
					{
						while (sqlDataReader.Read())
						{
							string question = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Question"));

							test = new TestDto()
							{
								Id = id,
								Question = question,
							};
						}

						sqlDataReader.Close();
					}
				}
			}

			return test;
		}

		public IList<TestDto> GetList(string courseId)
		{
			List<TestDto> tests = new List<TestDto>();

			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("GetTests", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@courseId", SqlDbType.Int).Value = courseId;

					sqlConnection.Open();

					using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
					{
						while (sqlDataReader.Read())
						{
							string id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")).ToString();
							string question = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Question"));

							tests.Add(
								new TestDto()
								{
									Id = id,
									Question = question,
								});
						}

						sqlDataReader.Close();
					}
				}
			}

			return tests;
		}

		public void Update(TestDto test)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("UpdateTest", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = test.Id;
					sqlCommand.Parameters.Add("@question", SqlDbType.NVarChar, -1).Value = test.Question;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
				}
			}
		}
	}
}
