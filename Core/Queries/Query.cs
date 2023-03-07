using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Queries
{
    public interface IQuery<TResult> { }
    //public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    //{
    //    TResult Handle(TQuery query);
    //}
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}
