using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiStore.Core.Entities;

namespace WebApiStore.Infraestructure.Data
{
    public class WebApiStoreContext : DbContext
    {
        public WebApiStoreContext(DbContextOptions options) : base(options) {
            
        }

        public DbSet<Product> Products { get; set; }

    }
}
