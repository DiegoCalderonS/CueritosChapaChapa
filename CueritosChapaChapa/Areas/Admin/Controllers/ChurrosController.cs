using Microsoft.AspNetCore.Mvc;
using AccesoDatos.Repositorio.IRepositorio;
using Modelos;
using Utilidades;
namespace CueritosChapaChapa.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ChurrosController : Controller
    {
        
        private readonly IUnidadTrabajo _unidadTrabajo;

        public ChurrosController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;   
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Churros churros = new Churros();
            if (id == null)
            {
                //creamos un nuevo registro
                churros.Estado = true;
                return View(churros);

            }
            churros = await _unidadTrabajo.Churros.Obtener(id.GetValueOrDefault());
            if (churros == null)
            {
                return NotFound();
            }
            return View(churros);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Churros churros)
        {
            if (ModelState.IsValid)
            {
                if (churros.id == 0)
                {
                    await _unidadTrabajo.Churros.Agregar(churros);
                    TempData[CC.Exitosa] = "Los churros Se Creo Con Exito";
                }
                else
                {
                    _unidadTrabajo.Churros.actualizar(churros);
                    TempData[CC.Exitosa] = "Los churros Se Actualizo Con Exito";

                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[CC.Error] = "Error al Grabar la churros";
            return View(churros);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var churrosBD = await _unidadTrabajo.Churros.Obtener(id);
            if (churrosBD == null)
            {
                return Json(new { success = false, message = " Error al borrar el registro en la base de datos " });
            }
            _unidadTrabajo.Churros.Remover(churrosBD);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Churros eliminada con exito " });
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos= await _unidadTrabajo.Churros.ObtenerTodos();
            return Json(new { data = todos});

        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Churros.ObtenerTodos();

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
