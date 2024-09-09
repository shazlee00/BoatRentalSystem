using AutoMapper;
using BoatRentalSystem.API.ViewModels;
using BoatRentalSystem.Application.Boat.ViewModels;
using BoatRentalSystem.Application.City.ViewModels;
using BoatRentalSystem.Application.Trip.ViewModels;
using BoatRentalSystem.Core.Entities;

namespace BoatRentalSystem.API.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<City, CityViewModel>().ReverseMap();
            CreateMap<City, AddCityViewModel>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<City, AddCityDto>().ReverseMap();

            CreateMap<Country, CountryViewModel>().ReverseMap();
            CreateMap<Country, AddCountryViewModel>().ReverseMap();


            CreateMap<Package, PackageViewModel>().ReverseMap();
            CreateMap<Package, AddPackageViewModel>().ReverseMap();

            CreateMap<Addition, AdditionViewModel>().ReverseMap();
            CreateMap<Addition, AddAdditionViewModel>().ReverseMap();


            CreateMap<Boat, BoatDto>().
                ForMember(dest => dest.BoatStatus, opt => opt.MapFrom(src => src.Status.ToString())).ReverseMap();
            CreateMap<Boat, AddBoatDto>().ReverseMap();
            CreateMap<Boat, UpdateBoatDto>().ReverseMap();




            CreateMap<Trip, TripDto>().
               ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString())).ReverseMap();
            CreateMap<Trip, AddTripDto>().ReverseMap();
            CreateMap<Trip, UpdateTripDto>().ReverseMap();









        }
    }
}
