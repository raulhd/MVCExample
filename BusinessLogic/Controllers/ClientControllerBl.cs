using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessLogic.Controllers.Interfaces;
using DataAccess.Context;
using DataAccess.Models;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Controllers
{
    public class ClientControllerBl : IClientControllerBl
    {
        public ClientControllerBl(IContext context,
                                    IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public IContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public async Task<ClientDto> Create(ClientDto dto)
        {
            if (dto == null)
                throw new ArgumentNullException("dto");

            var client = Mapper.Map<Client>(dto);
            var result = Context.Clients.Add(client);

            await Context.SaveChangesAsync();
            return Mapper.Map<ClientDto>(client);
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var client = await Context.Clients.FindAsync(id);
                Context.Clients.Remove(client);
                await Context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public async Task<IList<ClientDto>> GetAll()
        {
            return await Context.Clients
                            .AsNoTracking()
                            .ProjectTo<ClientDto>(Mapper.ConfigurationProvider)
                            .ToListAsync();
        }

        public async Task<ClientDto> GetById(int id)
        {
            var client = await Context.Clients
                            .AsNoTracking()
                            .FirstOrDefaultAsync(m => m.Id == id);

            return Mapper.Map<ClientDto>(client);
        }

        public async Task<ClientDto> Update(ClientDto dto, int id)
        {
            if (dto == null)
                throw new ArgumentNullException("dto");

            var client = Mapper.Map<Client>(dto);
            var result = Context.Clients.Update(client);

            await Context.SaveChangesAsync();
            return Mapper.Map<ClientDto>(client);
        }
    }
}
