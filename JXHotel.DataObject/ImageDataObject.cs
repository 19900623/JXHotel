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
    /// 图片
    /// </summary>
    [DataContract]
    public   class ImageDataObject
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        [Display(Name ="地址")]
        [Required]      
        public string Url { get; set; }

        /// <summary>
        /// 图片文字描述
        /// </summary>
        [DataMember]
        [Display(Name ="描述")]
        public string Description { get; set; }
    }
}
