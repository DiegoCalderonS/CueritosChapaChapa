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
    public class ChurrosRepositorio : Repositorio<Churros>, IChurrosRepositorio
    {
        private readonly ApplicationDbContext _db;     
        public ChurrosRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void actualizar(Churros churros)
        {
            var churrosBD= _db.Cueritos.FirstOrDefault(b => b.id == churros.id);
            if (churrosBD != null)
            {

                churrosBD.Nombre = churros.Nombre;
                churrosBD.Descripcion = churros.Descripcion;
                churrosBD.Estado = churros.Estado;
                _db.SaveChanges();
            }
        }
    }
}
