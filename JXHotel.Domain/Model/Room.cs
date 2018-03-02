using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
  public  class Room :AggregateRoot
    {   
        public Room()
        {
            RoomImages = new List<RoomImage>();
            Reservations = new List<Reservation>();
           
        }

        /// <summary>
        /// 酒店Id
        /// </summary>
        public Guid HotelId { get; set; }


        public Guid HotelRoomCategoryId { get; set; }

        /// <summary>
        /// 房间名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 价格 money/天
        /// </summary>   
        public decimal Price { get; set; }

        /// <summary>
        /// 房间描述
        /// </summary>
        public string Description { get; set; }

        public virtual List<RoomImage> RoomImages { get; set; }

        public virtual List<Reservation> Reservations { get; set; }

        public virtual Hotel Hotel { get; set; }

        public virtual HotelRoomCategory HotelRoomCategory { get; set; }

       
    }
}
