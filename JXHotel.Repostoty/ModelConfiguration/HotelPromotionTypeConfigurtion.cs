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
  public  class HotelPromotionTypeConfigurtion   :EntityTypeConfiguration<HotelPromotion>
    {
        public HotelPromotionTypeConfigurtion()
        {
            HasKey(c => c.Id);
            Property(c => c.Id)
               .IsRequired()
               .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Map<DiscountPromotion>(m => m.Requires("PromotionType").HasValue("discount"));
            Map<OverGivePromotion>(m => m.Requires("PromotionType").HasValue("overgive"));
            Map<OverMinusPromotion>(m => m.Requires("PromotionType").HasValue("overminus"));
            ToTable("HotelPromotion");
        }
    }
}
