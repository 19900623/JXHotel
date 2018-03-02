using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 优惠活动图片实体
    /// </summary>
  public  class PromotionImage :Image
    {
        public Guid HotelPromotionId { get; set; }

        public virtual HotelPromotion HotelPromotion { get; set; }
    }
}
