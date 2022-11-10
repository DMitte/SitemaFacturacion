using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Interfaces
{
    public interface ICategoria
    {
        /*
         * Crea una Categoria     
         */
        Task<Categorium> CreateCategoria(Categorium categoria);

        /*
        * devuelve todas las categorias una Categorias    
        */
        Task<List<Categorium>> GetAllCategorias();

        /*
        * devuelve una Categoria     
        */
        Task<Categorium> GetOneCategoria(int id);

        /*
        * actualiza una Categoria     
        */
        Task<bool> UpdateCategoria(Categorium categoria);

        /*
        * elimina una Categoria     
        */
        Task<bool> DeleteCategoria(int id);
    }
}
