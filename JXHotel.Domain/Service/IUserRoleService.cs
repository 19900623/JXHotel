using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;

namespace JXHotel.Domain.Service
{
   public   interface IUserRoleService<TUser,TRole> where  TUser:User where  TRole:Role
    {
        void AssignRole(Guid userID, Guid roleID);

     
    }
}
