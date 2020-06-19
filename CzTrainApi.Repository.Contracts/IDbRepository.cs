using CzTrainApi.Common.BaseTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CzTrainApi.Repository.Contracts
{
    public interface IDbRepository
    {
        Task<IQueryable<T>> GetAll<T>(Expression<Func<T, bool>> expr = null, List<Expression<Func<T, object>>> includes = null) where T : class, IEntity;
        Task<T> Get<T>(Expression<Func<T, bool>> expr, List<Expression<Func<T, object>>> includes = null) where T : class, IEntity;
        Task<T> GetById<T>(long id, List<Expression<Func<T, object>>> includes = null) where T : class, IEntity;
        Task<long> Add<T>(T entity) where T : class, IEntity;
        Task Update<T>(T entity) where T : class, IEntity;
        Task Delete<T>(long id) where T : class, IEntity;
    }
}
