using Microsoft.AspNetCore.Mvc;
using ListaTareas.Models;

namespace ListaTareas.Controllers
{
    public class TareasController : Controller
    {
            private static List<Tarea> tareas = new List<Tarea>();

            private static int contador = 1;

            public IActionResult Index()
            {
                return View("~/Views/Home/Index.cshtml", tareas);
            }

            [HttpPost]
            public IActionResult Agregar(string descripcion)
            {
                if (string.IsNullOrWhiteSpace(descripcion))
                {
                    ViewBag.Error = "ERROR: Escribe una tarea.";
                    return View("~/Views/Home/Index.cshtml", tareas);
                }

                Tarea nuevaTarea = new Tarea();

                nuevaTarea.Id = contador;
                nuevaTarea.Descripcion = descripcion;
                nuevaTarea.Completada = false;

                tareas.Add(nuevaTarea);

                contador++;

                return RedirectToAction("Index");
            }

                [HttpPost]
                public IActionResult Completar(int id)
                        {
                            foreach (var tarea in tareas)
                            {
                                if (tarea.Id == id)
                                {
                                    tarea.Completada = true;
                                }
                            }

                    return RedirectToAction("Index");
                        }

                [HttpPost]
                public IActionResult Eliminar(int id)
                {
                            for (int i = 0; i < tareas.Count; i++)
                            {
                                if (tareas[i].Id == id)
                                {
                                    tareas.RemoveAt(i);
                                    break;
                                }
                            }

                    return RedirectToAction("Index");
                }
    }
}
