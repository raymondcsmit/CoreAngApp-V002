using Core.Queries;
using MediatR;
using SchoolInfo.Module.Data.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolInfo.Module.Domain.Queries
{
    //public class GetFirstInfo : IRequest<SchoolInfoVM>
    //{  
    //    public GetFirstInfo()
    //    {
    //    }
    //}
    public class QueryRequest<TResult> : IQuery<TResult>
    {
        public Expression<Func<TResult, bool>> Criteria { get; set; }
    }
}
