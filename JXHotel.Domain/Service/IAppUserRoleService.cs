using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;

namespace JXHotel.Domain.Service
{
    /// <summary>
    /// appuser聚合与appuserrole聚合服务接口
    /// </summary>
 public   interface IAppUserRoleService  :IUserRoleService<AppUser,AppRole>
    {

    }
}
