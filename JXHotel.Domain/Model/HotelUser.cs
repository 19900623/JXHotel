using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 酒店员工聚合根
    /// </summary>
   public class HotelUser :User
    {
        public HotelUser()
        {
            
        }

        /// <summary>
        /// 酒店Id
        /// </summary>
        public Guid HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

        /// <summary>
        /// 角色Id
        /// </summary>
        public Guid HotelRoleId { get; set; }

        public virtual HotelRole HotelRole { get; set; }


    }
}
