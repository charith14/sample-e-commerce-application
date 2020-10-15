using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace sample_e_commerce_application.Models
{
    public class EcomContext:DbContext
    {
        public DbSet<Rent> Rents { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Branch> Branches { get; set; }
    }
}