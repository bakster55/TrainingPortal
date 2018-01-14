using Microsoft.AspNet.Identity;

namespace TrainingPortal.Web.Business.Models
{
	public class Role : IRole
	{
		public string Id { get; set; }

		public string Name { get; set; }
	}
}