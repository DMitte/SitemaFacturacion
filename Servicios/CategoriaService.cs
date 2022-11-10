using Entidades;
using Exepciones;
using Microsoft.EntityFrameworkCore;
using Repositorios;
using Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class CategoriaService : ICategoria
    {
        readonly facturaContext facturaContext = new();

        public async Task<Categorium> CreateCategoria(Categorium categoria)
        {
            Categorium filter = await facturaContext.Categoria.Where(c => c.CatNombre.Contains(categoria.CatNombre)).FirstOrDefaultAsync();
            if (filter == null)
            {
                await facturaContext.Categoria.AddAsync(categoria);
                await facturaContext.SaveChangesAsync();       
                return categoria;
            }
            throw new ResourceRedundantExeption("Esta Categoria ya existe");
        }

        public async Task<bool> DeleteCategoria(int id)
        {
            Categorium filter = await facturaContext.Categoria.Where(c => c.CatCodigo == id).FirstOrDefaultAsync();
            if (filter != null)
            {
                facturaContext.Categoria.Remove(filter);
                await facturaContext.SaveChangesAsync();
                return true;
            }
            throw new ResourceNotFoudExeption("Esta categoria no existe");
        }

        public async Task<List<Categorium>> GetAllCategorias()
        {
            return await facturaContext.Categoria.ToListAsync();
        }

        public async Task<Categorium> GetOneCategoria(int id)
        {
            Categorium filter = await facturaContext.Categoria.Where(c => c.CatCodigo == id).FirstOrDefaultAsync();
            if (filter != null)
            {
                return filter;
            }
            throw new ResourceNotFoudExeption("Esta categoria no existe");
        }

        public async Task<bool> UpdateCategoria(Categorium categoria)
        {
            Categorium filter = await facturaContext.Categoria.Where(c => c.CatCodigo == categoria.CatCodigo).FirstOrDefaultAsync();
            if (filter != null)
            {
                filter.CatCodigo = categoria.CatCodigo;
                filter.CatNombre = categoria.CatNombre;
                filter.CatDescripcion = categoria.CatDescripcion;
                facturaContext.Categoria.Update(filter);
                await facturaContext.SaveChangesAsync();
                return true;
            }
            throw new ResourceNotFoudExeption("Esta categoria no existe");
        }
    }
}
