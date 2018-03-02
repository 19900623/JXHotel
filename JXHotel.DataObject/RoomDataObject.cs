using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace JXHotel.DataObject
{
    [DataContract]
    public  class RoomDataObject
    {
        //public Room()
        //{
        //    RoomImages = new HashSet<RoomImage>();
        //    Reservations = new HashSet<Reservation>();

        //}

        [DataMember]
        public Guid Id { get; set; }

        /// <summary>
        /// 酒店Id
        /// </summary>
        [DataMember]
        public Guid HotelId { get; set; }

        [DataMember]
        public Guid HotelRoomCategoryId { get; set; }

        /// <summary>
        /// 房间名称
        /// </summary>
        [DataMember]
        [Required(ErrorMessage ="请输入房间名称")]
        [Display(Name ="名称")]
        public string Name { get; set; }

        /// <summary>
        /// 价格 money/天
        /// </summary>
        [DataMember]
        [Required(ErrorMessage ="请输入价格")]
        [Display(Name="价格")]
        public decimal Price { get; set; }

        /// <summary>
        /// 房间描述
        /// </summary>
        [DataMember]
        [Display(Name ="描述")]
        public string Description { get; set; }

        [DataMember]
        public  List<RoomImageDataObject> RoomImages { get; set; }

       // public virtual ICollection<Reservation> Reservations { get; set; }

        //public virtual Hotel Hotel { get; set; }

        //public virtual HotelRoomCategory HotelRoomCategory { get; set; }

       
    }
}
