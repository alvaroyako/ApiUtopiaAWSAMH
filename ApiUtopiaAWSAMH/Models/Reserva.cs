using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtopiaAWSAMH.Models
{
    [Table("RESERVAS")]
    public class Reserva
    {
        [Key]
        [Column("NOMBRE")]
        public string Nombre { get; set; }

        [Column("TELEFONO")]
        public string Telefono { get; set; }

        [Column("EMAIL")]
        public string Email { get; set; }

        [Column("PERSONAS")]
        public int Personas { get; set; }

        [Column("FECHA")]
        public string Fecha { get; set; }

        [Column("HORA")]
        public string Hora { get; set; }
    }
}
