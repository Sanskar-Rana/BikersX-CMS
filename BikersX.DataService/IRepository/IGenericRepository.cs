using BikersX.Entities.DbSet.Generic.Pagination;
using BikersX.Entities.DTOs.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BikersX.DataService.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        //Get All entities
        Task<PagedList<T>> GetAll(GenericParameters parameters);

        //Get specifice entity based on Id
        Task<T> GetById(Guid id);
        Task<bool> AddEntity(T entity);
        Task<bool> Delete(T entity);

        //Update Entity or Add if doesnot exist
        Task<bool> Upsert(T entity);
    }
}
