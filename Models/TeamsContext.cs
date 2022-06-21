using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using kolokwium2.Models;
using System.Diagnostics.CodeAnalysis;

namespace kolokwium2.Models
{
    public class TeamsContext : DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Member> Members { get; set; }
        public TeamsContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Organization>(e =>
            {
                e.HasKey(o => o.OrganizationID);
                e.Property(o => o.OrganizationName).HasMaxLength(100).IsRequired();
                e.Property(o => o.OrganizationDomain).HasMaxLength(50).IsRequired();

                e.HasData(
                    new Organization { OrganizationID = 1, OrganizationName = "Organization1", OrganizationDomain = "org1.com" },
                    new Organization { OrganizationID = 2, OrganizationName = "Organization2", OrganizationDomain = "org2.com" },
                    new Organization { OrganizationID = 3, OrganizationName = "Organization3", OrganizationDomain = "org3.com" }
                );
            });
            modelBuilder.Entity<Team>(e =>
            {
                e.HasKey(t => t.TeamID);
                e.Property(t => t.TeamName).HasMaxLength(50).IsRequired();
                e.Property(t => t.TeamDescription).HasMaxLength(100).IsRequired();

                e.HasData(
                    new Team { TeamID = 1, TeamName = "Team1", TeamDescription = "Team1 description", OrganizationID = 1 },
                    new Team { TeamID = 2, TeamName = "Team2", TeamDescription = "Team2 description", OrganizationID = 2 },
                    new Team { TeamID = 3, TeamName = "Team3", TeamDescription = "Team3 description", OrganizationID = 3 }
                );
            });
            modelBuilder.Entity<File>(e =>
            {
                e.HasKey(f => f.FileID);
                e.Property(f => f.FileName).HasMaxLength(100).IsRequired();
                e.Property(f => f.FileExtension).HasMaxLength(4).IsRequired();
                e.Property(f => f.FileSize).IsRequired();

                e.HasData(
                    new File { FileID = 1, FileName = "File1", FileExtension = "txt", FileSize = 1, TeamID = 1 },
                    new File { FileID = 2, FileName = "File2", FileExtension = "txt", FileSize = 2, TeamID = 2 },
                    new File { FileID = 3, FileName = "File3", FileExtension = "txt", FileSize = 3, TeamID = 3 }
                );
            });
            modelBuilder.Entity<Membership>(e =>
            {
                e.HasKey(m => m.MembershipID);
                e.Property(m => m.DateFrom).IsRequired();

                e.HasData(
                    new Membership { MembershipID = 1, DateFrom = new DateTime(2020, 1, 1), TeamID = 1, MemberID = 1 },
                    new Membership { MembershipID = 2, DateFrom = new DateTime(2020, 1, 1), TeamID = 2, MemberID = 2 },
                    new Membership { MembershipID = 3, DateFrom = new DateTime(2020, 1, 1), TeamID = 3, MemberID = 3 }
                );
            });
            modelBuilder.Entity<Member>(e =>
            {
                e.HasKey(m => m.MemberID);
                e.Property(m => m.FirstName).HasMaxLength(20).IsRequired();
                e.Property(m => m.Surname).HasMaxLength(50).IsRequired();
                e.Property(m => m.Nickname).HasMaxLength(20);


                e.HasData(
                    new Member { MemberID = 1, FirstName = "FirstName1", Surname = "Surname1", Nickname = "Nickname1" },
                    new Member { MemberID = 2, FirstName = "FirstName2", Surname = "Surname2", Nickname = "Nickname2" },
                    new Member { MemberID = 3, FirstName = "FirstName3", Surname = "Surname3", Nickname = "Nickname3" }
                );
            });
            }
        }
}