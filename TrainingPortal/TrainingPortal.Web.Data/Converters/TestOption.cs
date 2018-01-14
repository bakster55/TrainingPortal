using System.Collections.Generic;
using TrainingPortal.Web.Data.TestService;
using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Web.Data.Converters
{
	public static partial class Converter
	{
		//From TestService
		//public static implicit operator TestOption(TrainingPortal.Client.TestService.TestOptionDto option)
		//{
		//	if (option != null)
		//	{
		//		return new TrainingPortal.Client.TestService.TestOptionDto()
		//		{
		//			Id = option.Id,
		//			Name = option.Name,
		//			IsChecked = option.IsChecked
		//		};
		//	}

		//	return null;
		//}

		//public static implicit operator TrainingPortal.Client.TestService.TestOptionDto(TestOption option)
		//{
		//	if (option != null)
		//	{
		//		return new TrainingPortal.Client.TestService.TestOptionDto()
		//		{
		//			Id = option.Id,
		//			Name = option.Name,
		//			IsChecked = option.IsChecked
		//		};
		//	}

		//	return null;
		//}

		//From TestOptionService
		public static TestOption Convert(this TrainingPortal.Web.Data.TestOptionService.TestOptionDto option)
		{
			if (option != null)
			{
				return new TestOption()
				{
					Id = option.Id,
					Name = option.Name,
					IsChecked = option.IsChecked
				};
			}

			return null;
		}

		public static TrainingPortal.Web.Data.TestOptionService.TestOptionDto Convert(this TestOption option)
		{
			if (option != null)
			{
				return new TrainingPortal.Web.Data.TestOptionService.TestOptionDto()
				{
					Id = option.Id,
					Name = option.Name,
					IsChecked = option.IsChecked
				};
			}

			return null;
		}
	}
}