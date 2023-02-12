using BikersX.Entities.DTOs.Errors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikersX.Entities.DTOs.Generic
{
    public class Result<T>
    {
        public IEnumerable<T> data { get; set; }
        public Error Error { get; set; }
        public bool IsSuccess => Error == null;
        public DateTime ResponseTime { get; set; }
        public MetaData metaData { get; set; }
    }
}
