using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 折扣优惠活动
    /// </summary>
  public  class DiscountPromotion  :HotelPromotion
    {
        /// <summary>
        /// 折扣率 如：Rate=20  实际价格为 原价格*80%
        /// </summary>
        public int Rate { get; set; }
    }
}
