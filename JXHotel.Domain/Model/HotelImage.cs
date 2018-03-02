using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 酒店图片实体
    /// </summary>
  public  class HotelImage  :Image
    {
        public   Guid HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }
    }
}
