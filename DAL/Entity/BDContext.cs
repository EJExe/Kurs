using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL.Entity
{
    public partial class BdContext : DbContext
    {
        public BdContext()
            : base("name=BdContext")
        {
        }

        public virtual DbSet<CallTable> CallTable { get; set; }
        public virtual DbSet<DataTable> DataTable { get; set; }
        public virtual DbSet<SMSTable> SMSTable { get; set; }
        public virtual DbSet<TarifTable> TarifTable { get; set; }
        public virtual DbSet<TypeOfCallTable> TypeOfCallTable { get; set; }
        public virtual DbSet<TypeOfTarifTable> TypeOfTarifTable { get; set; }
        public virtual DbSet<UserTable> UserTable { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CallTable>()
                .Property(e => e.C__FK__Number_Sender)
                .IsUnicode(false);

            modelBuilder.Entity<CallTable>()
                .Property(e => e.C__FK__Number_Getter)
                .IsUnicode(false);

            modelBuilder.Entity<DataTable>()
                .Property(e => e.C__FK__Numbe_Of_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<SMSTable>()
                .Property(e => e.C__FK__Number_Poluchatela)
                .IsUnicode(false);

            modelBuilder.Entity<SMSTable>()
                .Property(e => e.C__FK__Number_Otpravitela)
                .IsUnicode(false);

            modelBuilder.Entity<TarifTable>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TypeOfCallTable>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<TypeOfTarifTable>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserTable>()
                .Property(e => e.C__PK___Number_Of_Phone)
                .IsUnicode(false);

            modelBuilder.Entity<UserTable>()
                .Property(e => e.FIO)
                .IsUnicode(false);

            modelBuilder.Entity<UserTable>()
                .Property(e => e.Loging)
                .IsUnicode(false);

            modelBuilder.Entity<UserTable>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
