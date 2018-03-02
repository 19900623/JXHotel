using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;

namespace JXHotel.Domain.Repository
{
    /// <summary>
    /// 酒店房间分类仓储接口
    /// </summary>
   public interface IHotelRoomCategoryRepository  :IRepository<HotelRoomCategory>
    {
        /// <summary>
        /// 根据活动id获取房间分类
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <returns></returns>
        List<HotelRoomCategory> GetHotelRoomCategoryByHotelPromotionId(Guid hotelPromotionId);

        /// <summary>
        /// 根据活动名称获取房间分类
        /// </summary>
        /// <param name="hotelPromotionName"></param>
        /// <returns></returns>
        List<HotelRoomCategory> GetHotelRoomCategoryByHotelPromotionName(string hotelPromotionName);


        /// <summary>
        /// 根据房间名称获取房间分类
        /// </summary>
        /// <param name="RoomName"></param>
        /// <returns></returns>
        HotelRoomCategory GetHotelRoomCategoryByRoomName(string RoomName);

    }
}
