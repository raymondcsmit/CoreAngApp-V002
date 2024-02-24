using Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;
using SecurityApp.Application.Command;
using SecurityApp.Application.Command.Handler;
using SecurityApp.Domain;

namespace SecurityApp.Test.Command.Handler
{
	public class LogOutCommandHandlerTests
	{
		private MockRepository mockRepository;

		private Mock<SignInManager<ApplicationUser>> mockSignInManager;
		private Mock<UserManager<ApplicationUser>> mockUserManager;
		private Mock<IOptions<Tenant>> mockOptions;
		private Mock<IConfigurationRoot> mockConfigurationRoot;
		private Mock<IHttpContextAccessor> mockHttpContextAccessor;
		private Mock<IMediator> mockMediator;

		public LogOutCommandHandlerTests()
		{
			this.mockRepository = new MockRepository(MockBehavior.Strict);

			this.mockSignInManager = this.mockRepository.Create<SignInManager<ApplicationUser>>();
			this.mockUserManager = this.mockRepository.Create<UserManager<ApplicationUser>>();
			this.mockOptions = this.mockRepository.Create<IOptions<Tenant>>();
			this.mockConfigurationRoot = this.mockRepository.Create<IConfigurationRoot>();
			this.mockHttpContextAccessor = this.mockRepository.Create<IHttpContextAccessor>();
			this.mockMediator = this.mockRepository.Create<IMediator>();
		}

		private LogOutCommandHandler CreateLogOutCommandHandler()
		{
			return new LogOutCommandHandler(
				this.mockSignInManager.Object,
				this.mockUserManager.Object,
				this.mockOptions.Object,
				this.mockConfigurationRoot.Object,
				this.mockHttpContextAccessor.Object,
				this.mockMediator.Object);
		}

		[Fact]
		public async Task Handle_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var logOutCommandHandler = this.CreateLogOutCommandHandler();
			LogOutCommand request = null;
			CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

			// Act
			var result = await logOutCommandHandler.Handle(
				request,
				cancellationToken);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}

		[Fact]
		public void GetCurrentUserId_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var logOutCommandHandler = this.CreateLogOutCommandHandler();

			// Act
			var result = logOutCommandHandler.GetCurrentUserId();

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}
	}
}
