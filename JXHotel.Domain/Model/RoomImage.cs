using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 房间图片实体
    /// </summary>
   public class RoomImage  :Image
    {
        public Guid RoomId { get; set; }

        public virtual Room Room { get; set; }
    }
}
