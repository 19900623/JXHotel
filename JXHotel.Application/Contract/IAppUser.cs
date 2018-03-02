using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.DataObject;

namespace JXHotel.Application.Contract
{
    /// <summary>
    /// app用户应用层
    /// </summary>
   public interface IAppUserUserService : IUserService<AppUserDataObject,AppRoleDataObject>
    {

    }
}
