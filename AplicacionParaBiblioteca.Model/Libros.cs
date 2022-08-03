
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacionParaBiblioteca.Model;

public class Libros
{
   
    public int Id { get; set; }


    public string Nombre { get; set; }


    public string Descripcion { get; set; }

    public Estado Estado { get; set; }

    public DateTime FechaDePublicacion { get; set; }
    [NotMapped]
    public String ElEstado { get; set; }
    
    public Tipo Tipo {get; set;}
    [NotMapped]
    public List<HistorialDePrestamos> HistorialDePrestamos { get; set; }

 
    
    
}
