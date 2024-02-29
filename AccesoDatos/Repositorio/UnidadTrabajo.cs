using AccesoDatos.Repositorio.IRepositorio;
using CueritosChapaChapa.AccesoDatos.Data;
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

       
        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Cueritos = new CueritosRepositorio(_db);
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
