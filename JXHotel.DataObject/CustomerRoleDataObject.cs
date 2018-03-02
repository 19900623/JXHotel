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
    /// 消费者角色
    /// </summary>
    [DataContract]
    public  class CustomerRoleDataObject : RoleDataObject
    {
        //public CustomerRole()
        //{
        //    HotelPromotions = new HashSet<HotelPromotion>();
        //}
        // public virtual ICollection<HotelPromotion> HotelPromotions { get; set; }
    }
}
