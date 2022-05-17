using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtopiaAWSAMH.Models
{
    [Table("PLATOS")]
    public class Plato
    {
        [Key]
        [Column("ID")]
        public int IdPlato { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }

        [Column("DESCRIPCION")]
        public string Descripcion { get; set; }

        [Column("CATEGORIA")]
        public string Categoria { get; set; }

        [Column("PRECIO")]
        public int Precio { get; set; }

        [Column("FOTO")]
        public string Foto { get; set; }

    }
}
