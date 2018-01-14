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
	using TrainingPortal.Data.Interfaces;
	using log4net;
	using TrainingPortal.Web.Models.Services;

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

			For<ILog>().Use(LogManager.GetLogger("Logger"));
			For<IAudienceRepository>().Use<AudienceRepository>();
			For<ICategoryRepository>().Use<CategoryRepository>();
			For<ICertificateRepository>().Use<CertificateRepository>();
			For<ICourseRepository>().Use<CourseRepository>();
			For<ILessonRepository>().Use<LessonRepository>();
			For<IRoleRepository>().Use<RoleRepository>();
			For<ITestOptionRepository>().Use<TestOptionRepository>();
			For<ITestRepository>().Use<TestRepository>();
			For<IUserRepository>().Use<UserRepository>();
			For<IUserRoleRepository>().Use<UserRoleRepository>();

			For<ITestService>().Use<TestService>();
		}

		#endregion
	}
}