// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultRegistry.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace TrainingPortal.DependencyResolution
{
	using StructureMap.Configuration.DSL;
	using StructureMap.Graph;
	using TrainingPortal.Data.Repositories;
	using TrainingPortal.Web.Data.AudienceService;
	using TrainingPortal.Web.Data.CategoryService;
	using TrainingPortal.Web.Data.CertificateService;
	using TrainingPortal.Web.Data.CourseService;
	using TrainingPortal.Web.Data.LessonService;
	using TrainingPortal.Web.Data.TestOptionService;
	using TrainingPortal.Web.Data.TestService;
	using TrainingPortal.Web.Data.RoleService;
	using TrainingPortal.Web.Data.UserRoleService;
	using TrainingPortal.Web.Data.UserService;

	public class DefaultRegistry : Registry
	{
		#region Constructors and Destructors

		public DefaultRegistry()
		{
			Scan(
					scan =>
					{
						scan.TheCallingAssembly();
						scan.WithDefaultConventions();
						scan.With(new ControllerConvention());
					});

			For<IAudienceService>().Use<AudienceRepository>();
			For<ICategoryService>().Use<CategoryRepository>();
			For<ICertificateService>().Use<CertificateRepository>();
			For<ICourseService>().Use<CourseRepository>();
			For<ILessonService>().Use<LessonRepository>();
			For<IRoleService>().Use<RoleRepository>();
			For<ITestOptionService>().Use<TestOptionRepository>();
			For<ITestService>().Use<TestRepository>();
			For<IUserService>().Use<UserRepository>();
			For<IUserRoleService>().Use<UserRoleRepository>();
		}

		#endregion
	}
}