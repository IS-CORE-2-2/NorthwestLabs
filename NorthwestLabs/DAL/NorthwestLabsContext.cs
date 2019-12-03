using NorthwestLabs.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwestLabs.DAL
{
    public class NorthwestLabsContext : DbContext
    {
        public NorthwestLabsContext()
            : base("NorthwestLabsContext")
        {

        }

        public DbSet<Assay_Required> Assay_Required { get; set; }
        public DbSet<Reference> Reference { get; set; }
        public DbSet<Assay> Assay { get; set; }
        public DbSet<Material_Assay> Material_Assay { get; set; }
        public DbSet<Test_Tube> Test_Tube { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Compound_Sample> Compound_Sample { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Order_Compound> Order_Compound { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
    }
}