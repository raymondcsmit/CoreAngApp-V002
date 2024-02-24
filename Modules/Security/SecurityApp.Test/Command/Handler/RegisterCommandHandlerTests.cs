using Core.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Moq;
using SecurityApp.Application.Command;
using SecurityApp.Application.Command.Handler;
using SecurityApp.Domain;

namespace SecurityApp.Test.Command.Handler
{
	public class RegisterCommandHandlerTests
	{
		private MockRepository mockRepository;

		private Mock<UserManager<ApplicationUser>> mockUserManager;
		private Mock<IOptions<Tenant>> mockOptions;
		private Mock<IMediator> mockMediator;

		public RegisterCommandHandlerTests()
		{
			this.mockRepository = new MockRepository(MockBehavior.Strict);

			this.mockUserManager = this.mockRepository.Create<UserManager<ApplicationUser>>();
			this.mockOptions = this.mockRepository.Create<IOptions<Tenant>>();
			this.mockMediator = this.mockRepository.Create<IMediator>();
		}

		private RegisterCommandHandler CreateRegisterCommandHandler()
		{
			return new RegisterCommandHandler(
				this.mockUserManager.Object,
				this.mockOptions.Object,
				this.mockMediator.Object);
		}

		[Fact]
		public async Task Handle_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var registerCommandHandler = this.CreateRegisterCommandHandler();
			RegisterCommand request = null;
			CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

			// Act
			var result = await registerCommandHandler.Handle(
				request,
				cancellationToken);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}
	}
}
