using BikersX.DataService.Data;
using BikersX.DataService.IRepository;
using BikersX.Entities.DbSet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikersX.DataService.Repository
{
    public class BillRepository : GenericRepository<Bill>, IBillRepository
    {
        public BillRepository(ApplicationDbContext db, ILogger logger) : base(db, logger)
        {
        }

        public Bill GetBillByID(int id)
        {
            return dbSet.Where(x=>x.Id == id).Include(x => x.BillUpdateHistories).FirstOrDefault();
        }

        public bool UpdateDebit(int id, int amount)
        {
            var data = _db.Bills.FirstOrDefault(x => x.Id == id);
            data.Debit = data.Debit + amount;
            data.Total = data.Credit - data.Debit;
            if(data.Total == 0)
            {
                data.PaymentStatus = Entities.DbSet.Enum.PaymentStatus.Paid;
                data.Status = false;
            }
            return true;
        }
    }
}
