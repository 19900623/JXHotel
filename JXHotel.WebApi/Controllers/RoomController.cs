using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JXHotel.Infrastructure;
using JXHotel.Application.Contract;
using JXHotel.Application;
using JXHotel.DataObject;
using Newtonsoft.Json;

namespace JXHotel.WebApi.Controllers
{
    public class RoomController : ApiController
    {
        private readonly IRoomService roomServiceImp = ServiceLocator.Instance.GetService<IRoomService>();



        #region 房间
        /// <summary>
        /// 创建房间
        /// </summary>
        /// <param name="RoomDataObject"></param>
        /// <returns></returns>
        public string  Post(List<RoomDataObject> RoomDataObject)
        {
            var rooms = roomServiceImp.CreateRoom(RoomDataObject);
            return JsonConvert.SerializeObject(rooms);
        }

        /// <summary>
        /// 获取所有房间
        /// </summary>
        /// <returns></returns>
        public string Get()
        {
            var rooms = roomServiceImp.GetRooms(QuerySpec.Empty);
            return JsonConvert.SerializeObject(rooms);
        }


        /// <summary>
        /// 根据Id值获取房间
        /// </summary>
        /// <param name="Id">id值</param>
        /// <returns></returns>
        public string GetByKey(string  Id)
        {
            var room = roomServiceImp.GetRoomByKey(new Guid(Id),QuerySpec.Empty);
            return JsonConvert.SerializeObject(room);
        }

        /// <summary>
        /// 根据房间名称获取房间
        /// </summary>
        /// <param name="name">房间名称</param>
        /// <returns></returns>
        public string GetByName(string name)
        {
            var room = roomServiceImp.GetRoomByName(name, QuerySpec.Empty);
            return JsonConvert.SerializeObject(room);
        }

        /// <summary>
        /// 删除房间
        /// </summary>
        /// <param name="ids">需要删除的房间</param>
       public  void Delete(List<string> ids)
        {
            roomServiceImp.DeleteRoom(ids);
        }

        /// <summary>
        /// 更新房间信息
        /// </summary>
        /// <param name="RoomDataObject">需要更新的房间</param>
        /// <returns></returns>
        public string Put(List<RoomDataObject> RoomDataObject)
        {

            var rooms = roomServiceImp.UpdateRoom(RoomDataObject);
            return JsonConvert.SerializeObject(rooms);
        }

        #endregion

        #region 房间分类
        /// <summary>
        /// 创建房间分类
        /// </summary>
        /// <param name="RoomCategoryDataObject">需要创建的分类</param>
        /// <returns></returns>
        public string PostHotelRoomCategory(List<HotelRoomCategoryDataObject> HotelRoomCategoryDataObject)
        {
            var categorys = roomServiceImp.CreateHotelRoomCategory(HotelRoomCategoryDataObject);
            return JsonConvert.SerializeObject(categorys);
        }

        /// <summary>
        /// 获取所有房间分类信息
        /// </summary>
        /// <returns></returns>
        public string GetHotelRoomCategorys()
        {
            var categorys = roomServiceImp.GetHotelRoomCategorys();
            return JsonConvert.SerializeObject(categorys);
        }

        /// <summary>
        /// 根据分类Id值获取分类信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string GetHotelRoomCategoryByKey(string  Id)
        {
            var category = roomServiceImp.GetHotelRoomCategoryByKey(new Guid(Id));
            return JsonConvert.SerializeObject(category);
        }

        /// <summary>
        /// 根据分类名称获取分类信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string  GetHotelRoomCategoryByName(string name)
        {
            var category = roomServiceImp.GetHotelRoomCategoryByName(name);
            return JsonConvert.SerializeObject(category);
        }

        /// <summary>
        /// 根据房间名称获取房间分类
        /// </summary>
        /// <param name="RoomName"></param>
        /// <returns></returns>
        public string GetHotelRoomCategoryByRoomName(string RoomName)
        {
            var category = roomServiceImp.GetHotelRoomCategoryByRoomName(RoomName);
            return JsonConvert.SerializeObject(category);
        }


        /// <summary>
        /// 更新房间分类
        /// </summary>
        /// <param name="HotelRoomCategoryDataObject"></param>
        /// <returns></returns>
        public string PutHotelRoomCategory(List<HotelRoomCategoryDataObject> HotelRoomCategoryDataObject)
        {
            var categorys = roomServiceImp.UpdateHotelRoomCategory(HotelRoomCategoryDataObject);
            return JsonConvert.SerializeObject(categorys);
        }

        /// <summary>
        /// 删除房间分类
        /// </summary>
        /// <param name="ids">需要删除房间分类的id值</param>
        public  void DeleteHotelRoomCategory(List<string> ids)
        {
            roomServiceImp.DeleteHotelRoomCategory(ids);
        }

        /// <summary>
        /// 将房间指向分类
        /// </summary>
        /// <param name="RoomID"></param>
        /// <param name="categoryID"></param>
        public  void PutAssignCategory(string  RoomID, string  categoryID)
        {
            roomServiceImp.AssignCategory(new Guid(RoomID), new Guid(categoryID));
        }


        #endregion

        #region 房间图片
        /// <summary>
        /// 创建房间图片
        /// </summary>
        /// <param name="RoomImageDataObject"></param>
        /// <returns></returns>
        public  void PostRoomImage(string  roomId, List<RoomImageDataObject> RoomImageDataObject)
        {
            roomServiceImp.AddRoomImage(new Guid(roomId), RoomImageDataObject);
        }

        /// <summary>
        /// 更新房间图片
        /// </summary>
        /// <param name="RoomImageDataObject"></param>
        /// <returns></returns>
        public string PutRoomImage(string  roomId, List<RoomImageDataObject> RoomImageDataObject)
        {
            var roomImages = roomServiceImp.UpdateRoomImage(new Guid(roomId), RoomImageDataObject);
            return JsonConvert.SerializeObject(roomImages);
        }

        /// <summary>
        /// 删除房间图片
        /// </summary>
        /// <param name="ids">需要删除的房间图片id值</param>
        public  void DeleteRoomImage(string  roomId, List<string> ids)
        {
            roomServiceImp.DeleteRoomImage(new Guid(roomId), ids);
        }



        /// <summary>
        /// 根据房间图片id获取房间图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetRoomImageByKey(string  roomId, string  id)
        {
            var roomImage = roomServiceImp.GetRoomImageByKey(new Guid(roomId), new Guid(id));
            return JsonConvert.SerializeObject(roomImage);
        }


        /// <summary>
        /// 根据房间id获取房间图片
        /// </summary>
        /// <param name="RoomId"></param>
        /// <returns></returns>
        public string GetRoomImagesByRoomId(string  roomId)
        {
            var roomImages = roomServiceImp.GetRoomImagesByRoomId(new Guid(roomId));
            return JsonConvert.SerializeObject(roomImages);
        }

        /// <summary>
        /// 根据房间名称获取房间图片
        /// </summary>
        /// <param name="RoomName"></param>
        /// <returns></returns>
        public string GetRoomImagesByRoomName(string roomName)
        {
            var roomImages = roomServiceImp.GetRoomImagesByRoomName(roomName);
            return JsonConvert.SerializeObject(roomImages);
        }

        #endregion

        #region 房间预定
        /// <summary>
        /// 根据房间名称获取预定
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        public string GetReservationsByRoomName(string roomName)
        {
            var reservations = roomServiceImp.GetReservationsByRoomName(roomName);
            return JsonConvert.SerializeObject(reservations);
        }
        #endregion
    }
}
