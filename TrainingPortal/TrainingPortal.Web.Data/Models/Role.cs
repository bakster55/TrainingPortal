using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using TrainingPortal.Web.Data.RoleService;

namespace TrainingPortal.Data.Models
{
	public class Role : IRole
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public static implicit operator Role(RoleDto role)
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

		public static implicit operator RoleDto(Role role)
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