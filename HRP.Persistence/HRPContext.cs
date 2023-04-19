using HRP.Application.Interfaces;
using HRP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRP.Persistence;

public partial class HRPContext : DbContext, IHRPDbContext
{
    public HRPContext()
    {
    }

    public HRPContext(DbContextOptions<HRPContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppEmployeeControlGroupRole> AppEmployeeControlGroupRoles { get; set; }
    public virtual DbSet<AppEmployeeHoliday> AppEmployeeHolidays { get; set; }
    public virtual DbSet<AppEmployeeInProject> AppEmployeeInProjects { get; set; }
    public virtual DbSet<AppHolidayInYear> AppHolidayInYears { get; set; }
    public virtual DbSet<RefCategory> RefCategories { get; set; }
    public virtual DbSet<RefControlGroup> RefControlGroups { get; set; }
    public virtual DbSet<RefControlGroupRole> RefControlGroupRoles { get; set; }
    public virtual DbSet<RefEmployee> RefEmployees { get; set; }
    public virtual DbSet<RefHoliday> RefHolidays { get; set; }
    public virtual DbSet<RefPlayer> RefPlayers { get; set; }
    public virtual DbSet<RefPosition> RefPositions { get; set; }
    public virtual DbSet<RefProject> RefProjects { get; set; }
    public virtual DbSet<RefSubdivision> RefSubdivisions { get; set; }
    public virtual DbSet<ViewEmployeeApprovement> ViewEmployeeApprovements { get; set; }
    public virtual DbSet<ViewEmployeeTree> ViewEmployeeTrees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("name=HRPConnection");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppEmployeeControlGroupRole>(entity =>
        {
            entity.HasKey(e => e.IdEmployeeControlGroupRole);

            entity.ToTable("App_EmployeeControlGroupRole");

            entity.HasIndex(e => new { e.IdEmployee, e.IdGroup }, "UK_EmployeeControlGroupRole").IsUnique();

            entity.Property(e => e.IdEmployeeControlGroupRole).HasColumnName("idEmployeeControlGroupRole");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IdGroup).HasColumnName("idGroup");
            entity.Property(e => e.IdRole).HasColumnName("idRole");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.AppEmployeeControlGroupRoles)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("FK_EmployeeControlGroupRole_Employee");

            entity.HasOne(d => d.IdGroupNavigation).WithMany(p => p.AppEmployeeControlGroupRoles)
                .HasForeignKey(d => d.IdGroup)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeControlGroupRole_Group");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.AppEmployeeControlGroupRoles)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EmployeeControlGroupRole_Role");
        });

        modelBuilder.Entity<AppEmployeeHoliday>(entity =>
        {
            entity.HasKey(e => e.IdEmployeeHoliday);

            entity.ToTable("App_EmployeeHoliday");

            entity.Property(e => e.IdEmployeeHoliday).HasColumnName("idEmployeeHoliday");
            entity.Property(e => e.DayCount).HasColumnName("dayCount");
            entity.Property(e => e.FactReleaseDate)
                .HasColumnType("datetime")
                .HasColumnName("factReleaseDate");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.IsPreferential).HasColumnName("isPreferential");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.AppEmployeeHolidays)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("FK_App_EmployeeHoliday_Ref_Employee");
        });

        modelBuilder.Entity<AppEmployeeInProject>(entity =>
        {
            entity.HasKey(e => e.IdEmployeeInProject);

            entity.ToTable("App_EmployeeInProject");

            entity.Property(e => e.IdEmployeeInProject).HasColumnName("idEmployeeInProject");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("endDate");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IdProject).HasColumnName("idProject");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.AppEmployeeInProjects)
                .HasForeignKey(d => d.IdEmployee)
                .HasConstraintName("FK_App_EmployeeInProject_Ref_Employee");

            entity.HasOne(d => d.IdProjectNavigation).WithMany(p => p.AppEmployeeInProjects)
                .HasForeignKey(d => d.IdProject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_App_EmployeeInProject_Ref_Project");
        });

        modelBuilder.Entity<AppHolidayInYear>(entity =>
        {
            entity.HasKey(e => e.IdHolidayInYear);

            entity.ToTable("App_HolidayInYear");

            entity.Property(e => e.IdHolidayInYear).HasColumnName("idHolidayInYear");
            entity.Property(e => e.FactDate)
                .HasColumnType("datetime")
                .HasColumnName("factDate");
            entity.Property(e => e.FactEndDate)
                .HasColumnType("datetime")
                .HasColumnName("factEndDate");
            entity.Property(e => e.IdHoliday).HasColumnName("idHoliday");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.IdHolidayNavigation).WithMany(p => p.AppHolidayInYears)
                .HasForeignKey(d => d.IdHoliday)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_App_HolidayInYear_Ref_Holiday");
        });

        modelBuilder.Entity<RefCategory>(entity =>
        {
            entity.HasKey(e => e.IdCategory);

            entity.ToTable("Ref_Category");

            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("categoryName");
        });

        modelBuilder.Entity<RefControlGroup>(entity =>
        {
            entity.HasKey(e => e.IdGroup);

            entity.ToTable("Ref_ControlGroup");

            entity.HasIndex(e => e.IdGroup, "UK_ControlGroup").IsUnique();

            entity.Property(e => e.IdGroup).HasColumnName("idGroup");
            entity.Property(e => e.GroupName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("groupName");
        });

        modelBuilder.Entity<RefControlGroupRole>(entity =>
        {
            entity.HasKey(e => e.IdRole);

            entity.ToTable("Ref_ControlGroupRole");

            entity.HasIndex(e => e.IdRole, "UK_ControlGroupRole").IsUnique();

            entity.Property(e => e.IdRole).HasColumnName("idRole");
            entity.Property(e => e.RoleName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("roleName");
        });

        modelBuilder.Entity<RefEmployee>(entity =>
        {
            entity.HasKey(e => e.IdEmployee);

            entity.ToTable("Ref_Employee");

            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.DomainName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("domainName");
            entity.Property(e => e.EmployeeIdentificationNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.IdPosition).HasColumnName("idPosition");
            entity.Property(e => e.IdSubdivision).HasColumnName("idSubdivision");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.RefEmployees)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ref_Employee_Ref_Category");

            entity.HasOne(d => d.IdPositionNavigation).WithMany(p => p.RefEmployees)
                .HasForeignKey(d => d.IdPosition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ref_Employee_Ref_Position");

            entity.HasOne(d => d.IdSubdivisionNavigation).WithMany(p => p.RefEmployees)
                .HasForeignKey(d => d.IdSubdivision)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ref_Employee_Ref_Subdivision");
        });

        modelBuilder.Entity<RefHoliday>(entity =>
        {
            entity.HasKey(e => e.IdHoliday);

            entity.ToTable("Ref_Holiday");

            entity.Property(e => e.IdHoliday).HasColumnName("idHoliday");
            entity.Property(e => e.HolidayName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("holidayName");
        });

        modelBuilder.Entity<RefPlayer>(entity =>
        {
            entity.HasKey(e => e.IdPlayer).HasName("PK_Ref_Player");

            entity.ToTable("Ref_Players");

            entity.Property(e => e.IdPlayer).HasColumnName("idPlayer");
            entity.Property(e => e.DomainName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("domainName");
            entity.Property(e => e.EMiddleName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("eMiddleName");
            entity.Property(e => e.EName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("eName");
            entity.Property(e => e.ESurname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("eSurname");
            entity.Property(e => e.EmployeeIdentificationNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IdSubdivision).HasColumnName("idSubdivision");
            entity.Property(e => e.PMiddleName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pMiddleName");
            entity.Property(e => e.PName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pName");
            entity.Property(e => e.PSurname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("pSurname");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.RefPlayers)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Ref_Player_Ref_Employee");
        });

        modelBuilder.Entity<RefPosition>(entity =>
        {
            entity.HasKey(e => e.IdPosition);

            entity.ToTable("Ref_Position");

            entity.Property(e => e.IdPosition).HasColumnName("idPosition");
            entity.Property(e => e.PositionName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("positionName");
        });

        modelBuilder.Entity<RefProject>(entity =>
        {
            entity.HasKey(e => e.IdProject);

            entity.ToTable("Ref_Project");

            entity.Property(e => e.IdProject).HasColumnName("idProject");
            entity.Property(e => e.ProjectDescription)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("projectDescription");
            entity.Property(e => e.ProjectName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("projectName");
        });

        modelBuilder.Entity<RefSubdivision>(entity =>
        {
            entity.HasKey(e => e.IdSubdivision);

            entity.ToTable("Ref_Subdivision");

            entity.Property(e => e.IdSubdivision).HasColumnName("idSubdivision");
            entity.Property(e => e.IdParentSubdivision).HasColumnName("idParentSubdivision");
            entity.Property(e => e.ShortName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("shortName");
            entity.Property(e => e.SubdivisionName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("subdivisionName");

            entity.HasOne(d => d.IdParentSubdivisionNavigation).WithMany(p => p.InverseIdParentSubdivisionNavigation)
                .HasForeignKey(d => d.IdParentSubdivision)
                .HasConstraintName("FK_Subdivision_Parent_Child");
        });

        modelBuilder.Entity<ViewEmployeeApprovement>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_EmployeeApprovements");

            entity.Property(e => e.DayCount).HasColumnName("dayCount");
            entity.Property(e => e.FactReleaseDate)
                .HasColumnType("datetime")
                .HasColumnName("factReleaseDate");
            entity.Property(e => e.FullName)
                .HasMaxLength(302)
                .IsUnicode(false);
            entity.Property(e => e.HolidayCount).HasColumnName("holidayCount");
            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IdEmployeeHoliday).HasColumnName("idEmployeeHoliday");
            entity.Property(e => e.IdPosition).HasColumnName("idPosition");
            entity.Property(e => e.IdSubdivision).HasColumnName("idSubdivision");
            entity.Property(e => e.IsApproved).HasColumnName("isApproved");
            entity.Property(e => e.IsPreferential).HasColumnName("isPreferential");
            entity.Property(e => e.MaxDayCount).HasColumnName("maxDayCount");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("startDate");
            entity.Property(e => e.TotalDays).HasColumnName("totalDays");
            entity.Property(e => e.Year).HasColumnName("year");
        });

        modelBuilder.Entity<ViewEmployeeTree>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("View_EmployeeTree");

            entity.Property(e => e.CategoryName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("categoryName");
            entity.Property(e => e.DomainName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("domainName");
            entity.Property(e => e.EmployeeIdentificationNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(302)
                .IsUnicode(false);
            entity.Property(e => e.IdBoss).HasColumnName("idBoss");
            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");
            entity.Property(e => e.IdParentSubdivision).HasColumnName("idParentSubdivision");
            entity.Property(e => e.IdPosition).HasColumnName("idPosition");
            entity.Property(e => e.IdSubdivision).HasColumnName("idSubdivision");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PositionName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("positionName");
            entity.Property(e => e.ShortName)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("shortName");
            entity.Property(e => e.SubdivisionName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("subdivisionName");
            entity.Property(e => e.Surname)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}