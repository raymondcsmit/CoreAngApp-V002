using Moq;
using SecurityApp.Application.Queries;
using SecurityApp.Application.Queries.Handler;
using SecurityApp.Infrastructure;

namespace SecurityApp.Test.Queries.Handlers
{
	public class GetAllTenantsQueryHandlerTests
	{
		private MockRepository mockRepository;

		private Mock<ApplicationDbContext> mockApplicationDbContext;

		public GetAllTenantsQueryHandlerTests()
		{
			this.mockRepository = new MockRepository(MockBehavior.Strict);

			this.mockApplicationDbContext = this.mockRepository.Create<ApplicationDbContext>();
		}

		private GetAllTenantsQueryHandler CreateGetAllTenantsQueryHandler()
		{
			return new GetAllTenantsQueryHandler(
				this.mockApplicationDbContext.Object);
		}

		[Fact]
		public async Task Handle_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var getAllTenantsQueryHandler = this.CreateGetAllTenantsQueryHandler();
			GetAllTenantsQuery query = null;
			CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

			// Act
			var result = await getAllTenantsQueryHandler.Handle(
				query,
				cancellationToken);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}
	}
}
