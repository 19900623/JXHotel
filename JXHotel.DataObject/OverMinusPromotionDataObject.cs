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
    /// 满减优惠活动
    /// </summary>
    [DataContract]
    public class OverMinusPromotionDataObject : HotelPromotionDataObject
    {
        /// <summary>
        /// 满金额
        /// </summary>
        [DataMember]
        [Required(ErrorMessage ="请输入满金额")]
        [Display(Name= "满金额")]
        public decimal  OverMoney { get; set; }

        /// <summary>
        /// 减金额
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "请输入减金额")]
        [Display(Name = "减金额")]
        public decimal MinusMoney { get; set; }

        [DataMember]       
        [Display(Name = "内容")]
        public string OverMinusMoneyText
        {
            get
            {
                return string.Format("满{0}元减{1}元",OverMoney,MinusMoney);
            }
        }
    }
}
