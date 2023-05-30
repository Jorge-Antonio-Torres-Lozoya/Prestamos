using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios_Prestamos.Shared.Modelos
{
    public class Solicitud_Prestamo
    {
        [Key]
        public int SolicitudId { get; set; }

        [Required(ErrorMessage = "El monto no puede ser  vació")]
        public int Monto_Prestamo { get; set; }

        [Required(ErrorMessage = "La Fecha no puede ser vacia no puede ser vació")]
        public DateTime Fecha_Solicitud { get; set; }

        [Required(ErrorMessage = "El estado  no puede ser vacia no puede ser vació")]
        public bool Estado_Solicitud { get; set; }

        [Required(ErrorMessage = "La tasa de interes no puede ser  vació")]
        public int Tasa_Interes { get; set; }

        [Required(ErrorMessage = "El plazo no puede ser  vació")]
        public int Plazo_meses { get; set; }

        [Required(ErrorMessage = "El cliente no puede ser vacia no puede ser vació")]
        public int UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }

        public virtual ICollection<Pago>? Pagos { get; set; }
    }
}
