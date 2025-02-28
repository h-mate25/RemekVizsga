using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class DesignTimeDbContext : IDesignTimeDbContextFactory<WarehouseDbContext>
    {
        public WarehouseDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseDbContext>();

            // Itt add meg a connection stringet
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=RakKezelo_Database");

            return new WarehouseDbContext(optionsBuilder.Options);
        }
    }
}

