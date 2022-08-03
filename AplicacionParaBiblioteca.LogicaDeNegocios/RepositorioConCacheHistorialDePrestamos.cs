using AplicacionParaBiblioteca.Model;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionParaBiblioteca.BS
{


    public class RepositorioConCacheHistorialDePrestamos : IRepositorioHistorialDePrestamos
    {
        private AplicacionParaBiblioteca.DA.DbContexto ElContextoBD;
      
       

        public RepositorioConCacheHistorialDePrestamos(AplicacionParaBiblioteca.DA.DbContexto contextoBD)
        {

            ElContextoBD = contextoBD;

        }

        public HistorialDePrestamos ObTengaHistorialPorIdDePrestamo(int IdPrestamo)
        {
            Model.HistorialDePrestamos resultado = null;
            List<HistorialDePrestamos> laLista;

            laLista = ObtengaLaLista();

            foreach (Model.HistorialDePrestamos item in laLista)
            {
                if (item.Id == IdPrestamo)
                    resultado = item;
            }

            return resultado;
        }
        public void Agregue(HistorialDePrestamos historialDePrestamos)
        {
           



            ElContextoBD.HistorialDePrestamos.Add(historialDePrestamos);
            ElContextoBD.SaveChanges();
        }

        public List<HistorialDePrestamos> ObtengaElHistorial(string Identificacion)
        {
            List<HistorialDePrestamos> laLista;
            List<HistorialDePrestamos> laListaFiltrada;

            laLista = ObtengaLaLista();

            laListaFiltrada = laLista.Where(x => x.Identificacion.Contains(Identificacion)).ToList();
            return laListaFiltrada;
        
        }


        public List<HistorialDePrestamos> ObtengaLaLista()
        {
            var resultado = from c in ElContextoBD.HistorialDePrestamos
                            select c;
            return resultado.ToList();

        }
    }
}
