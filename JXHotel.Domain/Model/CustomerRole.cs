using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 消费者角色聚合根
    /// </summary>
  public  class CustomerRole :Role
    {
        public CustomerRole()
        {
            HotelPromotions = new HashSet<HotelPromotion>();
        }
         public virtual ICollection<HotelPromotion> HotelPromotions { get; set; }
    }
}
