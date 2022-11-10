using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces
{
    public interface IAutenticacion
    {
        Task<Cliente> Login(string username, string password);
        Task<bool> Logout();
    }
}
