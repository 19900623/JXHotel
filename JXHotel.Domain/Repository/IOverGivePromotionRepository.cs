using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;

namespace JXHotel.Domain.Repository
{
    /// <summary>
    /// 满送优惠活动仓储接口
    /// </summary>
  public  interface IOverGivePromotionRepository  :IHotelPromotionRepository<OverGivePromotion>
    {
    }
}
