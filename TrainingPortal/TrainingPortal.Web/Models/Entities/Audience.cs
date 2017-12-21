using TrainingPortal.Web.Data.AudienceService;

namespace TrainingPortal.Models
{
	public class Audience
	{
		public string Id { get; set; }

		public string Name { get; set; }

		//From CourseService
		public static implicit operator Audience(TrainingPortal.Web.Data.CourseService.AudienceDto audience)
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

		public static implicit operator TrainingPortal.Web.Data.CourseService.AudienceDto(Audience audience)
		{
			if (audience != null)
			{
				return new TrainingPortal.Web.Data.CourseService.AudienceDto()
				{
					Id = audience.Id,
					Name = audience.Name,
				};
			}

			return null;
		}

		//From AudienceService
		public static implicit operator Audience(TrainingPortal.Web.Data.AudienceService.AudienceDto audience)
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

		public static implicit operator TrainingPortal.Web.Data.AudienceService.AudienceDto(Audience audience)
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