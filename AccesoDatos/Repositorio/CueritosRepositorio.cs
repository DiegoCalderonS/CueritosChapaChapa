using AccesoDatos.Repositorio.IRepositorio;
using CueritosChapaChapa.AccesoDatos.Data;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorio
{
    public class CueritosRepositorio : Repositorio<Cueritos>, ICueritosRepositorio
    {
        private readonly ApplicationDbContext _db;
        public CueritosRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void actualizar(Cueritos cueritos)
        {
            var bodegaBD = _db.Cueritos.FirstOrDefault(b => b.id == cueritos.id);
            if (bodegaBD != null)
            {

                bodegaBD.Nombre = cueritos.Nombre;
                bodegaBD.Descripcion = cueritos.Descripcion;
                bodegaBD.Estado = cueritos.Estado;
                _db.SaveChanges();
            }
        }
    }
}
