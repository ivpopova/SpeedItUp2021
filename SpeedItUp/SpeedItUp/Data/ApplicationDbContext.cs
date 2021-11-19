using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SpeedItUp.Models;
using System.Data;

namespace SpeedItUp.Data
{
    public class ApplicationDbContext : IdentityDbContext<Person>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //this.Database.Migrate();
        }

        public DbSet<SpeedItUp.Models.Child> Child { get; set; }

        public DbSet<SpeedItUp.Models.Slot> Slot { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Child>()
                 .HasMany(s => s.Slots)
                 .WithMany(c => c.Children)
                 .UsingEntity<Dictionary<string, object>>(
                "ChildSlot",
            j => j
                    .HasOne<Slot>()
                    .WithMany()
                    .HasForeignKey("SlotsId")
                    .HasConstraintName("FK_ChildSlot_Slot_SlotsId")
                    .OnDelete(DeleteBehavior.ClientCascade),
            j => j
                    .HasOne<Child>().WithMany()
                    .HasForeignKey("ChildrenId")
                    .HasConstraintName("FK_ChildSlot_Child_ChildrenId")
                    .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Child>()
            .HasMany(c => c.Parents)
            .WithMany(c => c.Children)
            .UsingEntity<Dictionary<string, object>>(
                "ChildPerson",
            j => j
                    .HasOne<Person>()
                    .WithMany()
                    .HasForeignKey("ParentsId")
                    .HasConstraintName("FK_ChildPerson_Person_ParentsId")
                    .OnDelete(DeleteBehavior.ClientCascade),
            j => j
                    .HasOne<Child>().WithMany()
                    .HasForeignKey("ChildrenId")
                    .HasConstraintName("FK_ChildPerson_Child_ChildrenId")
                    .OnDelete(DeleteBehavior.Cascade));


            modelBuilder.Entity<Slot>()
                .HasMany(s => s.Children)
                .WithMany(c => c.Slots)
                .UsingEntity<Dictionary<string, object>>(
                 "ChildSlot",
                j => j
                    .HasOne<Child>().WithMany()
                    .HasForeignKey("ChildrenId")
                    .HasConstraintName("FK_ChildSlot_Child_ChildrenId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Slot>()
                    .WithMany()
                    .HasForeignKey("SlotsId")
                    .HasConstraintName("FK_ChildSlot_Slot_SlotsId")
                    .OnDelete(DeleteBehavior.ClientCascade));


            modelBuilder.Entity<Slot>()
                .HasMany(s => s.Entertainers)
                .WithMany(c => c.Slots)
                .UsingEntity<Dictionary<string, object>>(
                "PersonSlot",
            j => j
                    .HasOne<Person>()
                    .WithMany()
                    .HasForeignKey("EntertainersId")
                    .HasConstraintName("FK_PersonSlot_Person_EntertainersId")
                    .OnDelete(DeleteBehavior.ClientCascade),
                j => j
                    .HasOne<Slot>()
                    .WithMany()
                    .HasForeignKey("SlotsId")
                    .HasConstraintName("FK_PersonSlot_Slot_SlotsId")
                    .OnDelete(DeleteBehavior.ClientCascade));

            modelBuilder.Entity<Person>()
                .HasMany(s => s.Slots)
                .WithMany(c => c.Entertainers)
                                .UsingEntity<Dictionary<string, object>>(
                "PersonSlot",
                 j => j
                    .HasOne<Slot>()
                    .WithMany()
                    .HasForeignKey("SlotsId")
                    .HasConstraintName("FK_PersonSlot_Slot_SlotsId")
                    .OnDelete(DeleteBehavior.ClientCascade),
                j => j
                    .HasOne<Person>()
                    .WithMany()
                    .HasForeignKey("EntertainersId")
                    .HasConstraintName("FK_PersonSlot_Person_EntertainersId")
                    .OnDelete(DeleteBehavior.ClientCascade));

            modelBuilder.Entity<Person>()
               .HasMany(s => s.Children)
               .WithMany(c => c.Parents)
               .UsingEntity<Dictionary<string, object>>(
                "ChildPerson",
                j => j
                    .HasOne<Child>().WithMany()
                    .HasForeignKey("ChildrenId")
                    .HasConstraintName("FK_ChildPerson_Child_ChildrenId")
                    .OnDelete(DeleteBehavior.Cascade),
                j => j
                    .HasOne<Person>()
                    .WithMany()
                    .HasForeignKey("ParentsId")
                    .HasConstraintName("FK_ChildPerson_Person_ParentsId")
                    .OnDelete(DeleteBehavior.ClientCascade));


            base.OnModelCreating(modelBuilder);
        }
    }
}
