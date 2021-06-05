using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppDilleto.Models
{
    //CARRITO
    [Table("t_proforma")]
    public class Proforma
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int ID {get; set;}

        public String UserID {get; set;}
        [Column("imagenname")]        
        public String ImagenName {get; set;}

        public Productos Producto {get; set;}

        [Display(Name="Cantidad")]
        public int Quantity{get; set;}

        [Display(Name="Precio")]

        public Decimal Price { get; set; }
    }
}