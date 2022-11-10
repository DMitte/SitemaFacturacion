using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces
{
    public interface ICliente
    {
        /*
        * Crea una Categoria     
        */
        Task<Cliente> CreateClient(Cliente client);

        /*
        * devuelve todas las categorias una Categorias    
        */
        Task<List<Cliente>> GetAllCliente();

        Task<Cliente> GetCliente(Cliente client);

        /*
        * devuelve una Categoria     
        */
        Task<Cliente> GetOneCliente(int id);

        /*
        * actualiza una Categoria     
        */
        Task<bool> UpdateCliente(Cliente client);

        /*
        * elimina una Categoria     
        */
        Task<bool> DeleteCliente(int id);
    }
}
