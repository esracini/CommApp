using CommAppAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommAppAPI.Persistence.Contexts
{
    public class CommAppAPIDbContext : DbContext
    {
        public CommAppAPIDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        //Fluent Api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Conpany -> Person bire çoık ilişki
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Company)
                .WithMany(c => c.Persons)
                .HasForeignKey(p => p.CompanyId)
                .OnDelete(DeleteBehavior.SetNull);
            // Şirket silinince çalışan silinmesin

            //Person -> Contact bire çok ilişki
            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Person)
                .WithMany(p => p.Contacts)
                .HasForeignKey(c => c.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
            // Kişi silinince iletişim bilgileri de silinsin

            //enum string olarak tutulacak
            modelBuilder.Entity<Contact>()
                .Property(c => c.Type)
                .HasConversion<string>()
                .HasMaxLength(20);
        }

    }
}
