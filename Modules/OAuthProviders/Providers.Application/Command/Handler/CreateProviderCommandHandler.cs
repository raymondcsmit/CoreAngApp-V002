﻿using Core.Models;
using Core.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Providers.Domain;
using Providers.Infrastructure;
using System.Net;

namespace SecurityApp.Application.Command.Handler
{

	public class CreateProviderCommandHandler : IRequestHandler<CreateProviderCommand, ResponseResult>
	{
		private readonly Tenant _tenant;
		private readonly ProviderContext _dbContext;
		public CreateProviderCommandHandler(IOptions<Tenant> options)
		{
			_tenant = options.Value;
		}

		public async Task<ResponseResult> Handle(CreateProviderCommand request, CancellationToken cancellationToken)
		{
			var existingProvider = await _dbContext.ProviderSettingsEntries
									.Where(p => p.Name == request.Name)
									.FirstOrDefaultAsync();

			if (existingProvider != null)
			{
				return new ResponseResult()
				{
					StatusCode = HttpStatusCode.BadRequest,
					Success = false,
					Message = $"Provider with name '{request.Name}' already exists"
				};
			}
			OAuth2ProviderSettings settings = new OAuth2ProviderSettings()
			{
				ClientId = request.ClientId,
				ClientSecret = request.ClientSecret,
				AuthorizationEndpoint = request.AuthorizationEndpoint,
				Name = request.Name,
				Scopes = request.Scopes,
				RedirectUri = request.RedirectUri,
				State = request.State,
				TokenEndpoint = request.TokenEndpoint,
				UserinfoEndpoint = request.UserinfoEndpoint,

			};
			_dbContext.ProviderSettingsEntries.Add(settings);
			await _dbContext.SaveChangesAsync();

			return new ResponseResult()
			{

				Data = settings,
				StatusCode = HttpStatusCode.OK,
				Success = true,
				Message = "Provider Added Successfully"
			};
			//return tokenHandler.WriteToken(token);
		}
	}

}
