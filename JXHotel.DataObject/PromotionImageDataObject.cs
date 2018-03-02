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
    /// 优惠活动图片
    /// </summary>
    [DataContract]
    public  class PromotionImageDataObject : ImageDataObject
    {
        [DataMember]
        public Guid HotelPromotionId { get; set; }

        //public virtual HotelPromotion HotelPromotion { get; set; }
    }
}
