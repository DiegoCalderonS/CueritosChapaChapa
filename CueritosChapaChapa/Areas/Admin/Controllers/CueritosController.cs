using Microsoft.AspNetCore.Mvc;
using AccesoDatos.Repositorio.IRepositorio;
using Modelos;
using Utilidades;
namespace CueritosChapaChapa.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CueritosController : Controller
    {
        
        private readonly IUnidadTrabajo _unidadTrabajo;

        public CueritosController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;   
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Cueritos cueritos = new Cueritos();
            if (id == null)
            {
                //creamos un nuevo registro
                cueritos.Estado = true;
                return View(cueritos);

            }
            cueritos = await _unidadTrabajo.Cueritos.Obtener(id.GetValueOrDefault());
            if (cueritos == null)
            {
                return NotFound();
            }
            return View(cueritos);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Cueritos cueritos)
        {
            if (ModelState.IsValid)
            {
                if (cueritos.id == 0)
                {
                    await _unidadTrabajo.Cueritos.Agregar(cueritos);
                    TempData[CC.Exitosa] = "La Cueritos Se Creo Con Exito";
                }
                else
                {
                    _unidadTrabajo.Cueritos.actualizar(cueritos);
                    TempData[CC.Exitosa] = "La Cueritos Se Actualizo Con Exito";

                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[CC.Error] = "Error al Grabar la cueritos";
            return View(cueritos);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var cueritosDB = await _unidadTrabajo.Cueritos.Obtener(id);
            if (cueritosDB == null)
            {
                return Json(new { success = false, message = " Error al borrar el registro en la base de datos " });
            }
            _unidadTrabajo.Cueritos.Remover(cueritosDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = " cueritos eliminada con exito " });
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos= await _unidadTrabajo.Cueritos.ObtenerTodos();
            return Json(new { data = todos});

        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Cueritos.ObtenerTodos();

            if (id == 0)
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim()
                        == nombre.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim()
                        == nombre.ToLower().Trim() && b.id != id);
            }
            if (valor)
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });
        }

        #endregion

    }
}
