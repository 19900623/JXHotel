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
    /// 满减优惠活动应用层
    /// </summary>
    public class OverMinusPromotionSerivice : HotelPromotionService<OverMinusPromotionDataObject, OverMinusPromotion>, IOverMinusPromotionSerivice
    {
        public OverMinusPromotionSerivice(IRepositoryContext context
                                          , IOverMinusPromotionRepository hotelPromotionRepository
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
