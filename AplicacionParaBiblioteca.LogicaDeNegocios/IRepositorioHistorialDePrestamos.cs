using AplicacionParaBiblioteca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionParaBiblioteca.BS
{
    public interface IRepositorioHistorialDePrestamos
    {




       
        List<HistorialDePrestamos> ObtengaLaLista();

        void Agregue(HistorialDePrestamos historial);

        List<HistorialDePrestamos> ObtengaElHistorial(string Identificacion);

        HistorialDePrestamos ObTengaHistorialPorIdDePrestamo(int IdPrestamo);


    }
}
