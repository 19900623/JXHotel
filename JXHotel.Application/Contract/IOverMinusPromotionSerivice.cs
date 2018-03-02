using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.DataObject;

namespace JXHotel.Application.Contract
{
    /// <summary>
    /// 满减优惠活动应用层接口
    /// </summary>
  public  interface IOverMinusPromotionSerivice :IHotelPromotionService<OverMinusPromotionDataObject>
    {
    }
}
