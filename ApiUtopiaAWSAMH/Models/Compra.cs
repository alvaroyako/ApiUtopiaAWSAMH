using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtopiaAWSAMH.Models
{
    [Table("COMPRA")]
    public class Compra
    {
        [Key]
        [Column("NOMBREJUEGO")]
        public string Nombre { get; set; }

        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }


        [Column("IDCOMPRA")]
        public int IdCompra { get; set; }
    }
}
