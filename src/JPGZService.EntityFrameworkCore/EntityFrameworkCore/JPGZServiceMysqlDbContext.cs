using Abp.EntityFrameworkCore;
using JPGZService.testmysqldb;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace JPGZService.EntityFrameworkCore
{
    public class JPGZServiceMysqlDbContext : AbpDbContext
    {
        public JPGZServiceMysqlDbContext(DbContextOptions<JPGZServiceMysqlDbContext> options)
           : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
        public virtual DbSet<Person> StudentBase { get; set; }
    }
}
