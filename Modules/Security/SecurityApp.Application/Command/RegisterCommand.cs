using Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityApp.Application.Command
{
    public class RegisterCommand : IRequest<ResponseResult>
    {
        public string UserName { get; set; }
        public string TenantId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
