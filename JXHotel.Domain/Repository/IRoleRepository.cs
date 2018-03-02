using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;

namespace JXHotel.Domain.Repository
{
  public  interface IRoleRepository<TRole,TUser> : IRepository<TRole>  where TRole:Role  where TUser:User
    {
        /// <summary>
        /// 根据指定的用户，获取该用户所属的角色。
        /// </summary>
        /// <param name="user">用户。</param>
        /// <returns>角色。</returns>
        TRole GetRoleForUser(TUser user);
    }
}
