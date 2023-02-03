using AutoMapper;
using CapstoneProject_DTOLayer.DTOs.ContactDTOs;
using CapstoneProject_EntityLayer.Concrete;

namespace CapstoneProject.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
    
        //Mapleme işlemi: DTO ile entityleri bağlamak için kullanılır.
        //Registeration: İnterface ile sınıfları birbirine bağlama işlemi 

        public MapProfile()
        {
            CreateMap<ContactAddDto, Contact3>();
            CreateMap<Contact3, ContactAddDto >();

            CreateMap<ContactListDto, Contact3>();
            CreateMap<Contact3, ContactListDto>();

            CreateMap<ContactUpdateDTO, Contact3>();
            CreateMap<Contact3, ContactUpdateDTO>();

          

        } 
    }
}
