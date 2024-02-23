using System;
using System.Text;

namespace Core.Utilities
{
	public static class Helper
	{
		public static string GenerateUniqueCode()
		{
			// Set up a random number generator
			Random random = new Random();

			// Define a list of characters to choose from
			string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

			// Create a StringBuilder to build the string
			StringBuilder sb = new StringBuilder();

			// Generate a random string of 4 characters
			for (int j = 0; j < 4; j++)
			{
				// Append a random character from the characters list
				sb.Append(characters[random.Next(characters.Length)]);
			}

			// Generate a random number between 1000 and 9999
			int randomNumber = random.Next(1000, 10000);

			// Append the random number
			sb.Append(randomNumber);

			// Return the generated unique code
			return sb.ToString();
		}
	}
}
