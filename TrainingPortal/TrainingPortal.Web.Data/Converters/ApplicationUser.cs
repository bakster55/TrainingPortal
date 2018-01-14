using TrainingPortal.Web.Data.UserService;
using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Web.Data.Converters
{
	public static partial class Converter
	{
		public static ApplicationUser Convert(this UserDto user)
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

		public static UserDto Convert(this ApplicationUser user)
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
	}
}