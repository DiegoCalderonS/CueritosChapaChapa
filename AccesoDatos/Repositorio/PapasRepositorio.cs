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
    public class PapasRepositorio : Repositorio<Papas>, IPapasRepositorio
    {
        private readonly ApplicationDbContext _db;
        public PapasRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void actualizar(Papas papas)
        {
            var papasBD = _db.Papas.FirstOrDefault(b => b.id == papas.id);
            if (papasBD != null)
            {

                papasBD.Nombre = papas.Nombre;
                papasBD.Descripcion = papas.Descripcion;
                papasBD.Estado = papas.Estado;
                _db.SaveChanges();
            }
        }
    }
}
