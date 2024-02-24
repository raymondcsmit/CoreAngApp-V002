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
	public class LoginCommandHandlerTests
	{
		private MockRepository mockRepository;

		private Mock<SignInManager<ApplicationUser>> mockSignInManager;
		private Mock<UserManager<ApplicationUser>> mockUserManager;
		private Mock<IOptions<Tenant>> mockOptions;
		private Mock<IConfigurationRoot> mockConfigurationRoot;
		private Mock<IHttpContextAccessor> mockHttpContextAccessor;
		private Mock<IMediator> mockMediator;

		public LoginCommandHandlerTests()
		{
			this.mockRepository = new MockRepository(MockBehavior.Strict);

			this.mockSignInManager = this.mockRepository.Create<SignInManager<ApplicationUser>>();
			this.mockUserManager = this.mockRepository.Create<UserManager<ApplicationUser>>();
			this.mockOptions = this.mockRepository.Create<IOptions<Tenant>>();
			this.mockConfigurationRoot = this.mockRepository.Create<IConfigurationRoot>();
			this.mockHttpContextAccessor = this.mockRepository.Create<IHttpContextAccessor>();
			this.mockMediator = this.mockRepository.Create<IMediator>();
		}

		private LoginCommandHandler CreateLoginCommandHandler()
		{
			return new LoginCommandHandler(
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
			var loginCommandHandler = this.CreateLoginCommandHandler();
			LoginCommand request = null;
			CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

			// Act
			var result = await loginCommandHandler.Handle(
				request,
				cancellationToken);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}
	}
}
