using CzTrainApi.Common.BaseTypes;
using CzTrainApi.Common.Exceptions;
using CzTrainApi.Db;
using CzTrainApi.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CzTrainApi.Repository
{
    public class DbRepository : IDbRepository
    {
        private readonly DatenbankContext _datenbankContext;

        public DbRepository(DatenbankContext datenbankContext)
        {
            _datenbankContext = datenbankContext;
        }

        public async Task<long> Add<T>(T entity) where T : class, IEntity
        {
            _datenbankContext.Set<T>().Add(entity);
            await _datenbankContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task Delete<T>(long id) where T : class, IEntity
        {
            var entity = await _datenbankContext.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new IdNotFoundException<T>(id);
            }

            entity.Geloescht = true;

            await Update<T>(entity);
        }

        public Task<T> Get<T>(Expression<Func<T, bool>> expr, List<Expression<Func<T, object>>> includes = null) where T : class, IEntity
        {
            if (includes == null)
            {
                return _datenbankContext.Set<T>().SingleOrDefaultAsync(expr);
            }
            else
            {
                return Include(includes).SingleOrDefaultAsync(expr);
            }
        }

         public Task<IQueryable<T>> GetAll<T>(Expression<Func<T, bool>> expr = null, List<Expression<Func<T, object>>> includes = null) where T : class, IEntity
        {
            if (expr == null)
            {
                if (includes == null)
                {
                    return Task.FromResult(_datenbankContext.Set<T>().AsQueryable());
                }
                else
                {
                    return Task.FromResult(Include(includes));
                }
            }
            else
            {
                if (includes == null)
                {
                    return Task.FromResult(_datenbankContext.Set<T>().Where(expr).AsQueryable());
                }
                else
                {
                    return Task.FromResult(Include(includes).Where(expr));
                }
            }
        }

        public Task<T> GetById<T>(long id, List<Expression<Func<T, object>>> includes = null) where T : class, IEntity
        {
            if (includes == null)
            {
                return _datenbankContext.Set<T>().FindAsync(id).AsTask();
            }
            else
            {
                return Include(includes).FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        public async Task Update<T>(T entity) where T : class, IEntity
        {
            entity.Aenderungsdatum = DateTime.Now;
            _datenbankContext.Entry(entity).State = EntityState.Modified;
            await _datenbankContext.SaveChangesAsync();
        }

        private IQueryable<T> Include<T>(List<Expression<Func<T, object>>> includes) where T : class, IEntity
        {
            return includes.Aggregate(_datenbankContext.Set<T>().AsQueryable(), (current, include) => current.Include(include));
        }
    }
}
