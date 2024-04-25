using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorio.IRepositorio
{
    public interface IUnidadTrabajo : IDisposable
    {
        ICueritosRepositorio Cueritos { get; }
        IChurrosRepositorio Churros { get; }
        IPapasRepositorio Papas { get; }
        IProductoRepositorio Producto { get; }
        Task Guardar();
    }
}
