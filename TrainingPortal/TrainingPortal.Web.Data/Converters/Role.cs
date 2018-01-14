using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using TrainingPortal.Web.Data.RoleService;
using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Web.Data.Converters
{
	public static partial class Converter
	{
		public static Role Convert(this RoleDto role)
		{
			if (role != null)
			{
				return new Role()
				{
					Id = role.Id,
					Name = role.Name,
				};
			}

			return null;
		}

		public static RoleDto Convert(this Role role)
		{
			if (role != null)
			{
				return new RoleDto()
				{
					Id = role.Id,
					Name = role.Name,
				};
			}

			return null;
		}
	}
}