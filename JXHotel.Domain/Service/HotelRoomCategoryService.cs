using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;
using JXHotel.Domain.Repository;

namespace JXHotel.Domain.Service
{
    /// <summary>
    /// 酒店房间与房间分类聚合服务接口
    /// </summary>
    public class HotelRoomCategoryService :IHotelRoomCategoryService
    {

        private readonly IRepositoryContext repositoryContext;
        private readonly IRoomRepository roomRepository;
        private readonly IHotelRoomCategoryRepository hotelRoomCategoryRepository;
        public HotelRoomCategoryService(IRepositoryContext repositoryContext, IRoomRepository roomRepository
                                                                          , IHotelRoomCategoryRepository hotelRoomCategoryRepository)
        {
            this.repositoryContext = repositoryContext;
            this.roomRepository = roomRepository;
            this.hotelRoomCategoryRepository = hotelRoomCategoryRepository;
        }

        /// <summary>
        /// 将房间指向分类
        /// </summary>
        /// <param name="RoomID"></param>
        /// <param name="categoryID"></param>
       public void AssignCategory(Guid RoomID, Guid categoryID)
        {
            Room room = roomRepository.GetByKey(RoomID);
            //HotelRoomCategory hotelRoomCategory = hotelRoomCategoryRepository.GetByKey(categoryID);
            room.HotelRoomCategoryId= categoryID;
            roomRepository.Update(room);
            repositoryContext.Commit();
        }

    }
}
