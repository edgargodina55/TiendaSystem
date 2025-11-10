
using AutoMapper;
using MasterLoyaltyStore.API.Dtos.User;
using MasterLoyaltyStore.Entities.Models;

namespace MasterLoyaltyStore.Bussiness.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //USER Mappings
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Adress, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.RoleName,opt => opt.MapFrom(src => src.UserType.Description))
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.UserType.UserTypeId));
        //Article Mappings
        //Store Mappings
    }
  
    
}