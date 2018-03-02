using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.DataObject;

namespace JXHotel.Application.Contract
{
    /// <summary>
    /// 酒店用户应用层
    /// </summary>
  public  interface IHotelUserService :IUserService<HotelUserDataObject,HotelRoleDataObject>
    {   
        /// <summary>
        /// 根据用户名获取酒店
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <returns></returns>
        HotelDataObject GetHotelByName(string userName);


        /// <summary>
        /// 根据用户ID值获取酒店
        /// </summary>
        /// <param name="UserId">用户Id值</param>
        /// <returns></returns>
        HotelDataObject GetHotelById(Guid UserId);

    }
}
