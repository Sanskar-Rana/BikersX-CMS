using AutoMapper;
using BikersX.Entities.DbSet;
using BikersX.Entities.DTOs.Outgoing;

namespace BikersX.Profiles
{
    public class BillProfile : Profile
    {
        public BillProfile()
        {
            CreateMap<UpdateHistory, BillDetailDTO>()
              // .ForMember(
              //     dest => dest.VendorId,
              //     from => from.MapFrom(x => x.VendorId)
              // )
              // .ForMember(
              //     dest => dest.BillNo,
              //     from => from.MapFrom(x => x.BillId)
              //)
               .ForMember(
                    dest => dest.BillUpdateHistories,
                    from => from.MapFrom(x=>x.BillUpdateHistories)
                );
        }
    }
}
