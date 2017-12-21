using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using TrainingPortal.Controllers;
using TrainingPortal.Models;
using TrainingPortal.Web.Data.TestOptionService;
using TrainingPortal.Web.Data.TestService;
using TrainingPortal.Web.Models.Services;

namespace TrainingPortal.Tests
{
	[TestClass]
	public class TestServiceTests
	{
		private Mock<TrainingPortal.Web.Data.TestService.ITestService> _testRepository;
		private Mock<ITestOptionService> _testOptionRepository;

		[TestInitialize]
		public void TestInitialize()
		{
			_testRepository = new Mock<TrainingPortal.Web.Data.TestService.ITestService>();
			_testOptionRepository = new Mock<ITestOptionService>();
		}

		[TestMethod]
		public void GetTrueAnswersCount_PassTwoFalse_ZeroReturned()
		{
			_testRepository
				.Setup(e => e.GetList(It.IsAny<string>()))
				.Returns((string courseId) =>
				{
					return new TestDto[]
					{
							new TestDto { Id = "6", Question = "A"},
							new TestDto { Id = "8", Question = "B"},
					};
				});

			_testOptionRepository
				.Setup(e => e.GetList(It.IsAny<string>()))
				.Returns((string courseId) =>
				{
					return new TestOptionDto[]
					{
							new TestOptionDto { Id = "3", Name = "A", IsChecked = true},
							new TestOptionDto { Id = "5", Name = "B", IsChecked = true},
					};
				});

			//_certificateRepository
			//	.Setup(e => e.Get(It.IsAny<string>(), It.IsAny<string>()))
			//	.Returns((CertificateDto certificate) =>
			//	{
			//		return null;
			//	});
			//_certificateRepository
			//	.Setup(e => e.Create(It.IsAny<CertificateDto>()))
			//	.Callback((CertificateDto certificate) =>
			//	{
			//		Assert.IsTrue(certificate.Result == 2);
			//	});

			var testService = new TestService(_testRepository.Object, _testOptionRepository.Object);

			var tests = new Test[]
				{
						new Test
						{
							Options = new TestOption[]
							{
									new TestOption { Id = "3", Name = "A", IsChecked = false},
									new TestOption { Id = "5", Name = "B", IsChecked = false},
							}.ToList()
						},
						new Test {
							Options = new TestOption[]
							{
									new TestOption { Id = "3", Name = "A", IsChecked = false},
									new TestOption { Id = "5", Name = "B", IsChecked = false},
							}.ToList()
						}
				}.ToList();

			int actualResult = testService.GetTrueAnswersCount(tests, "12");

			Assert.IsTrue(actualResult == 0);
		}
	}
}
