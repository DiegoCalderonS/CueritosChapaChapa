using Microsoft.AspNetCore.Mvc;
using AccesoDatos.Repositorio.IRepositorio;
using Modelos;
using Utilidades;
namespace CueritosChapaChapa.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PapasController : Controller
    {
        
        private readonly IUnidadTrabajo _unidadTrabajo;

        public PapasController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;   
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Papas papas = new Papas();
            if (id == null)
            {
                //creamos un nuevo registro
                papas.Estado = true;
                return View(papas);

            }
            papas = await _unidadTrabajo.Papas.Obtener(id.GetValueOrDefault());
            if (papas == null)
            {
                return NotFound();
            }
            return View(papas);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Papas papas)
        {
            if (ModelState.IsValid)
            {
                if (papas.id == 0)
                {
                    await _unidadTrabajo.Papas.Agregar(papas);
                    TempData[CC.Exitosa] = "La papas Se Creo Con Exito";
                }
                else
                {
                    _unidadTrabajo.Papas.actualizar(papas);
                    TempData[CC.Exitosa] = "La papas Se Actualizo Con Exito";

                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[CC.Error] = "Error al Grabar la cueritos";
            return View(papas);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var papasDB = await _unidadTrabajo.Papas.Obtener(id);
            if (papasDB == null)
            {
                return Json(new { success = false, message = " Error al borrar el registro en la base de datos " });
            }
            _unidadTrabajo.Papas.Remover(papasDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = " papas eliminada con exito " });
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos= await _unidadTrabajo.Papas.ObtenerTodos();
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
