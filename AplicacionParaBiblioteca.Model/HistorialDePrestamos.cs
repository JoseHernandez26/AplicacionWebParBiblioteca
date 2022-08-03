using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionParaBiblioteca.Model
{
    public class HistorialDePrestamos
    { 
        public int Id { get; set; }
        public string Identificacion { get; set; }

        public string NombreCompleto { get; set; }

        public DateTime FechaDeDevolucion { get; set; }

        public int IdPrestamo { get; set; }


    }
}
