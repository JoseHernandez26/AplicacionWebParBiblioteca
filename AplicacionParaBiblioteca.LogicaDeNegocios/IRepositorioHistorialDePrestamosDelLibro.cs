using AplicacionParaBiblioteca.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionParaBiblioteca.BS
{
    public class IRepositorioHistorialDePrestamosDelLibro : IRepositorioHistorialDePrestamosDeLibros
    {
        private AplicacionParaBiblioteca.DA.DbContexto ElContextoBD;



        public IRepositorioHistorialDePrestamosDelLibro(AplicacionParaBiblioteca.DA.DbContexto contextoBD)
        {

            ElContextoBD = contextoBD;

        }
        public void Agregue(HistorialDePrestamosDelLibro historialDePrestamos)
        {




            ElContextoBD.HistorialDePrestamosDelLibro.Add(historialDePrestamos);
            ElContextoBD.SaveChanges();
        }

    

        public HistorialDePrestamosDelLibro ObTengaHistorialPorIdDePrestamo(int IdPrestamo)
        {
            Model.HistorialDePrestamosDelLibro resultado = null;
            List<HistorialDePrestamosDelLibro> laLista;

            laLista = ObtengaLaLista();

            foreach (Model.HistorialDePrestamosDelLibro item in laLista)
            {
                if (item.IdPrestamo == IdPrestamo)
                    resultado = item;
            }

            return resultado;
        }

        public List<HistorialDePrestamosDelLibro> ObTengaHistorialPorIdentificacion(String identificacion)
        {
            List<HistorialDePrestamosDelLibro> laLista;
            List<HistorialDePrestamosDelLibro> laListaFiltrada;

            laLista = ObtengaLaLista();

            laListaFiltrada = laLista.Where(x => x.Identificacion.Contains(identificacion)).ToList();
            return laListaFiltrada;
        }


        public List<HistorialDePrestamosDelLibro> ObtengaLaLista()
        {
            var resultado = from c in ElContextoBD.HistorialDePrestamosDelLibro
                            select c;
            return resultado.ToList();

        }
    }
}
