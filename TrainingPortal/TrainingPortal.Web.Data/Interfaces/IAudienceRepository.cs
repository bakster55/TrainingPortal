using TrainingPortal.Web.Business.Models;

namespace TrainingPortal.Data.Interfaces
{
	public interface IAudienceRepository
	{
		void Create(Audience audience);
		void Delete(string id);
		Audience Get(string id);
		Audience[] GetList();
		void Update(Audience audience);
	}
}