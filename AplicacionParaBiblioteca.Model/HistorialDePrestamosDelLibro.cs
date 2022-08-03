using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionParaBiblioteca.Model
{
    public class HistorialDePrestamosDelLibro
    {
        public int Id { get; set; }
        public string Identificacion { get; set; }

        public string NombreCompleto { get; set; }

        public DateTime FechaDeDevolucion { get; set; }

        public int IdPrestamo { get; set; }
        [NotMapped]
        public Libros Libros { get; set; }

        public HistorialDePrestamosDelLibro() { 
        Libros = new Libros();
        }

    }
}
