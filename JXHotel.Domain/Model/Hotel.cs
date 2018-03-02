using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
 public   class Hotel  :AggregateRoot
    {

        public Hotel()
        {
            HotelCategorys = new List<HotelCategory>();
            HotelImages = new List<HotelImage>();
            Rooms = new List<Room>();
            HotelComments = new List<HotelComment>();
            HotelAccounts = new List<HotelAccount>();
            //HotelPromotions = new HashSet<HotelPromotion>();
        }

        public string Name { get; set; }


        public Address ContactAddress { get; set; }


        public string PhotoUrl { get; set; }

        /// <summary>
        /// 酒店均价
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get; set; }

        
        public string Description { get; set; }


       public virtual List<HotelCategory> HotelCategorys { get; set; }


       public virtual List<HotelImage> HotelImages { get; set; }

       public virtual List<Room> Rooms { get; set; }


       public virtual List<HotelAccount> HotelAccounts { get; set; }

       public virtual List<HotelComment> HotelComments { get; set; }

       //public virtual ICollection<HotelPromotion> HotelPromotions { get; set; }


    }
}
