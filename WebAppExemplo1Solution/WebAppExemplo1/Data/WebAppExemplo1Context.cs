using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppExemplo1.Models;

namespace WebAppExemplo1.Data
{
    public class WebAppExemplo1Context : DbContext
    {
        public WebAppExemplo1Context (DbContextOptions<WebAppExemplo1Context> options)
            : base(options)
        {
        }

        public DbSet<WebAppExemplo1.Models.ProdutoModel> ProdutoModel { get; set; }
    }
}
