using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Service
{
    /// <summary>
    /// 活动与房间分类聚合服务接口
    /// </summary>
   public interface IHotelPromotionRoomCategoryService
    {
        /// <summary>
        /// 将活动指向房间分类
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <param name="HotelRoomCategoryID"></param>
        void AssignHotelRoomCategory(Guid hotelPromotionId, Guid HotelRoomCategoryID);
       

        /// <summary>
        /// 将活动从房间分类中移除
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <param name="HotelRoomCategoryID"></param>
        void UnassignHotelRoomCategory(Guid hotelPromotionId, Guid HotelRoomCategoryID);
        

        
    }
}
