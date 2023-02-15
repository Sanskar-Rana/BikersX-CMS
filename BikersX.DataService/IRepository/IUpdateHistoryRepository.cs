using BikersX.Entities.DbSet;
using BikersX.Entities.DbSet.Generic.Pagination;
using BikersX.Entities.DTOs.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikersX.DataService.IRepository
{
    public interface IUpdateHistoryRepository : IGenericRepository<UpdateHistory>
    {
        bool CreateUpdateHistory(UpdateHistory data);
        PagedList<UpdateHistory> GetByBillId(int id,GenericParameters parameters);
    }
}
