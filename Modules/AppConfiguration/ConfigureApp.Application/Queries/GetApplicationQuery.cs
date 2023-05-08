using ConfigureApp.Infrastructure;
using Core.Queries;
using Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigureApp.Application.Queries
{
    
    public class GetApplicationQuery : IQuery<ResponseResult>
    {
        public long ApplicationId { get; set; }
    }
    public class GetAllApplicationQuery : IQuery<ResponseResult>
    {
    }
}
