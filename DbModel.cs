namespace Expensify
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DbModel")
        {
        }

        public virtual DbSet<MISCELLANEOU> MISCELLANEOUS { get; set; }
        public virtual DbSet<PERSONAL_CARE> PERSONAL_CAREs { get; set; }
        public virtual DbSet<SAVING> SAVINGS { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MISCELLANEOU>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<PERSONAL_CARE>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<SAVING>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.MISCELLANEOUS)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasOptional(e => e.PERSONAL_CARE)
                .WithRequired(e => e.user);

            modelBuilder.Entity<user>()
                .HasMany(e => e.SAVINGS)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasOptional(e => e.users1)
                .WithRequired(e => e.user1);
        }
    }
}
