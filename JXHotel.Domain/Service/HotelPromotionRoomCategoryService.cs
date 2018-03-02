using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Repository;
using JXHotel.Domain.Model;

namespace JXHotel.Domain.Service
{
    /// <summary>
    /// 活动与房间分类聚合服务
    /// </summary>
    public class HotelPromotionRoomCategoryService : IHotelPromotionRoomCategoryService
    {

        private readonly IRepositoryContext repositoryContext;
        private readonly IHotelRoomCategoryRepository hotelRoomCategoryRepository;
        private readonly IHotelPromotionRepository<HotelPromotion> hotelPromotionRepository;

        public HotelPromotionRoomCategoryService(IRepositoryContext repositoryContext, IHotelRoomCategoryRepository hotelRoomCategoryRepository
                                                                                      , IHotelPromotionRepository<HotelPromotion> hotelPromotionRepository)
        {
            this.repositoryContext = repositoryContext;
            this.hotelRoomCategoryRepository = hotelRoomCategoryRepository;
            this.hotelPromotionRepository = hotelPromotionRepository;
        }

        /// <summary>
        /// 将活动指向房间分类
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <param name="HotelRoomCategoryID"></param>
        public void AssignHotelRoomCategory(Guid hotelPromotionId, Guid HotelRoomCategoryID)
        {
            HotelPromotion hotelPromotion = hotelPromotionRepository.GetByKey(hotelPromotionId);
            HotelRoomCategory hotelRoomCategory = hotelRoomCategoryRepository.GetByKey(HotelRoomCategoryID);
            hotelPromotion.HotelRoomCategorys.Add(hotelRoomCategory);
            hotelPromotionRepository.Update(hotelPromotion);
            repositoryContext.Commit();
        }

        /// <summary>
        /// 将活动从房间分类中移除
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <param name="HotelRoomCategoryID"></param>
        public void UnassignHotelRoomCategory(Guid hotelPromotionId, Guid HotelRoomCategoryID)
        {
            HotelPromotion hotelPromotion = hotelPromotionRepository.GetByKey(hotelPromotionId);
            HotelRoomCategory hotelRoomCategory = hotelRoomCategoryRepository.GetByKey(HotelRoomCategoryID);
            hotelPromotion.HotelRoomCategorys.Add(hotelRoomCategory);
            hotelPromotionRepository.Remove(hotelPromotion);
            repositoryContext.Commit();
        }
    }
}
