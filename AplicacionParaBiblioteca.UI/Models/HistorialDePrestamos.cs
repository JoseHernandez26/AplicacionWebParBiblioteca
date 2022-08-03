using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacioParaBiblioteca.UI.Models
{
    public class HistorialDePrestamos
    {
        public string Identificacion { get; set; }

        public string NombreCompleto { get; set; }

        public DateTime FechaDeDevolucion { get; set; }

        public int IdPrestamo { get; set; }

    }
}
