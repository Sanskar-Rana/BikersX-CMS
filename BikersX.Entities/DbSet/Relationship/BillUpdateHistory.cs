using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikersX.Entities.DbSet.Relationship
{
    public class BillUpdateHistory
    {
        public int BillId { get; set; }
        [ValidateNever]
        [ForeignKey("BillId")]
        public Bill Bill { get; set; }
        public int UpdateHistoryId { get; set; }
        [ValidateNever]
        [ForeignKey("UpdaeHistoryId")]
        public UpdateHistory UpdateHistory { get; set; }
    }
}
