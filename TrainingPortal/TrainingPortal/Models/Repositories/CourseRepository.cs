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
	public static class CourseRepository
	{
		private static string _connectionString = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;

		public static void CreateCourse(Course course)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("AddCourse", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = course.Name;
					sqlCommand.Parameters.Add("@description", SqlDbType.NVarChar, -1).Value = course.Description;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
				}
			}
		}

		public static List<Course> GetCourses()
		{
			List<Course> courses = new List<Course>();

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

							courses.Add(new Course() { Id = id, Description = description, Name = name });
						}

						sqlDataReader.Close();
					}
				}
			}

			return courses;
		}

		internal static void UpdateCourse(int id, Course course)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("UpdateCourse", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
					sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = course.Name;
					sqlCommand.Parameters.Add("@description", SqlDbType.NVarChar, -1).Value = course.Description;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
				}
			}
		}

		public static Course GetCourse(int id)
		{
			Course course = null;

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

							course = new Course() { Id = id.ToString(), Description = description, Name = name };
						}

						sqlDataReader.Close();
					}
				}
			}

			return course;
		}

		public static void DeleteCourse(int id)
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