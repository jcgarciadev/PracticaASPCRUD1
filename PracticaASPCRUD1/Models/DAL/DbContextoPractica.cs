using Microsoft.EntityFrameworkCore;
using PracticaASPCRUD2.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaASPCRUD2.Models.DAL
{
    public class DbContextoPractica:DbContext
    {
        public DbContextoPractica(DbContextOptions<DbContextoPractica> options):
            base(options)
        {

        }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Cargo> Cargos { get; set; }      

    }
}
