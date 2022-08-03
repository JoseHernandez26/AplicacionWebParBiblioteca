using AplicacionParaBiblioteca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionParaBiblioteca.BS
{
    public interface IRepositorioLibros
    {
        List<Libros> ObtengaLaListaDeLibros();

        void AgregueLibros(Libros Libro);

        Libros ObtengaElLibro(int Libro);

        List<Libros> ObTengaLibrosPorNombre(string Nombre);

        List<Libros> ObtengaLaListaDeLibrosNoDisponibles();

        void CambiarEstado(int Id);

        Libros ObtenerPorId(int Id);
    }
}
