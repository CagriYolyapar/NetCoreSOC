using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Context
{
    public class MyContext:IdentityDbContext
    {
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {


        }

        public DbSet<Product> Products { get; set; }
    }
}
