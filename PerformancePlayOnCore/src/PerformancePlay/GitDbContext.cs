using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PerformancePlay.Models;

namespace PerformancePlay
{
    public partial class GitDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseSqlServer(@"data source=CH602;initial catalog=GitDataDb;user id=sa;password=123;MultipleActiveResultSets=True;App=EntityFramework");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GitHubResume>(entity =>
            {
                entity.HasKey(e => e.UserResumeId)
                    .HasName("PK_dbo.GitHubResume");

                entity.Property(e => e.PiplMatchedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<GitHubUser>(entity =>
            {
                entity.HasKey(e => e.Dbid)
                    .HasName("PK_dbo.GitHubUser");

                entity.Property(e => e.Dbid).HasColumnName("DBId");

                entity.Property(e => e.GrabDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<LData>(entity =>
            {
                entity.ToTable("LData");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.Model).IsRequired();

                entity.Property(e => e.ProductVersion)
                    .IsRequired()
                    .HasMaxLength(32);
            });
        }

        public virtual DbSet<GitHubResume> GitHubResumes { get; set; }
        public virtual DbSet<GitHubUser> GitHubUsers { get; set; }
        public virtual DbSet<LData> LData { get; set; }
        public virtual DbSet<MigrationHistory> MigrationHistory { get; set; }
        public virtual DbSet<PersonSkill> PersonSkill { get; set; }
    }
}