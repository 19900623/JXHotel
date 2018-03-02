using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 酒店分类
    /// </summary>
   public class HotelCategory  :AggregateRoot   
    {   


        public HotelCategory()
        {
            Hotels = new HashSet<Hotel>();
        }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        public virtual ICollection<Hotel> Hotels { get; set; }



    }
}
