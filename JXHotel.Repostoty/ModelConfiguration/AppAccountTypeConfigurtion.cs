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
  public  class AppAccountTypeConfigurtion  :EntityTypeConfiguration<AppAccount>
    {
        public AppAccountTypeConfigurtion()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
               .IsRequired()
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            ToTable("AppAccount");
        }
    }
}
