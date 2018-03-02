using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 满减优惠活动聚合
    /// </summary>
   public class OverMinusPromotion  :HotelPromotion
    {
        /// <summary>
        /// 满金额
        /// </summary>
        public decimal  OverMoney { get; set; }

        /// <summary>
        /// 减金额
        /// </summary>
        public decimal MinusMoney { get; set; }
    }
}
