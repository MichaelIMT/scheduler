using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduler.Models
{
    public class ShedulerContext : DbContext
    {
        public ShedulerContext() : base("Sheduler") { }

        public DbSet<Audience> Audiences { get; set; }
        public DbSet<Group> Groups { get; set; }  
        public DbSet<Kafedra> Kafedras { get; set; }
        public DbSet<Lektor> Lektors { get; set; }

        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectType> SubjectTypes { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Window> Windows { get; set; }
        public DbSet<Сorps> Сorpses { get; set; }
        public DbSet<MetodDni> MetodDni { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Specialty>()
                .HasRequired<Kafedra>(s => s.kafedra)
                .WithMany(g => g.Specialties)
                .HasForeignKey<int>(s => s.KafedraId).WillCascadeOnDelete(false);
        }
    }
}
