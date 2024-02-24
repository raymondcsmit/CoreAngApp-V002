using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using SecurityApp.Application.Command;
using SecurityApp.Controllers;

namespace SecurityApp.Test.Controllers
{
	public class SecurityControllerTests
	{
		private MockRepository mockRepository;

		private Mock<ILogger<SecurityController>> mockLogger;
		private Mock<IMediator> mockMediator;

		public SecurityControllerTests()
		{
			this.mockRepository = new MockRepository(MockBehavior.Strict);

			this.mockLogger = this.mockRepository.Create<ILogger<SecurityController>>();
			this.mockMediator = this.mockRepository.Create<IMediator>();
		}

		private SecurityController CreateSecurityController()
		{
			return new SecurityController(
				this.mockLogger.Object,
				this.mockMediator.Object);
		}

		[Fact]
		public async Task LogIn_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var securityController = this.CreateSecurityController();
			LoginCommand command = null;

			// Act
			var result = await securityController.LogIn(
				command);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}

		[Fact]
		public async Task Register_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var securityController = this.CreateSecurityController();
			RegisterCommand command = null;

			// Act
			var result = await securityController.Register(
				command);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}

		[Fact]
		public async Task Confirm_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var securityController = this.CreateSecurityController();
			ConfirmCommand command = null;

			// Act
			var result = await securityController.Confirm(
				command);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}

		[Fact]
		public async Task Logout_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var securityController = this.CreateSecurityController();

			// Act
			var result = await securityController.Logout();

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}

		[Fact]
		public async Task Get_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var securityController = this.CreateSecurityController();

			// Act
			var result = await securityController.Get();

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}
	}
}
