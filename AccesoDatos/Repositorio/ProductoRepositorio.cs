using AccesoDatos.Repositorio;
using AccesoDatos.Repositorio.IRepositorio;
using CueritosChapaChapa.AccesoDatos.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.AccesoDatos.Repositorio
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        private readonly ApplicationDbContext _db;
        public ProductoRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }
        public void actualizar(Producto producto)
        {
            var productoBD = _db.Productos.FirstOrDefault(b => b.Id == producto.Id);
        if(productoBD != null)
            {
                if(producto.ImagenUrl!=null)
                {
                    productoBD.ImagenUrl= producto.ImagenUrl;
                }

                productoBD.NumeroSerie = producto.NumeroSerie;
                productoBD.Descripcion = producto.Descripcion;
                productoBD.Precio= producto.Precio;
                productoBD.Costo= producto.Costo;
                productoBD.ChurrosId= producto.ChurrosId;
                productoBD.PapasId= producto.PapasId;
                productoBD.PadreId= producto.PadreId;
                productoBD.Estado = producto.Estado;
                _db.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> ObtenerTodosDropDownList(string obj)
        {
            if(obj == "Churros")
            {
                return _db.Churros.Where(c => c.Estado == true).Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.id.ToString()
                }) ;
            }
            if(obj =="Papas")
            {
                return _db.Papas.Where(c => c.Estado == true).Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.id.ToString()
                });
            }
            return null;
        }
    }
}
