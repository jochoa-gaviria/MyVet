using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyVet.Web.Data;
namespace MyVet.Web.Data.Entities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<History> Histiories { get; set; }
        public DbSet<Agenda> Agendas { get; set; }
    }
}
