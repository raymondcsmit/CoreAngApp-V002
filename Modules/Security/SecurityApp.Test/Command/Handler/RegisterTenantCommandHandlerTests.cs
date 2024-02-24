using MediatR;
using Moq;
using SecurityApp.Application.Command;
using SecurityApp.Application.Command.Handler;
using SecurityApp.Infrastructure;

namespace SecurityApp.Test.Command.Handler
{
	public class RegisterTenantCommandHandlerTests
	{
		private MockRepository mockRepository;

		private Mock<ApplicationDbContext> mockApplicationDbContext;
		private Mock<IMediator> mockMediator;

		public RegisterTenantCommandHandlerTests()
		{
			this.mockRepository = new MockRepository(MockBehavior.Strict);

			this.mockApplicationDbContext = this.mockRepository.Create<ApplicationDbContext>();
			this.mockMediator = this.mockRepository.Create<IMediator>();
		}

		private RegisterTenantCommandHandler CreateRegisterTenantCommandHandler()
		{
			return new RegisterTenantCommandHandler(
				this.mockApplicationDbContext.Object,
				this.mockMediator.Object);
		}

		[Fact]
		public async Task Handle_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var registerTenantCommandHandler = this.CreateRegisterTenantCommandHandler();
			RegisterTenantCommand request = null;
			CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

			// Act
			var result = await registerTenantCommandHandler.Handle(
				request,
				cancellationToken);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}
	}
}
