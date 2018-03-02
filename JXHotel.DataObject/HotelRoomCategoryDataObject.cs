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
    /// 酒店房间分类
    /// </summary>
    [DataContract]
    public class HotelRoomCategoryDataObject
    {
        //public HotelRoomCategory()
        //{
        //    Rooms = new HashSet<Room>();
        //    HotelPromotions = new HashSet<HotelPromotion>();
        //}

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid HotelId { get; set; }

        /// <summary>
        /// 分类名称
        /// </summary>
        [DataMember]
        [Required(ErrorMessage ="请输入名称")]
        [Display(Name ="名称")]
        public string Name { get; set; }

        [DataMember]
        [Display(Name = "描述")]
        public string Description { get; set; }

       // public virtual ICollection<Room> Rooms { get; set; }


        //public virtual ICollection<HotelPromotion> HotelPromotions { get; set; }


    }
}
