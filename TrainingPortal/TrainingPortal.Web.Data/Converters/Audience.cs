using TrainingPortal.Web.Data.AudienceService;
using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Web.Data.Converters
{
	public static partial class Converter
	{
		//From AudienceService
		public static Audience Convert(this TrainingPortal.Web.Data.AudienceService.AudienceDto audience)
		{
			if (audience != null)
			{
				return new Audience()
				{
					Id = audience.Id,
					Name = audience.Name,
				};
			}

			return null;
		}

		public static TrainingPortal.Web.Data.AudienceService.AudienceDto Convert(this Audience audience)
		{
			if (audience != null)
			{
				return new TrainingPortal.Web.Data.AudienceService.AudienceDto()
				{
					Id = audience.Id,
					Name = audience.Name,
				};
			}

			return null;
		}
	}
}