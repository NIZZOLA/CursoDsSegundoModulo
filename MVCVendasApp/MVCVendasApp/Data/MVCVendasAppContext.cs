using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCVendasApp.Models;

namespace MVCVendasApp.Data
{
    public class MVCVendasAppContext : DbContext
    {
        public MVCVendasAppContext (DbContextOptions<MVCVendasAppContext> options)
            : base(options)
        {
        }

        public DbSet<MVCVendasApp.Models.ClienteModel> ClienteModel { get; set; }

        public DbSet<MVCVendasApp.Models.ProdutoModel> ProdutoModel { get; set; }

        public DbSet<MVCVendasApp.Models.VendaModel> VendaModel { get; set; }

        public DbSet<MVCVendasApp.Models.VendaItensModel> VendaItensModel { get; set; }
    }
}
