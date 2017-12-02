using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Try1975.Nevlabs.Entities;

namespace Try1975.Nevlabs.MsSql.Mappings
{
    public class PersonMap : EntityTypeConfiguration<PersonEntity>
    {
        public PersonMap(string tableName)
        {
            HasKey(e => e.Id);
            Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            ToTable($"{tableName}");

            Property(e => e.Fullname)
                .IsOptional()
                .HasMaxLength(250)
                ;

            Property(e => e.Birthday)
                .IsOptional()
                .HasColumnType("date")
                ;

            Property(e => e.Email)
                .IsOptional()
                .HasMaxLength(50)
                ;

            Property(e => e.Phone)
                .IsOptional()
                .HasMaxLength(50)
                ;
        }
    }
}