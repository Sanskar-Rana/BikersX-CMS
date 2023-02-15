using AutoMapper;
using BikersX.DataService.IConfiguration;
using BikersX.Entities.DbSet;
using BikersX.Entities.DbSet.Generic.Pagination;
using BikersX.Entities.DTOs.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BikersX.Controllers
{
    public class VendorController : BaseController
    {
        public VendorController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        //Get
        [HttpGet]
        public async Task<IActionResult> GetVendors([FromQuery] GenericParameters parameters)
        {
            var data = await _unitOfWork.Vendor.GetAll(parameters);
            var metaData = new MetaData
            {
                CurrentPage = data.CurrentPage,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                HasNext = data.HasNext,
                HasPrevious = data.HasPrevious
            };
            Response.Headers.Add("X-Pagniation", JsonConvert.SerializeObject(metaData));
            var result = new Result<Vendor>();
            result.data = data;
            return Ok(result);
        }

        //Get
        [HttpPost]
        public async Task<IActionResult> AddVendor([FromForm] Vendor model)
        {
            if (ModelState.IsValid)
            {
               bool added = await _unitOfWork.Vendor.AddEntity(model);
                if (added)
                {

                    await _unitOfWork.CompleteAsync();
                    return Ok("Created Successfully");
                }
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetVendorByGuid([FromQuery] int id)
        {
            var data = _unitOfWork.Vendor.GetById(id);
            if (data == null)
                return NotFound("No record inserted with the giving code");
            return Ok(data);
        }
    }
}
