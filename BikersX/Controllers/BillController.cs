using AutoMapper;
using BikersX.DataService.IConfiguration;
using BikersX.Entities.DbSet.Generic.Pagination;
using BikersX.Entities.DbSet;
using BikersX.Entities.DTOs.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using BikersX.Entities.DTOs.Outgoing;

namespace BikersX.Controllers
{

    public class BillController : BaseController
    {
        
        public BillController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {
        }

        //Get
        [HttpGet]
        public async Task<IActionResult> GetBills([FromQuery] GenericParameters parameters)
        {
            var data = await _unitOfWork.Bill.GetAll(parameters);
            var metaData = new MetaData
            {
                CurrentPage = data.CurrentPage,
                PageSize = data.PageSize,
                TotalCount = data.TotalCount,
                HasNext = data.HasNext,
                HasPrevious = data.HasPrevious
            };
            Response.Headers.Add("X-Pagniation", JsonConvert.SerializeObject(metaData));
            var result = new Result<Bill>();
            result.data = data;
            return Ok(result);
        }

        //Get
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBillById([FromQuery] int id)
        {
            var data =  _unitOfWork.Bill.GetBillByID(id);
            //var mappedProfile = _mapper.Map<IEnumerable<BillDetailDTO>>(data);
            return Ok(data);
        }

        //Post
        [HttpPost]
        public async Task<IActionResult> AddBill([FromForm] Bill model)
        {
            if (ModelState.IsValid)
            {
                model.Total = model.Credit - model.Debit;
                
                if(model.Total != 0)
                {
                    model.PaymentStatus = Entities.DbSet.Enum.PaymentStatus.UnPaid;
                }
                model.Status = false;
                bool added = await _unitOfWork.Bill.AddEntity(model);
                if (added)
                {

                    await _unitOfWork.CompleteAsync();
                    return Ok("Created Successfully");
                }
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }


        //Post
        [HttpPut]
        public async Task<IActionResult> UpdateDebit( [FromQuery] int id, [FromForm] int debit)
        {
            var data = await _unitOfWork.Bill.GetById(id);
            if(data!= null)
            {
                bool check = _unitOfWork.Bill.UpdateDebit( id, debit);
               
                if (check)
                {
                    var updateData = new UpdateHistory();
                    updateData.Total = data.Total;
                    updateData.Debit = data.Debit;
                    updateData.Credit = data.Credit;
                    updateData.Status = data.Status;
                    updateData.PaymentStatus = data.PaymentStatus;
                    updateData.BillId = data.Id;
                    updateData.VendorId = data.VendorId;
                    bool addUpdate = _unitOfWork.UpdateHistory.CreateUpdateHistory(updateData);
                    await _unitOfWork.CompleteAsync();
                    if (addUpdate)
                    {
                        return Ok("Update Successfully");
                    }
                }
                return new JsonResult("Something went wrong") { StatusCode = 404 };
            }
            return new JsonResult("No Data Found") { StatusCode = 404 };
        }

    }
}
