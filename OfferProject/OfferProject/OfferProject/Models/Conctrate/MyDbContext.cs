using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OfferProject.Models.Conctrate
{
    public class MyDbContext: DbContext
    {
        public MyDbContext() { }
        public DbSet<City> cities { get; set; }
        public DbSet<Countries> countries { get; set; }
        public DbSet<Currency> currencies { get; set; }
        public DbSet<Incoterm> ıncoterms { get; set; }
        public DbSet<Mode> modes { get; set; }
        public DbSet<MovementType> movementTypes { get; set; }
        public DbSet<Offer> offers { get; set; }
        public DbSet<PackageType> packageTypes { get; set; }
        public DbSet<Unit1> unit1s { get; set; }
        public DbSet<Unit2> unit2s { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Admin> admins { get; set; }
    }
}