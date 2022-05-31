using Data.Entities;
using Data.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Flower> Flowers { get; set; }
        public DbSet<Orders> Orders { get; set; }
    }
}
