using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 满送优惠活动  满足多少天及送多少天
    /// </summary>
   public class OverGivePromotion  :HotelPromotion
    {
        public int OverDay { get; set; }


        public int GiveDay { get; set; }
    }
}
