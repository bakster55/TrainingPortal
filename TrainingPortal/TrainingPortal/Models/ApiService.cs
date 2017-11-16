using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingPortal.Models
{
	public class ApiService : IApiService
	{
		public string GetMessage()
		{
			return "Hello";
		}

		public string GetMessageException()
		{
			throw new NotImplementedException();
		}
	}
}