using Microsoft.EntityFrameworkCore;
using Domains = Template.Domain.Entities;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) 
            : base(options) { }

        public DbSet<Domains.TaskTodo> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Domains.TaskTodo>().ToTable("tarefas");
            builder.Entity<Domains.TaskTodo>().Property(x => x.Id);
            builder.Entity<Domains.TaskTodo>().Property(x => x.Title).HasMaxLength(60).HasColumnType("varchar(60)");
            builder.Entity<Domains.TaskTodo>().HasIndex(x => x.Id);
        }
    }
}
