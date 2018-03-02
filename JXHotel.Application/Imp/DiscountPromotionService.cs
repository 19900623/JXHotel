using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Application.Contract;
using JXHotel.Domain.Model;
using JXHotel.DataObject;
using JXHotel.Domain.Repository;
using JXHotel.Domain.Service;

namespace JXHotel.Application.Imp
{
    /// <summary>
    /// 折扣优惠活动应用层
    /// </summary>
    public class DiscountPromotionService : HotelPromotionService<DiscountPromotionDataObject, DiscountPromotion>, IDiscountPromotionService
    {
        public DiscountPromotionService(IRepositoryContext context
                                          , IDiscountPromotionRepository hotelPromotionRepository
                                          , IHotelRepository hotelRepository
                                          , ICustomerRoleRepository customerRoleRepository
                                          , IHotelRoomCategoryRepository hotelRoomCategoryRepository
                                          , IHotelPromotionCustomerRoleService hotelPromotionCustomerRoleService
                                          , IHotelPromotionRoomCategoryService hotelPromotionRoomCategoryService) 
                                      : base(context
                                              , hotelPromotionRepository
                                              , hotelRepository
                                              , customerRoleRepository
                                              , hotelRoomCategoryRepository
                                              , hotelPromotionCustomerRoleService
                                              , hotelPromotionRoomCategoryService)
        {

        }
    }
}
