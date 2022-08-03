


using AplicacionParaBiblioteca.BS;
using AplicacionParaBiblioteca.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace AplicacioParaBiblioteca.UI.Controllers
{
    public class LibroController : Controller
    {

        static int ContadorId = 0;
        static object lockObj = new object();

        List<int> Lista = new List<int>();

        Libros ElLibroConElIdABuscar = new Libros();
        int ElIdDelLibroADevolver;
        int elIdDelHistorialAGuardar;


        private readonly IRepositorioLibros ElRepositorio;
        private readonly IRepositorioHistorialDePrestamos ElRepositorioH;
        private readonly IRepositorioHistorialDePrestamosDeLibros ElRepositorioHL;
        // GET: LibroController

        HistorialDePrestamosController HistorialDePrestamosController;
        public LibroController(IRepositorioLibros Repositorio, IRepositorioHistorialDePrestamos RepositorioH, IRepositorioHistorialDePrestamosDeLibros repositorioHL)
        {
            ElRepositorio = Repositorio;
            ElRepositorioH = RepositorioH;
            ElRepositorioHL = repositorioHL;


        }



        private Libros GetLibro(int ID)
        {




            Libros resultado = null;
            List<Libros> LaLista;
            LaLista = ElRepositorio.ObtengaLaListaDeLibros();

            foreach (Libros item in LaLista)
            {
                if (item.Id == ID)
                {

                    ElIdDelLibroADevolver = ID;
                    resultado = item;
                }

            }



            return resultado;
        }


        private Libros CambiarEstado(int ID)
        {




            Libros resultado = null;
            List<Libros> LaLista;
            LaLista = ElRepositorio.ObtengaLaListaDeLibros();

            foreach (Libros item in LaLista)
            {
                if (item.Id == ID)
                {


                    resultado = item;
                }

            }



            return resultado;
        }






        private Libros CrearLibro(int ID)
        {




            Libros resultado = null;
            List<Libros> LaLista;
            LaLista = ElRepositorio.ObtengaLaListaDeLibros();

            foreach (Libros item in LaLista)
            {
                if (item.Id == ID)
                {

                    ElIdDelLibroADevolver = ID;
                    resultado = item;
                }

            }


            return resultado;
        }



        public ActionResult Index(string nombre)
        {
            List<Libros> laLista;

            if (nombre is null)
                laLista = ElRepositorio.ObtengaLaListaDeLibros();
            else
                laLista = ElRepositorio.ObTengaLibrosPorNombre(nombre);

            return View(laLista);
        }

        public ActionResult ListaDeLibroNoDisponibles(string Nombre)
        {
            List<Libros> laLista;

            if (Nombre is null)
                laLista = ElRepositorio.ObtengaLaListaDeLibrosNoDisponibles();
            else
                laLista = ElRepositorio.ObTengaLibrosPorNombre(Nombre);

            return View(laLista);
        }

        // GET: LibroController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        public void GenereIdIncrementable()
        {
            lock (lockObj)
            {
                ContadorId++;
            }
        }
        // GET: LibroController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: LibroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Libros Libro)
        {
            try
            {
                Libros elLibro = new Libros();



                elLibro.Nombre = Libro.Nombre;
                elLibro.Descripcion = Libro.Descripcion;
                elLibro.FechaDePublicacion = Libro.FechaDePublicacion;
                elLibro.Tipo = Libro.Tipo;
                ElRepositorio.AgregueLibros(elLibro);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public void ObtenerElID(int ID)
        {

            Libros elLibro;
            elLibro = GetLibro(ID);
            elLibro.Estado = Estado.Prestado;



        }

        // GET: LibroController/Edit/5
        public ActionResult Prestar(int ID)
        {


            List<HistorialDePrestamos> LaLista;
            LaLista = ElRepositorioH.ObtengaLaLista();




            return View(LaLista);
        }

        // POST: LibroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Prestar(int ID, IFormCollection collection)
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
        public ActionResult RegistrarPrestamo(int Id)
        {


            ElRepositorio.CambiarEstado(Id);
            return View();
        }

        // POST: LibroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarPrestamo(HistorialDePrestamos Historial)
        {
            try
            {
                HistorialDePrestamos elHistorialDePrestamos = new HistorialDePrestamos();
                elHistorialDePrestamos.Identificacion = Historial.Identificacion;
                elHistorialDePrestamos.NombreCompleto = Historial.NombreCompleto;
                elHistorialDePrestamos.FechaDeDevolucion = Historial.FechaDeDevolucion;

                ElRepositorioH.Agregue(elHistorialDePrestamos);




                return RedirectToAction(nameof(Prestar));
            }
            catch
            {
                return View();
            }
        }

        public void AgregueHistorialAlLibro(int IDLibro, string Identificacion)
        {

            HistorialDePrestamos elHistorial = new HistorialDePrestamos();
            elHistorial = HistorialDePrestamosController.GetHistorial(Identificacion);


            Libros elLibro = new Libros();
            elLibro = CrearLibro(IDLibro);
            elLibro.Estado = Estado.Disponible;



        }


        // GET: LibroController/Delete/5
        public ActionResult Detalle(int ID)
        {
            try { 
            HistorialDePrestamosDelLibro Historial;
                Libros Libro;
                Libros elLibro=new Libros();
                Libro = ElRepositorio.ObtenerPorId(ID);
                elLibro.Id = ID;
                elLibro.Nombre = Libro.Nombre;
                elLibro.Descripcion = Libro.Descripcion;
                elLibro.FechaDePublicacion = Libro.FechaDePublicacion;
                elLibro.Tipo = Libro.Tipo;
                elLibro.Estado = Libro.Estado;


           Historial = ElRepositorioHL.ObTengaHistorialPorIdDePrestamo(ID);
            List<HistorialDePrestamosDelLibro> laLista;
                HistorialDePrestamosDelLibro elhistorialDePrestamosDelLibro; 

                laLista = ElRepositorioHL.ObTengaHistorialPorIdentificacion(Historial.Identificacion);

                foreach (HistorialDePrestamosDelLibro item in laLista)
                {
                    item.Libros.Id = elLibro.Id;
                    item.Libros.Nombre = elLibro.Nombre;
                    item.Libros.Descripcion = elLibro.Descripcion;
                    item.Libros.FechaDePublicacion=elLibro.FechaDePublicacion;
                    item.Libros.Tipo = elLibro.Tipo;
                    item.Libros.Estado = elLibro.Estado;

                }
                return View(laLista);
            }
            catch{

}
            return View(nameof(InformacionDeNoHistorial));

        }

        // POST: LibroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Detalle(int id, IFormCollection collection)
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



        public void ObtenerelIdDelHistoriaAGuardar(int ID)
        {
            elIdDelHistorialAGuardar = ID;

        }


        public ActionResult Devolver(int Id)
        {



            TempData["ElIdDelLibroADevolver"] = Id;
            TempData["NombreCompleto"] = Id;

            List<HistorialDePrestamos> LaLista;
            LaLista = ElRepositorioH.ObtengaLaLista();



            return View(LaLista);

        }



        // POST: LibroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Devolver()
        {
            try
            {


               




                return RedirectToAction(nameof(Guardar));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Guardar(int Id)
        {
            ElIdDelLibroADevolver = (int)TempData["ElIdDelLibroADevolver"];
            TempData["ElIdDelHistorialAGuardar"] = Id;
            

            
            ElRepositorio.CambiarEstado(ElIdDelLibroADevolver);

            HistorialDePrestamos elHistorial;
            elHistorial = ElRepositorioH.ObTengaHistorialPorIdDePrestamo(Id);



            HistorialDePrestamosDelLibro elHistorialDePrestamos = new HistorialDePrestamosDelLibro();
            elHistorialDePrestamos.Identificacion = elHistorial.Identificacion;
            elHistorialDePrestamos.NombreCompleto = elHistorial.NombreCompleto;
            elHistorialDePrestamos.FechaDeDevolucion = elHistorial.FechaDeDevolucion;
            elHistorialDePrestamos.IdPrestamo = ElIdDelLibroADevolver;
            ElRepositorioHL.Agregue(elHistorialDePrestamos);
            return View();

        }



        // POST: LibroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Guardar(string Identificacion, IFormCollection collection)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InformacionDeNoHistorial(string Identificacion, IFormCollection collection)
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
