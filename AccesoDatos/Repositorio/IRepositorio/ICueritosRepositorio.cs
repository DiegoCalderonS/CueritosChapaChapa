using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Repositorio.IRepositorio
{
    public interface ICueritosRepositorio : IRepositorio<Cueritos>
    {
        void actualizar(Cueritos cueritos);
    }
}
