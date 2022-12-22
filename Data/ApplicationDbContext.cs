using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GYMAPI.Models;
//using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
       {
            Database.EnsureCreated();
       }           

        public DbSet<Member> Members { get; set; }
        public DbSet<User> Users { get; set; }         
        public DbSet<Payment> Payments { get; set; }
}



