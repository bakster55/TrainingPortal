using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPortal.Models
{
	public interface IApiService
	{
		string GetMessage();

		string GetMessageException();
	}
}
