using Core.Queries;
using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Providers.Application.Queries
{
    public class GetProviderQuery : IQuery<ResponseResult>
    {
        public string ProviderName{ get; set; }
    }
}
