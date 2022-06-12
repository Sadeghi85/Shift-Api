// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // SAMT_Agents
    public partial class SamtAgentConfiguration : IEntityTypeConfiguration<SamtAgent>
    {
        public void Configure(EntityTypeBuilder<SamtAgent> builder)
        {
            builder.ToTable("SAMT_Agents", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_TelavatAgents").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.FirstName).HasColumnName(@"FirstName").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.LastName).HasColumnName(@"LastName").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.NationalCode).HasColumnName(@"NationalCode").HasColumnType("nvarchar(20)").IsRequired(false).HasMaxLength(20);
            builder.Property(x => x.PersonnelId).HasColumnName(@"PersonnelID").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.Phone).HasColumnName(@"Phone").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.Address).HasColumnName(@"Address").HasColumnType("nvarchar(4000)").IsRequired(false).HasMaxLength(4000);
            builder.Property(x => x.Mobile).HasColumnName(@"Mobile").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.StatusEmployment).HasColumnName(@"StatusEmployment").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.WorkTypeId).HasColumnName(@"WorkTypeID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.IsDeleted).HasColumnName(@"IsDeleted").HasColumnType("bit").IsRequired();
            builder.Property(x => x.FatherName).HasColumnName(@"FatherName").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.RegCardNum).HasColumnName(@"RegCardNum").HasColumnType("nvarchar(20)").IsRequired(false).HasMaxLength(20);
            builder.Property(x => x.BirthPlace).HasColumnName(@"BirthPlace").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.BirthPlaceTitle).HasColumnName(@"BirthPlaceTitle").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.BirthDate).HasColumnName(@"BirthDate").HasColumnType("char(10)").IsRequired(false).IsFixedLength().IsUnicode(false).HasMaxLength(10);
            builder.Property(x => x.Sex).HasColumnName(@"Sex").HasColumnType("bit").IsRequired(false);
            builder.Property(x => x.FaxNum).HasColumnName(@"FaxNum").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.Nationality).HasColumnName(@"Nationality").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.SpouseDescription).HasColumnName(@"SpouseDescription").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.Email).HasColumnName(@"Email").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.EducationDegree).HasColumnName(@"EducationDegree").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.EducationDegreeTitle).HasColumnName(@"EducationDegreeTitle").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.EducationField).HasColumnName(@"EducationField").HasColumnType("nvarchar(1000)").IsRequired(false).HasMaxLength(1000);
            builder.Property(x => x.EmployeeNum).HasColumnName(@"EmployeeNum").HasColumnType("nvarchar(20)").IsRequired(false).HasMaxLength(20);
            builder.Property(x => x.SimaFilm).HasColumnName(@"SimaFilm").HasColumnType("bit").IsRequired(false);
            builder.Property(x => x.IsCompany).HasColumnName(@"IsCompany").HasColumnType("bit").IsRequired(false);
            builder.Property(x => x.PersonImage).HasColumnName(@"PersonImage").HasColumnType("nvarchar(500)").IsRequired(false).HasMaxLength(500);

            builder.HasIndex(x => new { x.FirstName, x.LastName }).HasDatabaseName("IX_NAME");

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<SamtAgent> builder);
    }

}
// </auto-generated>
