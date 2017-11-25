using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.Service.Dto;

namespace TrainingPortal.Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LessonService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select LessonService.svc or LessonService.svc.cs at the Solution Explorer and start debugging.
	public class LessonService : ILessonService
	{
		private string _connectionString = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;

		public void Create(LessonDto lesson, string courseId)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("AddLesson", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = lesson.Name;
					sqlCommand.Parameters.Add("@content", SqlDbType.NVarChar, -1).Value = lesson.Content;
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
				using (SqlCommand sqlCommand = new SqlCommand("DeleteLesson", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
				}
			}
		}

		public LessonDto Get(string id)
		{
			LessonDto lesson = null;

			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("GetLesson", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

					sqlConnection.Open();

					using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
					{
						while (sqlDataReader.Read())
						{
							string name = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Name"));
							string content = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Content"));

							lesson = new LessonDto()
							{
								Id = id.ToString(),
								Content = content,
								Name = name,
							};
						}

						sqlDataReader.Close();
					}
				}
			}

			return lesson;
		}

		public IList<LessonDto> GetList(string courseId)
		{
			List<LessonDto> lessons = new List<LessonDto>();

			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("GetLessons", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@courseId", SqlDbType.Int).Value = courseId;

					sqlConnection.Open();

					using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
					{
						while (sqlDataReader.Read())
						{
							string id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")).ToString();
							string name = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Name"));
							string content = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Content"));

							lessons.Add(
								new LessonDto()
								{
									Id = id.ToString(),
									Content = content,
									Name = name,
								});
						}

						sqlDataReader.Close();
					}
				}
			}

			return lessons;
		}

		public void Update(LessonDto lesson)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("UpdateLesson", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = lesson.Id;
					sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = lesson.Name;
					sqlCommand.Parameters.Add("@content", SqlDbType.NVarChar, -1).Value = lesson.Content;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
				}
			}
		}
	}
}
