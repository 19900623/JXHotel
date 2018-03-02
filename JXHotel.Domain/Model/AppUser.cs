using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 应用平台用户
    /// </summary>
   public class AppUser:User
    {

        public AppUser()
        {
            //AppAccounts = new HashSet<AppAccount>();
        }
        /// <summary>
        /// 角色Id
        /// </summary>
        public Guid AppRoleId { get; set; }

        public virtual AppRole AppRole { get; set; }


       
    }
}
