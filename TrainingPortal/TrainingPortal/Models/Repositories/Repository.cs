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
	public class Repository
	{
		private static string _connectionString = ConfigurationManager.ConnectionStrings["Local"].ConnectionString;
	}
}