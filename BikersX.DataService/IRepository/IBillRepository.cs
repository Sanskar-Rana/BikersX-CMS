using BikersX.Entities.DbSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikersX.DataService.IRepository
{
    public interface IBillRepository : IGenericRepository<Bill>
    {
        Bill GetBillByID(int id);
        bool UpdateDebit(int id, int amount);
    }
}
