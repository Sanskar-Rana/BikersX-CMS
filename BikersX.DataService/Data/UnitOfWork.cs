using BikersX.DataService.IConfiguration;
using BikersX.DataService.IRepository;
using BikersX.DataService.Repository;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikersX.DataService.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger _logger;

        public UnitOfWork(ApplicationDbContext db, ILoggerFactory loggerFactory)
        {
            _db = db;
            _logger = loggerFactory.CreateLogger("db_logs"); ;
            Vendor = new VendorRepository(_db,_logger);
            Bill = new BillRepository(_db,_logger);
            UpdateHistory = new UpdateHistoryRepository(_db,_logger);
        }

        public IVendorRepository Vendor { get; set; }

        public IBillRepository Bill { get; set; }

        public IUpdateHistoryRepository UpdateHistory { get; set; }

        public async Task CompleteAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
