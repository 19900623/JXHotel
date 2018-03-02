using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 酒店房间分类
    /// </summary>
    public class HotelRoomCategory : AggregateRoot
    {
        public HotelRoomCategory()
        {
            Rooms = new HashSet<Room>();
            HotelPromotions = new HashSet<HotelPromotion>();
        }

        public Guid HotelId { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }


        public virtual ICollection<HotelPromotion> HotelPromotions { get; set; }


    }
}
