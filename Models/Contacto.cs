using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AgendaContactos.Models
{
    public class Contacto
    {
       
            [Key]
            public int IdPersona { get; set; }

            [DisplayName("Nombre de Contacto")]
            [Required(ErrorMessage = "El campo Nombre es obligatorio")]
            public string Nombre { get; set; }

            [DisplayName("Numero de Telefono")]
            public string? Telefono { get; set; }

            [DisplayName("Domicilio")]
            public string? Direccion { get; set; }

            [DisplayName("Correo Electronico")]
            [DataType(DataType.EmailAddress)]
            public string? Email { get; set; }

            [DisplayName("Fecha de nacimiento")]
            [DataType(DataType.Date)]
            public DateOnly? Tipo { get; set; }

    }
}

