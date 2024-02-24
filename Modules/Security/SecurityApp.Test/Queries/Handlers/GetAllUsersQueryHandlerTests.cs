using Microsoft.AspNetCore.Identity;
using Moq;
using SecurityApp.Application.Queries;
using SecurityApp.Application.Queries.Handler;
using SecurityApp.Domain;

namespace SecurityApp.Test.Queries.Handlers
{
	public class GetAllUsersQueryHandlerTests
	{
		private MockRepository mockRepository;

		private Mock<UserManager<ApplicationUser>> mockUserManager;

		public GetAllUsersQueryHandlerTests()
		{
			this.mockRepository = new MockRepository(MockBehavior.Strict);

			// Create an instance of ApplicationUserStore
			var mockUserStore = new Mock<IUserStore<ApplicationUser>>();

			// Pass the instance of IUserStore<ApplicationUser> to the constructor
			this.mockUserManager = new Mock<UserManager<ApplicationUser>>(mockUserStore.Object, null, null, null, null, null, null, null, null);
		}

		private GetAllUsersQueryHandler CreateGetAllUsersQueryHandler()
		{
			return new GetAllUsersQueryHandler(
				this.mockUserManager.Object);
		}

		[Fact]
		public async Task Handle_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var getAllUsersQueryHandler = this.CreateGetAllUsersQueryHandler();
			GetAllUsersQuery query = null;
			CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

			// Act
			var result = await getAllUsersQueryHandler.Handle(
				query,
				cancellationToken);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}
	}

}
