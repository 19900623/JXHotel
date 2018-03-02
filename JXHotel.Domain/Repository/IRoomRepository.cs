using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;

namespace JXHotel.Domain.Repository
{
   public interface IRoomRepository  :IRepository<Room>
    {
        /// <summary>
        /// 根据酒店名称获取酒店房间
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        List<Room> GetRoomsByHotelName(string hotelName);

        #region 房间图片
        /// <summary>
        /// 创建房间图片
        /// </summary>
        /// <param name="RoomImages"></param>
        /// <returns></returns>
        void AddRoomImage(Guid roomId, List<RoomImage> RoomImages);

        /// <summary>
        /// 更新房间图片
        /// </summary>
        /// <param name="RoomImages"></param>
        /// <returns></returns>
        List<RoomImage> UpdateRoomImage(Guid roomId, List<RoomImage> RoomImages);

        /// <summary>
        /// 删除房间图片
        /// </summary>
        /// <param name="ids">需要删除的房间图片id值</param>
        void DeleteRoomImage(Guid roomId, List<string> ids);



        /// <summary>
        /// 根据房间图片id获取房间图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        RoomImage GetRoomImageByKey(Guid roomId, Guid id);


        /// <summary>
        /// 根据房间id获取房间图片
        /// </summary>
        /// <param name="RoomId"></param>
        /// <returns></returns>
        List<RoomImage> GetRoomImagesByRoomId(Guid roomId);

        /// <summary>
        /// 根据房间名称获取房间图片
        /// </summary>
        /// <param name="RoomName"></param>
        /// <returns></returns>
        List<RoomImage> GetRoomImagesByRoomName(string roomName);

        #endregion
    }
}
