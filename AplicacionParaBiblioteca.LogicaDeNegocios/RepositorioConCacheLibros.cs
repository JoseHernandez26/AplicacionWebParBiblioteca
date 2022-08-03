using AplicacionParaBiblioteca.BS;
using AplicacionParaBiblioteca.Model;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionParaBiblioteca.BS
{
    public class RepositorioConCacheLibros : IRepositorioLibros
    {
        private AplicacionParaBiblioteca.DA.DbContexto ElContextoBD;
        public RepositorioConCacheLibros(  AplicacionParaBiblioteca.DA.DbContexto contextoBD)
        {
            ElContextoBD=contextoBD; 
    }
        public void AgregueLibros(Libros Libro)
        {
         
            

            Libro.Estado = Model.Estado.Disponible;
            Libro.ElEstado = "Disponible";
           

            
            ElContextoBD.Libros.Add(Libro);
            ElContextoBD.SaveChanges();
        }

        public Libros ObtenerPorId(int Id)
        {
            Model.Libros resultado;

            resultado = ElContextoBD.Libros.Find(Id);

            return resultado;
        }
        public void CambiarEstado(int Id)
        {
            Model.Libros elLibroAModificar;

            elLibroAModificar = ObtenerPorId(Id);

            
            if (elLibroAModificar.Estado == Estado.Prestado)
            {
                elLibroAModificar.Estado = Estado.Disponible;

                elLibroAModificar.ElEstado = "Disponible";
            }
            else {
                elLibroAModificar.Estado = Estado.Prestado;
                elLibroAModificar.ElEstado = "Prestado";
            }

            ElContextoBD.Libros.Update(elLibroAModificar);
            ElContextoBD.SaveChanges();
        }
        public Libros ObtengaElLibro(int ID)
        {
            Model.Libros resultado = null;
            List<Libros> laLista;

            laLista = ObtengaLaListaDeLibros();

            foreach (Model.Libros item in laLista)
            {
                if (item.Id == ID)
                    resultado = item;
            }

            return resultado;
        }

        public List<Libros> ObtengaLaListaDeLibros()
        {
            var resultado = from c in ElContextoBD.Libros
                            select c;
            return resultado.ToList();

        }

        public List<Libros> ObtengaLaListaDeLibrosNoDisponibles()
        {
            var resultado = from c in ElContextoBD.Libros.Where(x => x.Estado==Estado.Prestado)

                            select c;
            return resultado.ToList();

        }

        public List<Libros> ObTengaLibrosPorNombre(String nombre)
        {
            List<Libros> laLista;
            List<Libros> laListaFiltrada;

            laLista = ObtengaLaListaDeLibros();

            laListaFiltrada = laLista.Where(x => x.Nombre.Contains(nombre)).ToList();
            return laListaFiltrada;
        }

      
      



    }
}

