using Moq;
using SecurityApp.Application.Events;
using SecurityApp.Application.Events.Handler;
using SecurityApp.Infrastructure;

namespace SecurityApp.Test.Events.Handler
{
	public class UserActivityEventHandlerTests
	{
		private MockRepository mockRepository;

		private Mock<ApplicationDbContext> mockApplicationDbContext;

		public UserActivityEventHandlerTests()
		{
			this.mockRepository = new MockRepository(MockBehavior.Strict);

			this.mockApplicationDbContext = this.mockRepository.Create<ApplicationDbContext>();
		}

		private UserActivityEventHandler CreateUserActivityEventHandler()
		{
			return new UserActivityEventHandler(
				this.mockApplicationDbContext.Object);
		}

		[Fact]
		public async Task Handle_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var userActivityEventHandler = this.CreateUserActivityEventHandler();
			UserActivityEvent notification = null;
			CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

			// Act
			await userActivityEventHandler.Handle(
				notification,
				cancellationToken);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}
	}
}
