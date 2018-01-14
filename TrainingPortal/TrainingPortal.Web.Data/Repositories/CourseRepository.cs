using TrainingPortal.Web.Data.CourseService;
using TrainingPortal.Data.Interfaces;
using TrainingPortal.Web.Business.Models;
using TrainingPortal.Web.Data.Converters;
using System.Linq;

namespace TrainingPortal.Data.Repositories
{
	public class CourseRepository : ICourseRepository
	{
		private CourseServiceClient courseServiceClient;
		private ICategoryRepository _categoryRepository;
		private IAudienceRepository _audienceRepository;

		public CourseRepository(
			ICategoryRepository categoryRepository,
			IAudienceRepository audienceRepository
			)
		{
			_categoryRepository = categoryRepository;
			_audienceRepository = audienceRepository;
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

		public void Create(Course course)
		{
			courseServiceClient.Create(course.Convert());
		}

		public void Delete(string id)
		{
			courseServiceClient.Delete(id);
		}

		public Course Get(string id)
		{
			CourseDto course = courseServiceClient.Get(id);
			Audience audience = _audienceRepository.Get(course.AudienceId);
			Category category = _categoryRepository.Get(course.CategoryId);

			return course.Convert(audience, category);
		}

		public Course[] GetList()
		{
			Course[] courses = courseServiceClient.GetList().Select((c) =>
			{
				Audience audience = _audienceRepository.Get(c.AudienceId);
				Category category = _categoryRepository.Get(c.CategoryId);

				Course course = c.Convert(audience, category);
				return course;
			}).ToArray();

			return courses;
		}

		public void Update(Course course)
		{
			courseServiceClient.Update(course.Convert());
		}
	}
}