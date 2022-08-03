
using AplicacionParaBiblioteca.UI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacioParaBiblioteca.UI.Models;

public class Libros
{
    
    public int Id { get; set; }
    [Required(ErrorMessage = "Favor llenar el campo de nombre ")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "Favor llenar la descripcion ")]
    public string Descripcion { get; set; }

    public Estado Estado { get; set; }
    [Required(ErrorMessage = "Favor seleccionar la fecha ")]
    public DateTime FechaDePublicacion { get; set; }

    [Required(ErrorMessage = "Favor seleccionar el tipo")]
    public Tipo Tipo { get; set; }
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public List<HistorialDePrestamos> HistorialDePrestamos { get; set; }
    [System.ComponentModel.DataAnnotations.Schema.NotMapped]
    public String ElEstado { get; set; }
  
}
