using AutoMapper;
using DataAccess.Models;
using Entities.Dtos;

namespace BusinessLogic.MapperProfiles
{
    public class ClientMapperProfiler : Profile
    {
        public ClientMapperProfiler()
        {
            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();
        }
    }
}
