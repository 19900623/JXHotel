using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.DataObject;

namespace JXHotel.Application.Contract
{
    /// <summary>
    /// 酒单房间应用层
    /// </summary>
    public interface IRoomService
    {
        #region 房间
        /// <summary>
        /// 创建房间
        /// </summary>
        /// <param name="RoomDataObject"></param>
        /// <returns></returns>
        List<RoomDataObject> CreateRoom(List<RoomDataObject> RoomDataObject);

        /// <summary>
        /// 获取所有房间
        /// </summary>
        /// <param name="spec">查询方式</param>
        /// <returns></returns>
        List<RoomDataObject> GetRooms(QuerySpec spec);


        /// <summary>
        /// 根据Id值获取房间
        /// </summary>
        /// <param name="Id">id值</param>
        /// <param name="spec">查询方式</param>
        /// <returns></returns>
        RoomDataObject GetRoomByKey(Guid Id, QuerySpec spec);

        /// <summary>
        /// 根据房间名称获取房间
        /// </summary>
        /// <param name="name">房间名称</param>
        /// <param name="spec">查询方式</param>
        /// <returns></returns>
        RoomDataObject GetRoomByName(string name, QuerySpec spec);

        /// <summary>
        /// 删除房间
        /// </summary>
        /// <param name="ids">需要删除的房间</param>
        void DeleteRoom(List<string> ids);

        /// <summary>
        /// 更新房间信息
        /// </summary>
        /// <param name="RoomDataObject">需要更新的房间</param>
        /// <returns></returns>
        List<RoomDataObject> UpdateRoom(List<RoomDataObject> RoomDataObject);

        #endregion

        #region 房间分类
        /// <summary>
        /// 创建房间分类
        /// </summary>
        /// <param name="RoomCategoryDataObject">需要创建的分类</param>
        /// <returns></returns>
        List<HotelRoomCategoryDataObject> CreateHotelRoomCategory(List<HotelRoomCategoryDataObject> HotelRoomCategoryDataObject);

        /// <summary>
        /// 获取所有房间分类信息
        /// </summary>
        /// <returns></returns>
        List<HotelRoomCategoryDataObject> GetHotelRoomCategorys();

        /// <summary>
        /// 根据分类Id值获取分类信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        HotelRoomCategoryDataObject GetHotelRoomCategoryByKey(Guid Id);

        /// <summary>
        /// 根据分类名称获取分类信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        HotelRoomCategoryDataObject GetHotelRoomCategoryByName(string name);

        /// <summary>
        /// 根据房间名称获取房间分类
        /// </summary>
        /// <param name="RoomName"></param>
        /// <returns></returns>
        HotelRoomCategoryDataObject GetHotelRoomCategoryByRoomName(string RoomName);


        /// <summary>
        /// 更新房间分类
        /// </summary>
        /// <param name="HotelRoomCategoryDataObject"></param>
        /// <returns></returns>
        List<HotelRoomCategoryDataObject> UpdateHotelRoomCategory(List<HotelRoomCategoryDataObject> HotelRoomCategoryDataObject);

        /// <summary>
        /// 删除房间分类
        /// </summary>
        /// <param name="ids">需要删除房间分类的id值</param>
        void DeleteHotelRoomCategory(List<string> ids);

        /// <summary>
        /// 将房间指向分类
        /// </summary>
        /// <param name="RoomID"></param>
        /// <param name="categoryID"></param>
        void AssignCategory(Guid RoomID, Guid categoryID);


        #endregion

        #region 房间图片
        /// <summary>
        /// 创建房间图片
        /// </summary>
        /// <param name="RoomImageDataObject"></param>
        /// <returns></returns>
        void AddRoomImage(Guid roomId, List<RoomImageDataObject> RoomImageDataObject);

        /// <summary>
        /// 更新房间图片
        /// </summary>
        /// <param name="RoomImageDataObject"></param>
        /// <returns></returns>
        List<RoomImageDataObject> UpdateRoomImage(Guid roomId, List<RoomImageDataObject> RoomImageDataObject);

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
        RoomImageDataObject GetRoomImageByKey(Guid roomId, Guid id);


        /// <summary>
        /// 根据房间id获取房间图片
        /// </summary>
        /// <param name="RoomId"></param>
        /// <returns></returns>
        List<RoomImageDataObject> GetRoomImagesByRoomId(Guid roomId);

        /// <summary>
        /// 根据房间名称获取房间图片
        /// </summary>
        /// <param name="RoomName"></param>
        /// <returns></returns>
        List<RoomImageDataObject> GetRoomImagesByRoomName(string roomName);

        #endregion

        #region 房间预定
        /// <summary>
        /// 根据房间名称获取预定
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        List<ReservationDataObject> GetReservationsByRoomName(string roomName);
        #endregion
    }
}
