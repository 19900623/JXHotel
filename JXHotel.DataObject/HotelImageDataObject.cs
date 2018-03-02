using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace JXHotel.DataObject
{
    /// <summary>
    /// 酒店图片实体
    /// </summary>
    [DataContract]
    public  class HotelImageDataObject : ImageDataObject
    {
        [DataMember]
        public   Guid HotelId { get; set; }

        //public virtual Hotel Hotel { get; set; }
    }
}
