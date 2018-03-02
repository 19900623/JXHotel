using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JXHotel.Domain.Model;
using JXHotel.DataObject;
namespace JXHotel.Application.Mapper
{
    /// <summary>
    /// DOT转换Model
    /// </summary>
  public  class DoMapMProfile :Profile
    {
        public DoMapMProfile()
        {
            CreateMap<AddressDataObject, Address>();
            CreateMap<AppAccountDataObject, AppAccount>();
            CreateMap<AppRoleDataObject, AppRole>();
            CreateMap<AppUserDataObject, AppUser>();
            CreateMap<CustomerAccountDataObject, CustomerAccount>();
            CreateMap<CustomerDataObject, Customer>();
            CreateMap<CustomerRoleDataObject, CustomerRole>();
            CreateMap<DiscountPromotionDataObject, DiscountPromotion>();
            CreateMap<HotelAccountDataObject, HotelAccount>();
            CreateMap<HotelCategoryDataObject, HotelCategory>();
            CreateMap<HotelCommentDataObject, HotelComment>();
            CreateMap<HotelDataObject, Hotel>();
            CreateMap<HotelImageDataObject, HotelImage>();
            CreateMap<HotelRoleDataObject, HotelRole>();
            CreateMap<HotelRoomCategoryDataObject, HotelRoomCategory>();
            CreateMap<HotelUserDataObject, HotelUser>();
            CreateMap<OverGivePromotionDataObject, OverGivePromotion>();
            CreateMap<OverMinusPromotionDataObject, OverMinusPromotion>();
            CreateMap<PromotionImageDataObject, PromotionImage>();
            CreateMap<ReservationDataObject, Reservation>();
            CreateMap<ReservationStatusDataObject, ReservationStatus>();
            CreateMap<RoomDataObject, Room>();
            CreateMap<RoomImageDataObject, RoomImage>();
        }
    }
}
