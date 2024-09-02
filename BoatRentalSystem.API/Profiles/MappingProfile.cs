using AutoMapper;
using BoatRentalSystem.API.ViewModels;
using BoatRentalSystem.Application.City.ViewModels;
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






        }
    }
}
