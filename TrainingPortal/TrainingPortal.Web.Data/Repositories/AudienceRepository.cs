using System.Linq;
using TrainingPortal.Data.Interfaces;
using TrainingPortal.Web.Business.Models;
using TrainingPortal.Web.Data.AudienceService;
using TrainingPortal.Web.Data.Converters;

namespace TrainingPortal.Data.Repositories
{
	public class AudienceRepository : IAudienceRepository
	{
		private AudienceServiceClient audienceServiceClient;

		public AudienceRepository()
		{
			audienceServiceClient = new AudienceServiceClient();
			audienceServiceClient.Open();
		}

		~AudienceRepository()
		{
			if (audienceServiceClient != null)
			{
				audienceServiceClient.Close();
			}
		}

		public void Create(Audience audience)
		{
			audienceServiceClient.Create(audience.Convert());
		}

		public void Delete(string id)
		{
			audienceServiceClient.Delete(id);
		}

		public Audience Get(string id)
		{
			AudienceDto audience = audienceServiceClient.Get(id);

			return audience.Convert();
		}

		public Audience[] GetList()
		{
			AudienceDto[] audienceList = audienceServiceClient.GetList();

			return audienceList.Select((a) => a.Convert()).ToArray();
		}

		public void Update(Audience audience)
		{
			audienceServiceClient.Update(audience.Convert());
		}
	}
}