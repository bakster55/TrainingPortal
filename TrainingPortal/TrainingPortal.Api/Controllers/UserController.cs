using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
using System.Web.Security;

namespace TrainingPortal.Api.Controllers
{
	public class UserController : ApiController
	{
		private readonly string _connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog = TrainingPortal; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

		// GET: api/User
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET: api/User/5
		public string Get(int id)
		{
			return "value";
		}

		// POST: api/User
		public void Post(string name, string email, string passwordHash, string token)
		{
			using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
			{
				using (SqlCommand sqlCommand = new SqlCommand("AddUser", sqlConnection))
				{
					sqlCommand.CommandType = CommandType.StoredProcedure;

					sqlCommand.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
					sqlCommand.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
					sqlCommand.Parameters.Add("@passwordHash", SqlDbType.NVarChar).Value = email;
					sqlCommand.Parameters.Add("@token", SqlDbType.NVarChar).Value = email;

					sqlConnection.Open();
					sqlCommand.ExecuteNonQuery();
				}
			}
		}

		// PUT: api/User/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE: api/User/5
		public void Delete(int id)
		{
		}
	}
}
