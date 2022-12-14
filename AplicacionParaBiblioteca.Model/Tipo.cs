using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AplicacionParaBiblioteca.Model
{
    public enum Tipo
    {
        [Description("Cientificos")]
        Cientificos,
        [Description("Literatura & Linguistico")]
        LiteraturaYLinguistico,
        [Description("De Viaje")]
        DeViaje,
    
        [Description("Biografías")]
        Biografia,
        [Description("Libro de texto")]
        LibroDeTexto

    }
}
