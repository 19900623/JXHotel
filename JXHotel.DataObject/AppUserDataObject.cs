using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace JXHotel.DataObject
{
    /// <summary>
    /// 应用平台用户
    /// </summary>
    [DataContract]
    public class AppUserDataObject : UserDataObject
    {
        /// <summary>
        /// 角色Id
        /// </summary>
        [DataMember]
        public Guid AppRoleId { get; set; }

        //public virtual AppRole AppRole { get; set; } 



    }
}
