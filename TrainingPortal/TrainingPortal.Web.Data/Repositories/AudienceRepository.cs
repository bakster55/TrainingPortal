using TrainingPortal.Web.Data.AudienceService;

namespace TrainingPortal.Data.Repositories
{
	public class AudienceRepository : IAudienceService
	{
		private AudienceServiceClient audienceServiceClient;

		public AudienceRepository()
		{
			audienceServiceClient = new AudienceServiceClient();
			audienceServiceClient.Open();
		}

		~AudienceRepository()
		{
			audienceServiceClient.Close();
		}

		public void Create(AudienceDto audience)
		{
			audienceServiceClient.Create(audience);
		}

		public void Delete(string id)
		{
			audienceServiceClient.Delete(id);
		}

		public AudienceDto Get(string id)
		{
			AudienceDto audience = audienceServiceClient.Get(id);

			return audience;
		}

		public AudienceDto[] GetList()
		{
			AudienceDto[] audienceList = audienceServiceClient.GetList();

			return audienceList;
		}

		public void Update(AudienceDto audience)
		{
			audienceServiceClient.Update(audience);
		}
	}
}