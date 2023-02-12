using BikersX.Entities.DbSet.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikersX.Entities.DbSet
{
    public class Vendor : BaseEntity
    {
        public string VendorName { get; set; }
        public string OwnerName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string? PhoneNumber2 { get; set; }
        public string Description { get; set; }
    }
}
