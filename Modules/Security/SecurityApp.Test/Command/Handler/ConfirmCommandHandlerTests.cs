using MediatR;
using Microsoft.AspNetCore.Identity;
using Moq;
using SecurityApp.Application.Command;
using SecurityApp.Application.Command.Handler;
using SecurityApp.Domain;

namespace SecurityApp.Test.Command.Handler
{
	public class ConfirmCommandHandlerTests
	{
		private MockRepository mockRepository;

		private Mock<SignInManager<ApplicationUser>> mockSignInManager;
		private Mock<IMediator> mockMediator;

		public ConfirmCommandHandlerTests()
		{
			this.mockRepository = new MockRepository(MockBehavior.Strict);

			this.mockSignInManager = this.mockRepository.Create<SignInManager<ApplicationUser>>();
			this.mockMediator = this.mockRepository.Create<IMediator>();
		}

		private ConfirmCommandHandler CreateConfirmCommandHandler()
		{
			return new ConfirmCommandHandler(
				this.mockSignInManager.Object,
				this.mockMediator.Object);
		}

		[Fact]
		public async Task Handle_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var confirmCommandHandler = this.CreateConfirmCommandHandler();
			ConfirmCommand request = null;
			CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

			// Act
			var result = await confirmCommandHandler.Handle(
				request,
				cancellationToken);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}
	}
}
