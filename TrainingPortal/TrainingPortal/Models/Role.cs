using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace TrainingPortal.Models
{
	public class Role : IRole
	{
		public string Id { get; set; }

		public string Name { get; set; }
	}
}