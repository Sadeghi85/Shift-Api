// <auto-generated>
// ReSharper disable All

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leopard.Repository
{
    // SAMT_Mojri
    public partial class SamtMojriConfiguration : IEntityTypeConfiguration<SamtMojri>
    {
        public void Configure(EntityTypeBuilder<SamtMojri> builder)
        {
            builder.ToTable("SAMT_Mojri", "dbo");
            builder.HasKey(x => x.Id).HasName("PK_SAMT_Mojri").IsClustered();

            builder.Property(x => x.Id).HasColumnName(@"ID").HasColumnType("int").IsRequired().ValueGeneratedOnAdd().UseIdentityColumn();
            builder.Property(x => x.AgentId).HasColumnName(@"AgentID").HasColumnType("int").IsRequired();
            builder.Property(x => x.CoreMasterOfficeId).HasColumnName(@"CoreMasterOfficeID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.IsGuest).HasColumnName(@"IsGuest").HasColumnType("bit").IsRequired(false);
            builder.Property(x => x.IsTemp).HasColumnName(@"IsTemp").HasColumnType("bit").IsRequired(false);
            builder.Property(x => x.EducationDegreeId).HasColumnName(@"EducationDegreeID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.EducationDegreeKindId).HasColumnName(@"EducationDegreeKindID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.EducationField).HasColumnName(@"EducationField").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.EducationPlace).HasColumnName(@"EducationPlace").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.MaritalStatusId).HasColumnName(@"MaritalStatusID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ReferrerPerson).HasColumnName(@"ReferrerPerson").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.ReferrerContact).HasColumnName(@"ReferrerContact").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.PersonnelPicture).HasColumnName(@"PersonnelPicture").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.AddressKindId).HasColumnName(@"AddressKindID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.ProvinceId).HasColumnName(@"ProvinceID").HasColumnType("int").IsRequired(false);
            builder.Property(x => x.AddressPhone).HasColumnName(@"AddressPhone").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.AddressPostalCode).HasColumnName(@"AddressPostalCode").HasColumnType("nvarchar(50)").IsRequired(false).HasMaxLength(50);
            builder.Property(x => x.Address).HasColumnName(@"Address").HasColumnType("nvarchar(max)").IsRequired(false);
            builder.Property(x => x.MojriOfficeIsDeleted).HasColumnName(@"MojriOfficeIsDeleted").HasColumnType("bit").IsRequired(false);

            InitializePartial(builder);
        }

        partial void InitializePartial(EntityTypeBuilder<SamtMojri> builder);
    }

}
// </auto-generated>