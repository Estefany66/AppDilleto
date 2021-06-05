using System;
using AppDilleto.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDilleto.Models
{
    [Table("t_contactanos")]
    public class Contactanos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("apellidos")]
        public string Apellidos { get; set; }

        [Column("celular")]
        public string Celular { get; set; }

        [Column("email")]
        public string Email { get; set; }

        [Column("mensaje")]
        public string Mensaje { get; set; }
        
         [NotMapped]
        public String Status {get; set;}
    

        
    }
}
