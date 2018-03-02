using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Application.Contract;
using JXHotel.Domain.Repository;
using JXHotel.Domain.Model;
using JXHotel.Domain.Specification;
using JXHotel.Domain.Service;
using JXHotel.DataObject;

namespace JXHotel.Application.Imp
{
    /// <summary>
    /// 酒店房间应用层
    /// </summary>
    public class RoomService : ApplicationService,IRoomService
    {
        private readonly IRoomRepository roomRepository;
        private readonly IHotelRoomCategoryRepository hotelRoomCategoryRepository;
        private readonly IReservationRepository reservationRepository;
        private readonly IHotelRoomCategoryService hotelRoomCategoryService;

        public RoomService(IRepositoryContext context, IRoomRepository roomRepository
                                                     , IHotelRoomCategoryRepository hotelRoomCategoryRepository
                                                     , IReservationRepository reservationRepository
                                                     , IHotelRoomCategoryService hotelRoomCategoryService) : base(context)
        {
            this.roomRepository = roomRepository;
            this.hotelRoomCategoryRepository = hotelRoomCategoryRepository;
            this.reservationRepository = reservationRepository;
            this.hotelRoomCategoryService= hotelRoomCategoryService;
        }


        #region 房间
        /// <summary>
        /// 创建房间
        /// </summary>
        /// <param name="RoomDataObject"></param>
        /// <returns></returns>
        public List<RoomDataObject> CreateRoom(List<RoomDataObject> RoomDataObject)
        {
            return this.PerformCreateObjects<List<RoomDataObject>, RoomDataObject, Room>(RoomDataObject, roomRepository);
        }

        /// <summary>
        /// 获取所有房间
        /// </summary>
        /// <param name="spec">查询方式</param>
        /// <returns></returns>
        public List<RoomDataObject> GetRooms(QuerySpec spec)
        {
            IEnumerable<Room> rooms;
            if (!spec.Verbose)
            {
                rooms = roomRepository.FindAll();
            }
            else
            {
                rooms = roomRepository.FindAll(new AnySpecification<Room>(), r=>r.HotelRoomCategory );
            }
            List<RoomDataObject> RoomDataObjects = AutoMapper.Mapper.Map<List<Room>, List<RoomDataObject>>(rooms.ToList());
            return RoomDataObjects;
        }


        /// <summary>
        /// 根据Id值获取房间
        /// </summary>
        /// <param name="Id">id值</param>
        /// <param name="spec">查询方式</param>
        /// <returns></returns>
        public RoomDataObject GetRoomByKey(Guid Id, QuerySpec spec)
        {
            Room room;
            if (!spec.Verbose)
            {
                room = roomRepository.GetByKey(Id);
            }
            else
            {
                room = roomRepository.Find(Specification<Room>.Eval(r => r.Id.Equals(Id)), h => h.HotelRoomCategory);

            }
            return AutoMapper.Mapper.Map<Room, RoomDataObject>(room);
        }

        /// <summary>
        /// 根据房间名称获取房间
        /// </summary>
        /// <param name="name">房间名称</param>
        /// <param name="spec">查询方式</param>
        /// <returns></returns>
        public RoomDataObject GetRoomByName(string name, QuerySpec spec)
        {
            Room room;
            if (!spec.Verbose)
            {
                room = roomRepository.Find(Specification<Room>.Eval(h => h.Name.Equals(name)));
            }
            else
            {
                room = roomRepository.Find(Specification<Room>.Eval(h => h.Name.Equals(name)), r => r.HotelRoomCategory);

            }
            return AutoMapper.Mapper.Map<Room, RoomDataObject>(room);
        }

        /// <summary>
        /// 删除房间
        /// </summary>
        /// <param name="ids">需要删除的房间</param>
        public void DeleteRoom(List<string> ids)
        {
            this.PerformDeleteObjects<Room>(ids, roomRepository);
        }

        /// <summary>
        /// 更新房间信息
        /// </summary>
        /// <param name="RoomDataObject">需要更新的房间</param>
        /// <returns></returns>
        public List<RoomDataObject> UpdateRoom(List<RoomDataObject> RoomDataObject)
        {
            return this.PerformUpdateObjects<List<RoomDataObject>, RoomDataObject, Room>(RoomDataObject, roomRepository
                                                                                           , dto => dto.Id.ToString(), null);
        }

        #endregion

        #region 房间分类
        /// <summary>
        /// 创建房间分类
        /// </summary>
        /// <param name="RoomCategoryDataObject">需要创建的分类</param>
        /// <returns></returns>
        public List<HotelRoomCategoryDataObject> CreateHotelRoomCategory(List<HotelRoomCategoryDataObject> HotelRoomCategoryDataObject)
        {
            return this.PerformCreateObjects<List<HotelRoomCategoryDataObject>, HotelRoomCategoryDataObject, HotelRoomCategory>(HotelRoomCategoryDataObject, hotelRoomCategoryRepository);
        }

        /// <summary>
        /// 获取所有房间分类信息
        /// </summary>
        /// <returns></returns>
        public List<HotelRoomCategoryDataObject> GetHotelRoomCategorys()
        {
            List<HotelRoomCategory> listHotelRoomCategory = hotelRoomCategoryRepository.FindAll().ToList();
            return AutoMapper.Mapper.Map<List<HotelRoomCategory>, List<HotelRoomCategoryDataObject>>(listHotelRoomCategory);
        }

        /// <summary>
        /// 根据分类Id值获取分类信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public HotelRoomCategoryDataObject GetHotelRoomCategoryByKey(Guid Id)
        {
            HotelRoomCategory HotelRoomCategory = hotelRoomCategoryRepository.GetByKey(Id);
            return AutoMapper.Mapper.Map<HotelRoomCategory, HotelRoomCategoryDataObject>(HotelRoomCategory);
        }

        /// <summary>
        /// 根据分类名称获取分类信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public HotelRoomCategoryDataObject GetHotelRoomCategoryByName(string name)
        {
            HotelRoomCategory HotelRoomCategory = hotelRoomCategoryRepository.Find(Specification<HotelRoomCategory>.Eval(h => h.Name.Equals(name)));
            return AutoMapper.Mapper.Map<HotelRoomCategory, HotelRoomCategoryDataObject>(HotelRoomCategory);
        }

        /// <summary>
        /// 根据房间名称获取房间分类
        /// </summary>
        /// <param name="RoomName"></param>
        /// <returns></returns>
        public HotelRoomCategoryDataObject GetHotelRoomCategoryByRoomName(string RoomName)
        {
            HotelRoomCategory hotelRoomCategory = hotelRoomCategoryRepository.GetHotelRoomCategoryByRoomName(RoomName);
            return AutoMapper.Mapper.Map<HotelRoomCategory, HotelRoomCategoryDataObject>(hotelRoomCategory);
        }


        /// <summary>
        /// 更新房间分类
        /// </summary>
        /// <param name="HotelRoomCategoryDataObject"></param>
        /// <returns></returns>
        public List<HotelRoomCategoryDataObject> UpdateHotelRoomCategory(List<HotelRoomCategoryDataObject> HotelRoomCategoryDataObject)
        {
            return this.PerformUpdateObjects<List<HotelRoomCategoryDataObject>, HotelRoomCategoryDataObject, HotelRoomCategory>(HotelRoomCategoryDataObject, hotelRoomCategoryRepository
                                                                                                           , dto => dto.Id.ToString(), null);
        }

        /// <summary>
        /// 删除房间分类
        /// </summary>
        /// <param name="ids">需要删除房间分类的id值</param>
        public void DeleteHotelRoomCategory(List<string> ids)
        {
            this.PerformDeleteObjects<HotelRoomCategory>(ids, hotelRoomCategoryRepository);
        }

        /// <summary>
        /// 将房间指向分类
        /// </summary>
        /// <param name="RoomID"></param>
        /// <param name="categoryID"></param>
        public void AssignCategory(Guid RoomID, Guid categoryID)
        {
            hotelRoomCategoryService.AssignCategory(RoomID, categoryID);
        }



        #endregion

        #region 房间图片
        /// <summary>
        /// 创建房间图片
        /// </summary>
        /// <param name="RoomImageDataObject"></param>
        /// <returns></returns>
        public void AddRoomImage(Guid roomId,List<RoomImageDataObject> RoomImageDataObject)
        {
            List<RoomImage> listRoomImage = AutoMapper.Mapper.Map<List<RoomImageDataObject>, List<RoomImage>>(RoomImageDataObject);
            roomRepository.AddRoomImage(roomId, listRoomImage);
        }

        /// <summary>
        /// 更新房间图片
        /// </summary>
        /// <param name="RoomImageDataObject"></param>
        /// <returns></returns>
        public List<RoomImageDataObject> UpdateRoomImage(Guid roomId, List<RoomImageDataObject> RoomImageDataObject)
        {
            List<RoomImage> listRoomImage = AutoMapper.Mapper.Map<List<RoomImageDataObject>, List<RoomImage>>(RoomImageDataObject);
            List<RoomImage> updatelistRoomImage=   roomRepository.UpdateRoomImage(roomId, listRoomImage);
            return AutoMapper.Mapper.Map<List<RoomImage>, List<RoomImageDataObject>>(updatelistRoomImage);
        }

        /// <summary>
        /// 删除房间图片
        /// </summary>
        /// <param name="ids">需要删除的房间图片id值</param>
        public void DeleteRoomImage(Guid roomId, List<string> ids)
        {
            roomRepository.DeleteRoomImage(roomId, ids);
        }

       

        /// <summary>
        /// 根据房间图片id获取房间图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RoomImageDataObject GetRoomImageByKey(Guid roomId, Guid id)
        {
            RoomImage roomImage = roomRepository.GetRoomImageByKey(roomId, id);
            return AutoMapper.Mapper.Map<RoomImage, RoomImageDataObject>(roomImage);
        }


        /// <summary>
        /// 根据房间id获取房间图片
        /// </summary>
        /// <param name="RoomId"></param>
        /// <returns></returns>
        public List<RoomImageDataObject> GetRoomImagesByRoomId(Guid roomId)
        {
            List<RoomImage> listRoomImage = roomRepository.GetRoomImagesByRoomId(roomId);
            return AutoMapper.Mapper.Map<List<RoomImage>, List<RoomImageDataObject>>(listRoomImage);
        }

        /// <summary>
        /// 根据房间名称获取房间图片
        /// </summary>
        /// <param name="RoomName"></param>
        /// <returns></returns>
        public List<RoomImageDataObject> GetRoomImagesByRoomName(string roomName)
        {
            List<RoomImage> listRoomImage = roomRepository.GetRoomImagesByRoomName(roomName);
            return AutoMapper.Mapper.Map<List<RoomImage>, List<RoomImageDataObject>>(listRoomImage);
        }

        #endregion

        #region 房间预定
        /// <summary>
        /// 根据房间名称获取预定
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        public List<ReservationDataObject> GetReservationsByRoomName(string roomName)
        {
            List<Reservation> listReservation = reservationRepository.GetReservationsByRoomName(roomName);
            return AutoMapper.Mapper.Map<List<Reservation>, List<ReservationDataObject>>(listReservation);
        }
        #endregion



    }
}
