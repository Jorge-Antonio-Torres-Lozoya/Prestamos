using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios_Prestamos.Shared.Modelos
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El nombre no puede ser vació")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El correo no puede ser vació"), EmailAddress]
        public string? Correo { get; set; }

        [Required(ErrorMessage = "El Teléfono no puede ser vació"), Phone]
        public string? Telefono { get; set; }

        public virtual ICollection<Solicitud_Prestamo>? Solicitudes { get; set; }
    }
}
