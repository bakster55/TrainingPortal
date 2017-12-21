using TrainingPortal.Web.Data.CourseService;

namespace TrainingPortal.Data.Repositories
{
	public class CourseRepository : ICourseService
	{
		private CourseServiceClient courseServiceClient;

		public CourseRepository()
		{
			courseServiceClient = new CourseServiceClient();
			courseServiceClient.Open();
		}

		~CourseRepository()
		{
			if (courseServiceClient != null)
			{
				courseServiceClient.Close();
			}
		}

		public void Create(CourseDto course)
		{
			courseServiceClient.Create(course);
		}

		public void Delete(string id)
		{
			courseServiceClient.Delete(id);
		}

		public CourseDto Get(string id)
		{
			CourseDto course = courseServiceClient.Get(id);

			return course;
		}

		public CourseDto[] GetList()
		{
			CourseDto[] categories = courseServiceClient.GetList();

			return categories;
		}

		public void Update(CourseDto course)
		{
			courseServiceClient.Update(course);
		}
	}
}