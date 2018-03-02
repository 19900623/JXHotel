using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;

namespace JXHotel.Domain.Service
{
    /// <summary>
    /// 酒店用户与酒店用户角色聚合服务接口
    /// </summary>
  public  interface IHotelUserRoleService  :IUserRoleService<HotelUser,HotelRole>
    {

    }
}
