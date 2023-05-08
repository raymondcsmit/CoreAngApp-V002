using Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityApp.Application.Command
{
    public class CreateProviderCommand : IRequest<ResponseResult>
    {
        public string Name { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string AuthorizationEndpoint { get; set; }
        public string TokenEndpoint { get; set; }
        public string Scopes { get; set; }
        public string State { get; set; }//This is some key which will ensure the callback and other request
        public string RedirectUri { get; set; }
        public string UserinfoEndpoint { get; set; }
    }
}
