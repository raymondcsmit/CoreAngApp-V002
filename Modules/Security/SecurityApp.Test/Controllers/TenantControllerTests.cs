using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using SecurityApp.Application.Command;
using SecurityApp.Controllers;

namespace SecurityApp.Test.Controllers
{
	public class TenantControllerTests
	{
		private MockRepository mockRepository;

		private Mock<ILogger<SecurityController>> mockLogger;
		private Mock<IMediator> mockMediator;

		public TenantControllerTests()
		{
			this.mockRepository = new MockRepository(MockBehavior.Strict);

			this.mockLogger = this.mockRepository.Create<ILogger<SecurityController>>();
			this.mockMediator = this.mockRepository.Create<IMediator>();
		}

		private TenantController CreateTenantController()
		{
			return new TenantController(
				this.mockLogger.Object,
				this.mockMediator.Object);
		}

		[Fact]
		public async Task Register_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var tenantController = this.CreateTenantController();
			RegisterTenantCommand command = null;

			// Act
			var result = await tenantController.Register(
				command);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}

		[Fact]
		public async Task Get_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var tenantController = this.CreateTenantController();

			// Act
			var result = await tenantController.Get();

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}
	}
}
