using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace JXHotel.Repository.ModelConfiguration
{
  public  class RoleTypeConfiguration   :EntityTypeConfiguration<Role>
    {
        public RoleTypeConfiguration()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
               .IsRequired()
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Map<HotelRole>(m => m.Requires("RoleType").HasValue("hotel"));
            Map<AppRole>(m => m.Requires("RoleType").HasValue("app"));
            Map<CustomerRole>(m => m.Requires("RoleType").HasValue("customer"));
            ToTable("Role");
        }
    }
}
