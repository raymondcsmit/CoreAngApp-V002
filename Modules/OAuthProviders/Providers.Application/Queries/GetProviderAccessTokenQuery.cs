using Core.Queries;
using Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Application.Queries
{
    public class GetProviderAccessTokenQuery :  IQuery<ResponseResult>
    {
        public string ProviderName{ get; set; }
        public string Code { get; set; }
        public string State { get; set; }
    }
}
