using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDilleto.Models
{
    [Table("t_accesorios")]
    public class Prod
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID {get; set;}

        [Required(ErrorMessage = "Por favor ingrese nombre del Accesorio")]

        [Display(Name="Nombre")]
        public String Name {get; set;}

        [Required(ErrorMessage = "Porfavor ingrese el precio")]
        [Display(Name="Precio")]
        public Decimal Price { get; set; }

        [Required(ErrorMessage = "Porfavor ingrese la imagen")]
        [Display(Name="Imagen del Accesorio")]
        public String ImagenName { get; set; }

        [Required(ErrorMessage = "Please enter Status")]
        public String Status { get; set; }

        public virtual ICollection<Proforma> ProformaItems { get; set; }

    }
}