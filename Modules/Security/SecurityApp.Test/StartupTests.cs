using Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace SecurityApp.Test
{
	public class StartupTests
	{
		private MockRepository mockRepository;

		private Mock<CoreDbContextOptionsBuilder> mockCoreDbContextOptionsBuilder;
		private Mock<IConfigurationRoot> mockConfigurationRoot;

		public StartupTests()
		{
			this.mockRepository = new MockRepository(MockBehavior.Strict);

			this.mockCoreDbContextOptionsBuilder = this.mockRepository.Create<CoreDbContextOptionsBuilder>();
			this.mockConfigurationRoot = this.mockRepository.Create<IConfigurationRoot>();
		}

		private Startup CreateStartup()
		{
			return new Startup(
				this.mockCoreDbContextOptionsBuilder.Object,
				this.mockConfigurationRoot.Object);
		}

		[Fact]
		public void ConfigureServices_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var startup = this.CreateStartup();
			IServiceCollection services = null;

			// Act
			startup.ConfigureServices(
				services);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}

		[Fact]
		public void Configure_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var startup = this.CreateStartup();
			IApplicationBuilder app = null;
			IWebHostEnvironment env = null;

			// Act
			startup.Configure(
				app,
				env);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}
	}
}
