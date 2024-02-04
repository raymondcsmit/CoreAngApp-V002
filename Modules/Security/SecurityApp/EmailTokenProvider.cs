using Microsoft.AspNetCore.Identity;
using SecurityApp.Domain;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SecurityApp
{
	public class EmailConfirmationTokenProvider<TUser> : IUserTwoFactorTokenProvider<TUser> where TUser : ApplicationUser
	{
		public Task<bool> CanGenerateTwoFactorTokenAsync(UserManager<TUser> manager, TUser user)
		{
			return Task.FromResult(true);
		}

		public Task<string> GenerateAsync(string purpose, UserManager<TUser> manager, TUser user)
		{
			// Generating an 8-digit code
			var randomNumber = new byte[4]; // 4 bytes = 32 bits, enough for an 8-digit number
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(randomNumber);
				int code = Math.Abs(BitConverter.ToInt32(randomNumber, 0)) % 100000000; // Ensuring it's positive and 8 digits
				return Task.FromResult(code.ToString("D8")); // Ensures leading zeros are added to make it 8 digits if necessary
			}
		}
		public Task<bool> ValidateAsync(string purpose, string token, UserManager<TUser> manager, TUser user)
		{

			if (user.ConfirmationCode == token)
			{
				return Task.FromResult(true);
			}

			// Token does not match or is not found
			return Task.FromResult(false);
		}
	}
	public class EmailConfirmationTokenProviderOptions : DataProtectionTokenProviderOptions
	{
	}
}
