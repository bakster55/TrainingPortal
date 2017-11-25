using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.Service.Dto;

namespace TrainingPortal.Service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CourseService" in code, svc and config file together.
	// NOTE: In order to launch WCF Test Client for testing this service, please select CourseService.svc or CourseService.svc.cs at the Solution Explorer and start debugging.
	public class CourseService : ICourseService
	{
		private string _connectionString = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;

		public IList<CourseDto> GetList()
		{
			List<CourseDto> courses = new List<CourseDto>();

			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("GetCourses", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlConnection.Open();

					using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
					{
						while (sqlDataReader.Read())
						{
							string id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("Id")).ToString();
							string name = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Name"));
							string description = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Description"));

							string categoryId = sqlDataReader.GetInt32(4).ToString();
							string categoryName = sqlDataReader.GetString(5);

							courses.Add(
								new CourseDto()
								{
									Id = id.ToString(),
									Description = description,
									Name = name,
									Category = new CategoryDto() { Id = categoryId, Name = categoryName }
								});
						}

						sqlDataReader.Close();
					}
				}
			}

			return courses;
		}

		public CourseDto Get(string id)
		{
			CourseDto course = null;

			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("GetCourse", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;

					sqlConnection.Open();

					using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
					{
						while (sqlDataReader.Read())
						{
							string name = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Name"));
							string description = sqlDataReader.GetString(sqlDataReader.GetOrdinal("Description"));

							string categoryId = sqlDataReader.GetInt32(4).ToString();
							string categoryName = sqlDataReader.GetString(5);

							course = new CourseDto()
							{
								Id = id.ToString(),
								Description = description,
								Name = name,
								Category = new CategoryDto() { Id = categoryId, Name = categoryName }
							};
						}

						sqlDataReader.Close();
					}
				}
			}

			return course;
		}

		public void Update(CourseDto course)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("UpdateCourse", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = course.Id;
					sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = course.Name;
					sqlCommand.Parameters.Add("@description", SqlDbType.NVarChar, -1).Value = course.Description;
					sqlCommand.Parameters.Add("@categoryId", SqlDbType.Int).Value = course.Category.Id;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
				}
			}
		}

		public void Create(CourseDto course)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("AddCourse", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = course.Name;
					sqlCommand.Parameters.Add("@description", SqlDbType.NVarChar, -1).Value = course.Description;
					sqlCommand.Parameters.Add("@categoryId", SqlDbType.Int).Value = course.Category.Id;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
				}
			}
		}

		public void Delete(string id)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("DeleteCourse", sqlConnection))
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
