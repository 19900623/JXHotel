using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;

namespace JXHotel.Domain.Repository
{
    /// <summary>
    /// 折扣优惠仓储接口
    /// </summary>
 public  interface IDiscountPromotionRepository : IHotelPromotionRepository<DiscountPromotion>
    {

    }
}
