using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JXHotel.DataObject;
using JXHotel.Infrastructure;
using JXHotel.Application.Contract;

namespace JXHotel.WebApi.Controllers
{
    public class DiscountPromotionController :HotelPromotionController<DiscountPromotionDataObject>
    {
        public DiscountPromotionController()
        {
            this.hotelPromotionServiceImp = ServiceLocator.Instance.GetService<IDiscountPromotionService>();
        }

        //protected override IHotelPromotionService<DiscountPromotionDataObject> hotelPromotionServiceImp
        //{
        //     get
        //    {
        //        return ServiceLocator.Instance.GetService<IDiscountPromotionService>();
        //    }
        //}
    }
}