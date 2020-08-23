namespace Expensify
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Expensify.Models;

    public partial class DbModel1 : DbContext
    {
        public DbModel1()
            : base("name=DbModel1")
        {
        }

        public virtual DbSet<Expens> Expenses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expens>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<Expens>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<Expens>()
                .Property(e => e.username)
                .IsUnicode(false);
        }
    }
}
