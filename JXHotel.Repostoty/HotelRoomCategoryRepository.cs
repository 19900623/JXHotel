using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;
using JXHotel.Domain.Repository;
using JXHotel.Repository.Specification;

namespace JXHotel.Repository
{
    public class HotelRoomCategoryRepository : EntityFrameworkRepository<HotelRoomCategory>, IHotelRoomCategoryRepository
    {
        public HotelRoomCategoryRepository(IRepositoryContext context) : base(context)
        {

        }

        /// <summary>
        /// 根据活动id获取房间分类
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <returns></returns>
       public List<HotelRoomCategory> GetHotelRoomCategoryByHotelPromotionId(Guid hotelPromotionId)
        {
            var context = this.EFContext.dbContext as JXHotelDbContext;
            return context.HotelPromotions.Find(hotelPromotionId).HotelRoomCategorys.ToList();
        }

        /// <summary>
        /// 根据活动名称获取房间分类
        /// </summary>
        /// <param name="hotelPromotionName"></param>
        /// <returns></returns>
       public List<HotelRoomCategory> GetHotelRoomCategoryByHotelPromotionName(string hotelPromotionName)
        {
            var context = this.EFContext.dbContext as JXHotelDbContext;
            return context.HotelPromotions.Where(new HotelPromotionNameEqualSpecification(hotelPromotionName).GetExpression()).FirstOrDefault().HotelRoomCategorys;
        }


        /// <summary>
        /// 根据房间名称获取房间分类
        /// </summary>
        /// <param name="RoomName"></param>
        /// <returns></returns>
      public  HotelRoomCategory GetHotelRoomCategoryByRoomName(string RoomName)
        {
            var context = EFContext.dbContext as JXHotelDbContext;
            Room room = context.Rooms.Where(new RoomNameEqualSpecification(RoomName).GetExpression()).FirstOrDefault();
            return room.HotelRoomCategory;
        }
    }
}
