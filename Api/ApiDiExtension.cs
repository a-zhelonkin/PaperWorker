using Api.Mappers;
using Api.Models;
using Api.Models.Account;
using Core;
using Database.Models;
using Database.Models.Account;
using Database.Models.Addressing;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public static class ApiDiExtension
    {
        public static void AddApi(this IServiceCollection services)
        {
            services.AddScoped<IMapper<User, UserDto>, UserDtoMapper>();
            services.AddScoped<IMapper<Profile, ProfileDto>, ProfileDtoMapper>();
            services.AddScoped<IMapper<ProfileDto, Profile>, DtoProfileMapper>();
            services.AddScoped<IMapper<Address, AddressDto>, AddressDtoMapper>();
            services.AddScoped<IMapper<Structure, StructureDto>, StructureDtoMapper>();
            services.AddScoped<IMapper<Street, StreetDto>, StreetDtoMapper>();
            services.AddScoped<IMapper<Locality, LocalityDto>, LocalityDtoMapper>();
            services.AddScoped<IMapper<Territory, TerritoryDto>, TerritoryDtoMapper>();
        }
    }
}