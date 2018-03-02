using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;

namespace JXHotel.Domain.Repository
{
    /// <summary>
    /// 酒店分类仓储接口
    /// </summary>
  public  interface IHotelCategoryRepository  :IRepository<HotelCategory>
    {
        /// <summary>
        /// 根据酒店名称获取酒店分类
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        List<HotelCategory> GetHotelCategoryByHotelName(string hotelName);
    }
}
