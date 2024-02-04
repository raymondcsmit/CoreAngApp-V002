using Core.Events;
using Core.Models;
using Core.Responses;
using Core.Utilities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SecurityApp.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SecurityApp.Application.Command.Handler
{

	public class LoginCommandHandler : IRequestHandler<LoginCommand, ResponseResult>
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly IHttpContextAccessor contextAccessor;
		private readonly IConfigurationRoot _configuration;
		private readonly IMediator _mediator;
		private readonly Tenant _tenant;
		public LoginCommandHandler(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IOptions<Tenant> options, IConfigurationRoot configuration, IHttpContextAccessor cta, IMediator mediator)
		{
			_signInManager = signInManager;
			_userManager = userManager;
			_configuration = configuration;
			contextAccessor = cta;
			_tenant = options.Value;
			_mediator = mediator;
		}
		public async Task<ResponseResult> Handle(LoginCommand request, CancellationToken cancellationToken)
		{
			var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, false, false);
			if (!result.Succeeded)
			{
				// Consider using a logging mechanism to log the error details
				return ResponseFactory.CreateError($"Unable to login user: {result}", HttpStatusCode.Unauthorized);
			}

			var user = await _userManager.FindByEmailAsync(request.Email);
			if (user == null)
			{
				return ResponseFactory.CreateNotFound("User not found.");
			}

			if (!user.EmailConfirmed)
			{
				return ResponseFactory.CreateForbidden("User did not enter confirmation code.");
			}

			var roles = await _userManager.GetRolesAsync(user);
			var token = GenerateAccessToken(user, roles);
			var refreshToken = GenerateRefreshToken(user.Id);

			user.RefreshTokens = user.RefreshTokens ?? new List<RefreshToken>();
			user.RefreshTokens.Add(refreshToken);
			await _userManager.UpdateAsync(user);

			var @event = new AuditLogEvent
			{
				AuditData = new AuditEntry
				{
					Action = "LogIn",
					EntityName = "ApplicationUser",
					ObjectValue = SerializeDeSerialize.SerializeObject(user)
				}
			};
			await _mediator.Publish(@event, cancellationToken);

			var tokenDetail = new TokenDetail
			{
				AccessToken = token,
				TokenLifeTime = int.Parse(_configuration["Jwt:ExpiresInMinutes"]),
				RefreshToken = refreshToken,
				UserName = user.UserName,
				Message = "Success"
			};

			return ResponseFactory.CreateSuccess("User successfully logged in.", tokenDetail);
		}
		private string GenerateAccessToken(ApplicationUser user, IList<string> roles)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
			DateTime ExpiryTime = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpiresInMinutes"]));

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
				new Claim(ClaimTypes.Name, user.UserName,ClaimValueTypes.String),
				new Claim(ClaimTypes.Email, user.Email,ClaimValueTypes.String),
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString(),ClaimValueTypes.String),
				new Claim(ClaimTypes.Role, string.Join(",", roles)),
				new Claim("tenantId",_tenant.TenantId.ToString()),
				new Claim("userId", user.Id.ToString())
				}),
				Expires = ExpiryTime,
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}
		private RefreshToken GenerateRefreshToken(long userId)
		{
			var ipAddress = contextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
			var randomBytes = new byte[64];
			using (var rng = RandomNumberGenerator.Create())
			{
				rng.GetBytes(randomBytes);
				return new RefreshToken
				{
					Token = Convert.ToBase64String(randomBytes),
					Expiry = DateTime.UtcNow.AddDays(double.Parse(_configuration["Jwt:RefreshTokenExpiryInDays"])),
					Created = DateTime.UtcNow,
					CreatedByIp = ipAddress,
					UserId = userId.ToString()

				};
			}
		}
	}

}
