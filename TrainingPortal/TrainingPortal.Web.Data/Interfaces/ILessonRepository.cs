using TrainingPortal.Web.Data.LessonService;
using TrainingPortal.Web.Business.Models;
namespace TrainingPortal.Data.Interfaces
{
	public interface ILessonRepository
	{
		void Create(Lesson lesson, string courseId);
		void Delete(string id);
		Lesson Get(string id);
		Lesson[] GetList(string courseId);
		void Update(Lesson lesson);
	}
}