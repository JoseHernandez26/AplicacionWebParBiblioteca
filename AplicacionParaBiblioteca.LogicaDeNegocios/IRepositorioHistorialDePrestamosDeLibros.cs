using AplicacionParaBiblioteca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionParaBiblioteca.BS
{
public interface IRepositorioHistorialDePrestamosDeLibros
    {


        List<HistorialDePrestamosDelLibro> ObtengaLaLista();

        void Agregue(HistorialDePrestamosDelLibro historial);

        List<HistorialDePrestamosDelLibro> ObTengaHistorialPorIdentificacion(string Identificacion);
        HistorialDePrestamosDelLibro ObTengaHistorialPorIdDePrestamo(int IdPrestamo);
    }
}
