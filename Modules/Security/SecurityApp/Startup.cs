using Core;
using Core.Contracts;
using Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SecurityApp.Application.Command;
using SecurityApp.Domain;
using SecurityApp.Infrastructure;
using System;
using System.Text;

namespace SecurityApp
{
	public class Startup : PluginStartupBase
	{
		private readonly CoreDbContextOptionsBuilder OptionsBuilder;
		private readonly IConfigurationRoot config;
		public Startup(CoreDbContextOptionsBuilder optb, IConfigurationRoot _config)
		{
			OptionsBuilder = optb;
			config = _config;
			RoutePrefix = "Auth";
		}

		public override void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<ApplicationDbContext>(options => OptionsBuilder.SelectDatabase<ApplicationDbContext>());


			services.AddIdentity<ApplicationUser, ApplicationRole>(opt =>
				{
					opt.Password.RequiredLength = 7;
					opt.Password.RequireDigit = false;
					opt.Password.RequireUppercase = false;
					opt.User.RequireUniqueEmail = true;
					opt.SignIn.RequireConfirmedEmail = true;
					opt.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";
				})
					.AddEntityFrameworkStores<ApplicationDbContext>()
					.AddSignInManager<SignInManager<ApplicationUser>>()
					.AddUserManager<UserManager<ApplicationUser>>()
					.AddDefaultTokenProviders()
					.AddTokenProvider<EmailConfirmationTokenProvider<ApplicationUser>>("emailconfirmation"); ;// to generate email confirmation token
			var jwt = config.GetSection("Jwt").Get<JwtConfiguration>();
			services.Configure<EmailConfirmationTokenProviderOptions>(opt =>
						opt.TokenLifespan = TimeSpan.FromDays(3));
			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(options =>
			{
				options.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = jwt.Issuer,
					ValidAudience = jwt.Audience,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key))
				};
			});

			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(LoginCommand).Assembly));
			services.AddControllers();
		}

		public override void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			using (var scope = app.ApplicationServices.CreateScope())
			{
				var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
				var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
				var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
				DbInitializer.SeedData(context, userManager, roleManager).Wait();
			}
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}