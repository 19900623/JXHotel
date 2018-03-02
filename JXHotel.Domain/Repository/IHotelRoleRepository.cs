using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;

namespace JXHotel.Domain.Repository
{
    /// <summary>
    /// 酒店用户角色仓储接口
    /// </summary>
   public interface IHotelRoleRepository  :IRoleRepository<HotelRole,HotelUser>
    {

    }
}
