using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using TrainingPortal.Controllers;
using TrainingPortal.Data.Interfaces;
using TrainingPortal.Models;
using TrainingPortal.Web.Business.Models;
using TrainingPortal.Web.Data.TestOptionService;
using TrainingPortal.Web.Data.TestService;
using TrainingPortal.Web.Models.Services;

namespace TrainingPortal.Tests
{
	[TestClass]
	public class TestServiceTests
	{
		private Mock<ITestRepository> _testRepository;

		[TestInitialize]
		public void TestInitialize()
		{
			_testRepository = new Mock<ITestRepository>();
		}

		[TestMethod]
		public void GetTrueAnswersCount_PassTwoFalseOfTwo_ZeroReturned()
		{
			_testRepository
				.Setup(e => e.GetList(It.IsAny<string>()))
				.Returns((string courseId) =>
				{
					return new Test[]
					{
							new Test {
								Id = "6",
								Question = "A",
								Options = new TestOption[]
								{
													new TestOption { Id = "3", Name = "A", IsChecked = true},
													new TestOption { Id = "5", Name = "B", IsChecked = true},
								}.ToList()
							},
							new Test {
								Id = "8",
								Question = "B",
								Options = new TestOption[]
								{
													new TestOption { Id = "3", Name = "A", IsChecked = true},
													new TestOption { Id = "5", Name = "B", IsChecked = true},
								}.ToList()
							},
					};
				});

			var testService = new TestService(_testRepository.Object);

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

		[TestMethod]
		public void GetTrueAnswersCount_PassTwoTrueOfThree_TwoReturned()
		{
			_testRepository
				.Setup(e => e.GetList(It.IsAny<string>()))
				.Returns((string courseId) =>
				{
					return new Test[]
					{
							new Test {
								Id = "1",
								Question = "A",
								Options = new TestOption[]
								{
								new TestOption { Id = "1", Name = "A", IsChecked = true},
								new TestOption { Id = "2", Name = "B", IsChecked = false},
								}.ToList()
							},
							new Test {
								Id = "2",
								Question = "B",
								Options = new TestOption[]
								{
								new TestOption { Id = "1", Name = "A", IsChecked = true},
								new TestOption { Id = "2", Name = "B", IsChecked = false},
								}.ToList()
							},
							new Test {
								Id = "3",
								Question = "C",
								Options = new TestOption[]
								{
								new TestOption { Id = "1", Name = "A", IsChecked = true},
								new TestOption { Id = "2", Name = "B", IsChecked = false},
								}.ToList()
							},
					};
				});

			var testService = new TestService(_testRepository.Object);

			var tests = new Test[]
				{
						new Test
						{
							Options = new TestOption[]
							{
									new TestOption { Id = "1", Name = "A", IsChecked = true},
									new TestOption { Id = "2", Name = "B", IsChecked = false},
							}.ToList()
						},
						new Test {
							Options = new TestOption[]
							{
									new TestOption { Id = "1", Name = "A", IsChecked = false},
									new TestOption { Id = "2", Name = "B", IsChecked = false},
							}.ToList()
						},
						new Test {
							Options = new TestOption[]
							{
									new TestOption { Id = "1", Name = "A", IsChecked = true},
									new TestOption { Id = "2", Name = "B", IsChecked = false},
							}.ToList()
						}
				}.ToList();

			int actualResult = testService.GetTrueAnswersCount(tests, "12");

			Assert.IsTrue(actualResult == 2);
		}
	}
}
