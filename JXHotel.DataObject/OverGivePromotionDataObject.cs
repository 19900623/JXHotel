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
    /// 满送优惠活动  满足多少天及送多少天
    /// </summary>
    [DataContract]
    public class OverGivePromotionDataObject : HotelPromotionDataObject
    {
        [DataMember]
        [Required(ErrorMessage ="请输入满天数")]
        [Display(Name ="满天数")]
        public int OverDay { get; set; }

        [DataMember]
        [Required(ErrorMessage = "请输入减天数")]
        [Display(Name = "满减天数")]
        public int GiveDay { get; set; }

        [DataMember]
        [Display(Name="内容")]
        public string OverGiveDayText
        {
            get
            {
                return string.Format("满{0}天减{1}天", OverDay, GiveDay);
            }
        }
    }
}
