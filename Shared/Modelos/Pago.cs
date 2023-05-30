using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios_Prestamos.Shared.Modelos
{
    public class Pago
    {
        public int PagoId { get; set; }

        [Required(ErrorMessage = "El monto no puede ser  vació")]
        public int Monto_Pago { get; set; }

        [Required(ErrorMessage = "La fecha de pago no puede ser  vació")]
        public DateTime Fecha_Pago { get; set; }

        [Required(ErrorMessage = "La solicitud no puede ser  vació")]
        public int SolicitudId { get; set; }
        public virtual Solicitud_Prestamo? Solicitud_Prestamo { get; set; }
    }
}
