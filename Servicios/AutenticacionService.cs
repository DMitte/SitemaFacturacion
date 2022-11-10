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
    public class AutenticacionService : IAutenticacion
    {
        facturaContext factContext = new();
        public async Task<Cliente> Login(string username, string password)
        {
          Cliente user = await factContext.Clientes.Where(c => c.CliCedula.Contains(username)).FirstOrDefaultAsync();
            if(user != null && password == EncryptData.Decrypt(user.CliPassword)) {
                return user;
            }
            return null;
        }

        public Task<bool> Logout()
        {
            throw new NotImplementedException();
        }
    }
}
