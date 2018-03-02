using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace JXHotel.Repository.ModelConfiguration
{
  public  class HotelUserTypeConfiguration   :EntityTypeConfiguration<HotelUser>
    {
        public HotelUserTypeConfiguration()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
               .IsRequired()
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(20);
            Property(c => c.PassWord)
                .IsRequired()
                .HasMaxLength(20);
            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(80);
            ToTable("HotelUser");
        }
    }
}
