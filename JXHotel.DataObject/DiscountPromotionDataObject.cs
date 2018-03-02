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
    /// 折扣优惠活动
    /// </summary>
    [DataContract]
    public  class DiscountPromotionDataObject : HotelPromotionDataObject
    {
        /// <summary>
        /// 折扣率 如：Rate=20  实际价格为 原价格*80%
        /// </summary>
        [DataMember]
        [Required(ErrorMessage ="请输入折扣率",AllowEmptyStrings =false)]
        public int Rate { get; set; }


        [DataMember]
        [Display(Name = "折扣率")]
        public String RateText
        {
            get
            {
                return "-" + Rate.ToString() + "%";
            }
        }
    }
}
