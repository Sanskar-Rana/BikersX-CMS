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
    public class VendorRepository : GenericRepository<Vendor>, IVendorRepository
    {
        public VendorRepository(ApplicationDbContext db, ILogger logger) : base(db, logger)
        {
        }
    }
}
