using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using TrainingPortal.Service.Dto;

namespace TrainingPortal.Service
{
	public class CertificateService : ICertificateService
	{
		private string _connectionString = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;

		public void Create(CertificateDto certificate)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("AddCertificate", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = certificate.Id;
					sqlCommand.Parameters.Add("@courseId", SqlDbType.Int).Value = certificate.CourseId;
					sqlCommand.Parameters.Add("@userId", SqlDbType.Int).Value = certificate.UserId;
					sqlCommand.Parameters.Add("@result", SqlDbType.Int).Value = certificate.Result;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
				}
			}
		}

		public void Delete(string id)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("DeleteCertificate", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@id", SqlDbType.UniqueIdentifier).Value = id;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
				}
			}
		}

		public CertificateDto Get(string userId, string courseId)
		{
			CertificateDto certificate = null;

			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("GetCertificate", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@userId", SqlDbType.Int).Value = userId;
					sqlCommand.Parameters.Add("@courseId", SqlDbType.Int).Value = courseId;

					sqlConnection.Open();

					using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
					{
						while (sqlDataReader.Read())
						{
							Guid id = sqlDataReader.GetGuid(sqlDataReader.GetOrdinal("id"));
							int result = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("result"));

							certificate = new CertificateDto() { Id = id, UserId = userId, CourseId = courseId, Result = result };
						}

						return certificate;
					}
				}
			}
		}
	}
}
