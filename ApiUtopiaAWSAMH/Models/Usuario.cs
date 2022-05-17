using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiUtopiaAWSAMH.Models
{
    [Table("USUARIOS")]
    public class Usuario
    {
        [Key]
        [Column("IDUSUARIO")]
        public int IdUsuario { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }

        [Column("EMAIL")]
        public string Email { get; set; }

        [Column("PASSWORD")]
        public byte[] Password { get; set; }

        [Column("SALT")]
        public string Salt { get; set; }

        [Column("IMAGEN")]
        public string Imagen { get; set; }

        [Column("ROL")]
        public string Rol { get; set; }

        [NotMapped]
        public string PasswordString { get; set; }
    }
}
