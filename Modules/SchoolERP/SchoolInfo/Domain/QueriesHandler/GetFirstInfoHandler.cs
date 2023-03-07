using Core.Models;
using Core.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolInfo.Module.Data;
using SchoolInfo.Module.Data.ViewModel;
using SchoolInfo.Module.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolInfo.Module.Domain.QueriesHandler
{
    
    //public class GetFirstInfoHandler : IRequestHandler<GetFirstInfo, SchoolInfoVM>
    //{
    //    private readonly SchoolInfoDbContext dbContext;

    //    public GetFirstInfoHandler(SchoolInfoDbContext context)
    //    {
    //        dbContext = context;
    //    }

    //    public async Task<SchoolInfoVM> Handle(GetFirstInfo request, CancellationToken cancellationToken)
    //    {
    //        var product =await dbContext.dbSetSchoolInfoEntities.FirstOrDefaultAsync();//.FirstOrDefault();//.GetById(request.Id);
    //        return product;
    //    }
    //}
    public class QueryRequestHandler<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult> where TResult :BaseEntity
    {
        private readonly SchoolInfoDbContext dbContext;

        public QueryRequestHandler(SchoolInfoDbContext context)
        {
            dbContext = context;
        }
        public async Task<TResult> Handle(TQuery query)
        {
            return await dbContext.Set<TResult>()
                .Where(query.Criteria)
                .FirstOrDefaultAsync();
        }
        //public async Task<TResult> Handle(TQuery query)
        //{
        //    var product = await dbContext.Set<TResult>().Where(query.Criteria);// .dbSetSchoolInfoEntities.FirstOrDefaultAsync();
        //    return product;
        //    // Implementation to handle the query and return a result of type TResult
        //    // You can use the query.Criteria lambda expression to filter the results
        //}
    }
    public class QueryRequestHandler1<TQuery, TResult> : IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
        private readonly DbContext _dbContext;

        public QueryRequestHandler1(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public TResult Handle(TQuery query)
        //{
        //    // Use the query.Criteria lambda expression to filter the results
        //    var queryable = _dbContext.Set<TResult>().Where(query.Criteria);

        //    // Implementation to handle the query and return a result of type TResult
        //    // ...
        //}

        Task<TResult> IQueryHandler<TQuery, TResult>.Handle(TQuery query)
        {
            var queryable = _dbContext.Set<TResult>().Where(query.Criteria);
        }
    }

}
