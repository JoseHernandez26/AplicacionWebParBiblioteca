using AplicacionParaBiblioteca.BS;
using AplicacionParaBiblioteca.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AplicacionParaBiblioteca.UI.Controllers
{
    public class HistorialDePrestamosDelLibroController : Controller
    {
        private readonly IRepositorioHistorialDePrestamosDeLibros ElRepositorio;
        // GET: HistorialDePrestamosDelLibroController

        public HistorialDePrestamosDelLibroController(IRepositorioHistorialDePrestamosDeLibros  Repositorio)
        {
            ElRepositorio = Repositorio;
        }
        public ActionResult Index(string Identificacion)
        {
            List<HistorialDePrestamosDelLibro> laLista;

            if (Identificacion is null)
                laLista = ElRepositorio.ObtengaLaLista();
            else
                laLista = ElRepositorio.ObTengaHistorialPorIdentificacion(Identificacion);

            return View(laLista);
        }

        // GET: HistorialDePrestamosDelLibroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HistorialDePrestamosDelLibroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HistorialDePrestamosDelLibroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: HistorialDePrestamosDelLibroController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HistorialDePrestamosDelLibroController/Edit/5
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

        // GET: HistorialDePrestamosDelLibroController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HistorialDePrestamosDelLibroController/Delete/5
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
