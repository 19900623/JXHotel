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
    /// 房间图片实体
    /// </summary>
    [DataContract]
    public class RoomImageDataObject : ImageDataObject
    {
        [DataMember]
        public Guid RoomId { get; set; }

        //public virtual Room Room { get; set; }
    }
}
