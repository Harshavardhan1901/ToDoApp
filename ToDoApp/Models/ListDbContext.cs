﻿using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models
{
    public class ListDbContext : DbContext
    {
        public ListDbContext(DbContextOptions<ListDbContext> options) : base(options)
        {
        }

        public DbSet<List> List { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=LAPTOP-P20IR6K6;database=ToDoAppDb;trusted_connection=true; TrustServerCertificate=true;");
        }
    }
}
