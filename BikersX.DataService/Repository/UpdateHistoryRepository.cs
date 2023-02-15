using BikersX.DataService.Data;
using BikersX.DataService.IRepository;
using BikersX.Entities.DbSet;
using BikersX.Entities.DbSet.Generic.Pagination;
using BikersX.Entities.DbSet.Relationship;
using BikersX.Entities.DTOs.Generic;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikersX.DataService.Repository
{
    public class UpdateHistoryRepository : GenericRepository<UpdateHistory>, IUpdateHistoryRepository
    {
        public UpdateHistoryRepository(ApplicationDbContext db, ILogger logger) : base(db, logger)
        {
        }

        public bool CreateUpdateHistory(UpdateHistory data)
        {
            var billEntity = _db.Bills.Where(x => x.Id == data.BillId).FirstOrDefault();
            var BillUpdateHis = new BillUpdateHistory()
            {
                Bill = billEntity,
                UpdateHistory = data,
               
            };
            _db.Add(BillUpdateHis);
            dbSet.Add(data);
            return true;
        }

        public PagedList<UpdateHistory> GetByBillId(int id, GenericParameters parameters)
        {
            return PagedList<UpdateHistory>.ToPagedList(dbSet.Where(x => x.BillId == id).OrderByDescending(x => x.CreatedAt), parameters.PageNumber, parameters.PageSize);
        }
    }
}
