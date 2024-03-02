using System;
using System.Collections.Generic;
using ApplicationSecurity.Domain.IdentityAccessManagementEntities;
using Microsoft.EntityFrameworkCore;

namespace ApplicationSecurity.Domain.IdentityAccessManagementDbContext;

public partial class ApplicationDevelopmentSecuritydbContext : DbContext
{
    public ApplicationDevelopmentSecuritydbContext()
    {
    }

    public ApplicationDevelopmentSecuritydbContext(DbContextOptions<ApplicationDevelopmentSecuritydbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApiKey> ApiKeys { get; set; }

    public virtual DbSet<CustomerApplication> CustomerApplications { get; set; }

    public virtual DbSet<CustomerForApplication> CustomerForApplications { get; set; }

    public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleGroup> RoleGroups { get; set; }

    public virtual DbSet<SingleSignOnUser> SingleSignOnUsers { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=ApplicationDevelopmentSecuritydb;Trusted_Connection=true;TrustServerCertificate=True;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApiKey>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ApiKeyId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ClientId).HasMaxLength(250);
            entity.Property(e => e.ClientName).HasMaxLength(250);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateInactive).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
        });

        modelBuilder.Entity<CustomerApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CustomerApplicationId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateInactive).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.CustomerForApplication).WithMany(p => p.CustomerApplications)
                .HasForeignKey(d => d.CustomerForApplicationId)
                .HasConstraintName("FK_CustomerForApplicationId");
        });

        modelBuilder.Entity<CustomerForApplication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_CustomerForApplicationId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateInactive).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<EmailTemplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EmailTemplateId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateInactive).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RoleId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateInactive).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.RoleGroup).WithMany(p => p.Roles)
                .HasForeignKey(d => d.RoleGroupId)
                .HasConstraintName("FK_RoleGroupId");
        });

        modelBuilder.Entity<RoleGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_RoleGroupId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateInactive).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);

            entity.HasOne(d => d.CustomerApplication).WithMany(p => p.RoleGroups)
                .HasForeignKey(d => d.CustomerApplicationId)
                .HasConstraintName("FK_CustomerApplicationId");
        });

        modelBuilder.Entity<SingleSignOnUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_SingleSignOnId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateInactive).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(250);

            entity.HasOne(d => d.User).WithMany(p => p.SingleSignOnUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_SingleSignOnUserId");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UsersID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateInactive).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.DisplayName).HasMaxLength(250);
            entity.Property(e => e.Email).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(250);
            entity.Property(e => e.IdNumber).HasMaxLength(250);
            entity.Property(e => e.LastName).HasMaxLength(250);
            entity.Property(e => e.MobileNo).HasMaxLength(50);
            entity.Property(e => e.PasswordResetExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.PasswordSetUpExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.TelNo).HasMaxLength(50);
            entity.Property(e => e.UserCode).HasMaxLength(250);
            entity.Property(e => e.UserName).HasMaxLength(250);

            entity.HasOne(d => d.UserType).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserTypeId)
                .HasConstraintName("FK_UserTypeId");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UserRoleId");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_UR_RoleId");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UR_UserId");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_UserTypesID");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateInactive).HasColumnType("datetime");
            entity.Property(e => e.DateUpdated).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
