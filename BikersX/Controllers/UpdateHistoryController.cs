using AutoMapper;
using BikersX.DataService.IConfiguration;
using BikersX.Entities.DbSet.Generic.Pagination;
using BikersX.Entities.DbSet;
using BikersX.Entities.DTOs.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BikersX.Controllers
{

    public class UpdateHistoryController : BaseController
    {
        public UpdateHistoryController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }


        //Get
        [HttpGet]
        public async Task<IActionResult> GetUpdateHistories([FromQuery] GenericParameters parameters)
        {
            var data = await _unitOfWork.UpdateHistory.GetAll(parameters);
            var metaData = new MetaData
            {
                CurrentPage = data.CurrentPage,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                HasNext = data.HasNext,
                HasPrevious = data.HasPrevious
            };
            Response.Headers.Add("X-Pagniation", JsonConvert.SerializeObject(metaData));
            var result = new Result<UpdateHistory>();
            result.data = data;
            return Ok(result);
        }


        //Get
        [HttpGet("[action]")]
        public  IActionResult GetUpdateHistoryByBillId([FromQuery] int id, [FromQuery] GenericParameters parameters)
        {
            var data =  _unitOfWork.UpdateHistory.GetByBillId(id, parameters);
            var metaData = new MetaData
            {
                CurrentPage = data.CurrentPage,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                HasNext = data.HasNext,
                HasPrevious = data.HasPrevious
            };
            Response.Headers.Add("X-Pagniation", JsonConvert.SerializeObject(metaData));
            var result = new Result<UpdateHistory>();
            result.data = data;
            return Ok(result);
        }
    }
}
