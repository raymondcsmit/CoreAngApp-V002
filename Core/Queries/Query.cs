using Core.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Queries
{
    //public interface IQuery<out TResponse>
    //{
    //}

    public interface IQuery : IQuery<ResponseResult>
    {
    }
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
    //public interface IQueryHandler<in TQuery, TResponse>
    //    where TQuery : IQuery<TResponse>
    //{
    //    Task<TResponse> Handle(TQuery query);
    //}

    //public interface IQueryHandler<in TQuery> : IQueryHandler<TQuery, ResponseResult>
    //    where TQuery : IQuery<ResponseResult>
    //{
    //}
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    {
    }

    public interface IQueryHandler<in TQuery> : IRequestHandler<TQuery, ResponseResult>
        where TQuery : IQuery<ResponseResult>
    {
    }


    /*
      public interface IQuery : IRequest<ResponseResult>
    {
    }

    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }

    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
        where TQuery : IRequest<TResponse>
    {
    }

    public interface IQueryHandler<TQuery> : IRequestHandler<TQuery, ResponseResult>
        where TQuery : IRequest<ResponseResult>
    {
    }
     */
    //public interface IQuery<TResult> { }

    //public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    //{
    //    //Task<TResult> Handle(TQuery query);
    //}
}
