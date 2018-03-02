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
    /// 实体转换为DTO
    /// </summary>
  public  class MMapDoProfile :Profile
    {
        public MMapDoProfile()
        {
            CreateMap<Address, AddressDataObject>();
            CreateMap<AppAccount, AppAccountDataObject>();
            CreateMap<AppRole, AppRoleDataObject>();
            CreateMap<AppUser, AppUserDataObject>();
            CreateMap<CustomerAccount, CustomerAccountDataObject>();
            CreateMap<Customer, CustomerDataObject>();
            CreateMap<CustomerRole, CustomerRoleDataObject>();
            CreateMap<DiscountPromotion, DiscountPromotionDataObject>();
            CreateMap<HotelAccount, HotelAccountDataObject>();
            CreateMap<HotelCategory, HotelCategoryDataObject>();
            CreateMap<HotelComment, HotelCommentDataObject>();
            CreateMap<Hotel, HotelDataObject>();
            CreateMap<HotelImage, HotelImageDataObject>();
            CreateMap<HotelRole, HotelRoleDataObject>();
            CreateMap<HotelRoomCategory, HotelRoomCategoryDataObject>();
            CreateMap<HotelUser, HotelUserDataObject>();
            CreateMap<OverGivePromotion, OverGivePromotionDataObject>();
            CreateMap<OverMinusPromotion, OverMinusPromotionDataObject>();
            CreateMap<PromotionImage, PromotionImageDataObject>();
            CreateMap<Reservation, ReservationDataObject>();
            CreateMap<ReservationStatus, ReservationStatusDataObject>();
            CreateMap<Room, RoomDataObject>();
            CreateMap<RoomImage, RoomImageDataObject>();
        }
    }
}
