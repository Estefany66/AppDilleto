using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AppDilleto.Models;
using AppDilleto.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace AppDilleto.Controllers
{
    public class AccesoriosController : Controller
    {
        
        private readonly ILogger<CatalogoController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public AccesoriosController(ILogger<CatalogoController> logger,
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager)
        {
            _context = context;
            _logger = logger;
            _userManager = userManager;
        }

        
        public async Task<IActionResult> Index()
        {
            var productos = from o in _context.DataProd select o;
            productos = productos.Where(s => s.Status.Equals("A"));
            return View(await productos.ToListAsync());
        }

        public async Task<IActionResult> Add(int? id)
        {
            var userID = _userManager.GetUserName(User);
            if(userID == null){
                ViewData["Message"] = "Por favor debe loguearse antes de agregar un producto";
                List<Productos> productos = new List<Productos>();
                return  View("Index",productos);
            }else{
                var producto = await _context.DataProductos.FindAsync(id);
                Proforma proforma1 = new Proforma();
                proforma1.Producto = producto;
                proforma1.Price = producto.Price;
                proforma1.Quantity = 1;
                proforma1.UserID = userID;
                _context.Add(proforma1);
                await _context.SaveChangesAsync();
                return  RedirectToAction(nameof(Index));
            }

        }        

    }
}