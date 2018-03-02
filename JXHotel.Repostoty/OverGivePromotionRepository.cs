using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;
using JXHotel.Domain.Repository;

namespace JXHotel.Repository
{
    /// <summary>
    /// 满送优惠活动仓储
    /// </summary>
    public class OverGivePromotionRepository : HotelPromotionRepository<OverGivePromotion>, IOverGivePromotionRepository
    {
        public OverGivePromotionRepository(IRepositoryContext context) : base(context)
        {
        }

    }
}
