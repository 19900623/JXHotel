using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace JXHotel.DataObject
{
    /// <summary>
    /// 酒店员工聚合根
    /// </summary>
    [DataContract]
    public class HotelUserDataObject : UserDataObject
    {
        //public HotelUser()
        //{

        //}

        /// <summary>
        /// 酒店Id
        /// </summary>
        [DataMember]
        public Guid HotelId { get; set; }

        //public virtual Hotel Hotel { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        [DataMember]
        public Guid HotelRoleId { get; set; }

        //public virtual HotelRole HotelRole { get; set; }


    }
}
