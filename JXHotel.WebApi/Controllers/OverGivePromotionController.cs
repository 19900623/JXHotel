using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JXHotel.DataObject;
using JXHotel.Infrastructure;
using JXHotel.Application.Contract;

namespace JXHotel.WebApi.Controllers
{
    public class OverGivePromotionController : HotelPromotionController<OverGivePromotionDataObject>
    {
        public OverGivePromotionController()
        {
            this.hotelPromotionServiceImp = ServiceLocator.Instance.GetService<IOverGivePromotionService>();
        }
    }
}