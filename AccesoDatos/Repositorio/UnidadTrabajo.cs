using AccesoDatos.Repositorio.IRepositorio;
using CueritosChapaChapa.AccesoDatos.Data;
using SistemaInventario.AccesoDatos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public ICueritosRepositorio Cueritos { get; set; }
        public IChurrosRepositorio Churros { get; set; }
        public IPapasRepositorio Papas { get; set; }

        public IProductoRepositorio Producto { get; set; }
        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Cueritos = new CueritosRepositorio(_db);
            Churros = new ChurrosRepositorio(_db);
            Papas = new PapasRepositorio(_db);
            Producto = new ProductoRepositorio(_db);
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}
