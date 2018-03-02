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
    public   class HotelDataObject
    {

        //public Hotel()
        //{
        //    HotelCategorys = new HashSet<HotelCategory>();
        //    HotelImages = new HashSet<HotelImage>();
        //    Rooms = new HashSet<Room>();
        //    HotelComments = new HashSet<HotelComment>();
        //    HotelAccounts = new HashSet<HotelAccount>();
        //    //HotelPromotions = new HashSet<HotelPromotion>();
        //}

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        [Required(ErrorMessage ="请输入名称")]
        [Display(Name ="名称")]
        public string Name { get; set; }

        [DataMember]
        [Required(ErrorMessage = "请输入地址")]
        [Display(Name = "地址")]
        public AddressDataObject ContactAddress { get; set; }

        [DataMember]
        [Display(Name ="图片地址")]
        public string PhotoUrl { get; set; }

        /// <summary>
        /// 酒店均价
        /// </summary>
        [DataMember]
        [Display(Name="平均价格")]
        public decimal Price { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        [DataMember]
        [Display(Name = "联系人")]
        public string Contact { get; set; }

        [DataMember]
        [Display(Name = "描述")]
        public string Description { get; set; }


        //public virtual   ICollection<HotelCategory> HotelCategorys { get; set; }

        [DataMember]
        public  List<HotelImageDataObject> HotelImages { get; set; }

        //public virtual ICollection<Room> Rooms { get; set; }

        [DataMember]
        public  List<HotelAccountDataObject> HotelAccounts { get; set; }

        [DataMember]
        public  List<HotelCommentDataObject> HotelComments { get; set; }

      


    }
}
