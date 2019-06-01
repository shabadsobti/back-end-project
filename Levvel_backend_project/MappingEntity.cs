using System;
using System.Linq;
using AutoMapper;
using Levvel_backend_project.Models;

namespace Levvel_backend_project
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            CreateMap<TruckCategory, CategoryResource>()
            //.ForMember(d => d.CategoryId, opt => opt.MapFrom(c => c.CategoryId))
            .ForMember(d => d.CategoryName, opt => opt.MapFrom(c => c.Category.CategoryName));


            CreateMap<CategoryResource, TruckCategory>()
            .ForMember(d => d.CategoryId, opt => opt.Ignore())
            .ForMember(d => d.Category, opt => opt.Ignore())
            .AfterMap((o, c) =>
            {
                c.Category = new Category();
              
                c.Category.CategoryName = o.CategoryName;

            });

            CreateMap<AddTruckResource, Truck>()
            .ForMember(o => o.TruckCategory, opt => opt.MapFrom(x => x.Categories))
            .ForMember(dto => dto.Title, opt => opt.MapFrom(x => x.Title))
            .ForMember(dto => dto.Coordinates, opt => opt.MapFrom(x => x.Coordinates));

            CreateMap<Truck, AddTruckResource>()
                .ForMember(dto => dto.Categories, opt => opt.MapFrom(x => x.TruckCategory))
                .ForMember(dto => dto.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(dto => dto.Coordinates, opt => opt.MapFrom(x => x.Coordinates));



            CreateMap<RegistrationViewModel, AppUser>().ForMember(au => au.UserName, map => map.MapFrom(vm => vm.Email));


            CreateMap<CustomerTrucks, AddTruckResource>()
                .ForMember(d => d.Title, opt => opt.MapFrom(c => c.Truck.Title));

           
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerViewModel, Customer>();
               


        }
    }
}
