using BikersX.Entities.DbSet.Enum;
using BikersX.Entities.DbSet.Relationship;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikersX.Entities.DTOs.Outgoing
{
    public class BillDetailDTO
    {
        /*public string BillNo { get; set; }
        public int VendorId { get; set; }
        public string Product { get; set; }
        public int Credit { get; set; }
        public int Debit { get; set; }
        public int Total { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string Remark { get; set; }*/
        public ICollection<BillUpdateHistory> BillUpdateHistories { get; set; }
    }
}
