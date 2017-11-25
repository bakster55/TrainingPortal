using System;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using TrainingPortal.Client.UserService;

namespace TrainingPortal.Models
{
	public class ApplicationUser : IUser
	{
		public string Id { get; set; }

		public string UserName { get; set; }

		public string Email { get; set; }

		public string PasswordHash { get; set; }

		public static implicit operator ApplicationUser(UserDto user)
		{
			if (user != null)
			{
				return new ApplicationUser()
				{
					Email = user.Email,
					Id = user.Id,
					PasswordHash = user.PasswordHash,
					UserName = user.UserName,
				};
			}

			return null;
		}

		public static implicit operator UserDto(ApplicationUser user)
		{
			if (user != null)
			{
				return new UserDto()
				{
					Email = user.Email,
					Id = user.Id,
					PasswordHash = user.PasswordHash,
					UserName = user.UserName,
				};
			}

			return null;
		}

		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
		{
			// Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
			var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
			// Add custom user claims here
			return userIdentity;
		}
	}
}