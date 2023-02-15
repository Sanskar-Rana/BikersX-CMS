using BikersX.DataService.Data;
using BikersX.DataService.IRepository;
using BikersX.Entities.DbSet.Generic.Pagination;
using BikersX.Entities.DTOs.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikersX.DataService.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _db;
        internal DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(ApplicationDbContext db,  ILogger logger)
        {
            _db = db;
            dbSet = db.Set<T>();
            _logger = logger;
        }

        public async Task<PagedList<T>> GetAll(GenericParameters parameters)
        {
            var allEntities = await dbSet.ToListAsync();
            return PagedList<T>.ToPagedList(dbSet, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<bool> AddEntity(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public async Task<bool> Delete(T entity)
        {
             dbSet.Remove(entity);
            return true;
        }

        public Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
