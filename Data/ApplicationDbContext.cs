using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppDilleto.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AppDilleto.Models.Contactanos> DataContactanos { get; set; }
        public DbSet<AppDilleto.Models.Proforma> DataCarrito { get; set; }
        public DbSet<AppDilleto.Models.Productos> DataProductos { get; set; }
        public DbSet<AppDilleto.Models.Pedido> DataPedidos { get; set; }
        public DbSet<AppDilleto.Models.Prod> DataProd { get; set; }
        public DbSet<AppDilleto.Models.Proforma1> DataCarrito1 { get; set; }

    }
}
