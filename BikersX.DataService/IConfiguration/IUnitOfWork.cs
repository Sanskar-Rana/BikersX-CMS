using BikersX.DataService.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikersX.DataService.IConfiguration
{
    public interface IUnitOfWork
    {
        IVendorRepository Vendor { get; }
        Task CompleteAsync();
    }
}
