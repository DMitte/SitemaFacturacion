using Entidades;
using Exepciones;
using Microsoft.EntityFrameworkCore;
using Repositorios;
using ServerAnime.Model.Utils;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    

    public class ClienteService : ICliente
    {
        readonly facturaContext facturaContext = new();

        public async Task<Cliente> CreateClient(Cliente client)
        {
            Cliente filter = await facturaContext.Clientes.Where(c => c.CliCedula.Contains(client.CliCedula)).FirstOrDefaultAsync();
            if (filter == null)
            {
                client.CliPassword = EncryptData.Encrypt(client.CliPassword);
                await facturaContext.Clientes.AddAsync(client);
                await facturaContext.SaveChangesAsync();
                return client;
            }
            throw new ResourceRedundantExeption("Este Cliente ya existe");
        }

        public Task<bool> DeleteCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Cliente>> GetAllCliente()
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> GetCliente(Cliente client)
        {
            throw new NotImplementedException();
        }

        public Task<Cliente> GetOneCliente(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCliente(Cliente client)
        {
            throw new NotImplementedException();
        }
    }
}
