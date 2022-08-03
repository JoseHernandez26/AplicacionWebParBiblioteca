

using AplicacionParaBiblioteca.BS;
using AplicacionParaBiblioteca.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AplicacioParaBiblioteca.UI.Controllers
{
    public class HistorialDePrestamosController : Controller
    {
        private readonly IRepositorioHistorialDePrestamos ElRepositorio;
        // GET: HistorialDePrestamosController

        public HistorialDePrestamosController(IRepositorioHistorialDePrestamos  Repositorio)
        {
            ElRepositorio = Repositorio;
        }
        public HistorialDePrestamos GetHistorial(String ID)
        {


            HistorialDePrestamos resultado = null;
            List<HistorialDePrestamos> LaLista;
            LaLista = ElRepositorio.ObtengaLaLista();

            foreach (HistorialDePrestamos item in LaLista)
            {
                if (item.Identificacion == ID)
                {

                    resultado = item;
                }

            }
            return resultado;
        }

       
        public ActionResult Index(string Identificacion)

        {


            List<HistorialDePrestamos> laLista;

            if (Identificacion is null)
                laLista = ElRepositorio.ObtengaLaLista();
            else
                laLista = ElRepositorio.ObtengaElHistorial(Identificacion);

            return View(laLista);
        }

        // GET: HistorialDePrestamosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HistorialDePrestamosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistorialDePrestamosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HistorialDePrestamos Historial)
        {
            try
            {
              HistorialDePrestamos elHistorialDePrestamos = new HistorialDePrestamos();
                elHistorialDePrestamos.Identificacion = Historial.Identificacion;
                elHistorialDePrestamos.NombreCompleto = Historial.NombreCompleto;
                elHistorialDePrestamos.FechaDeDevolucion = Historial.FechaDeDevolucion;

                ElRepositorio.Agregue(elHistorialDePrestamos);

             
                return RedirectToAction(nameof(Index));



            }
            catch
            {
                return View();
            }
        }

        // GET: HistorialDePrestamosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HistorialDePrestamosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HistorialDePrestamosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HistorialDePrestamosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
