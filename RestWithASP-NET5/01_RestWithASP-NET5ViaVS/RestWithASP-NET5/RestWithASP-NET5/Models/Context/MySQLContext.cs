﻿using Microsoft.EntityFrameworkCore;

namespace RestWithASP_NET5.Models.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {

        }

        public MySQLContext(DbContextOptions<MySQLContext> options) :base(options) { }

        public DbSet<Person> Persons { get; set; }
    }
}
