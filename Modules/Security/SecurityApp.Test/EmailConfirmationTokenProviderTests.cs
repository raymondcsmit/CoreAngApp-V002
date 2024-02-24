using Microsoft.AspNetCore.Identity;
using Moq;
using SecurityApp.Domain;

namespace SecurityApp.Test
{
	public class EmailConfirmationTokenProviderTests
	{
		private MockRepository mockRepository;



		public EmailConfirmationTokenProviderTests()
		{
			this.mockRepository = new MockRepository(MockBehavior.Strict);


		}

		private EmailConfirmationTokenProvider<ApplicationUser> CreateProvider()
		{
			return new EmailConfirmationTokenProvider<ApplicationUser>();
		}

		[Fact]
		public async Task CanGenerateTwoFactorTokenAsync_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var provider = this.CreateProvider();
			UserManager<ApplicationUser> manager = null;
			ApplicationUser user = null;

			// Act
			var result = await provider.CanGenerateTwoFactorTokenAsync(
				manager,
				user);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}

		[Fact]
		public async Task GenerateAsync_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var provider = this.CreateProvider();
			string purpose = null;
			UserManager<ApplicationUser> manager = null;
			ApplicationUser user = null;

			// Act
			var result = await provider.GenerateAsync(
				purpose,
				manager,
				user);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}

		[Fact]
		public async Task ValidateAsync_StateUnderTest_ExpectedBehavior()
		{
			// Arrange
			var provider = this.CreateProvider();
			string purpose = null;
			string token = null;
			UserManager<ApplicationUser> manager = null;
			ApplicationUser user = null;

			// Act
			var result = await provider.ValidateAsync(
				purpose,
				token,
				manager,
				user);

			// Assert
			Assert.True(false);
			this.mockRepository.VerifyAll();
		}
	}
}
