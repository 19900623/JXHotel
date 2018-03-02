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
    /// 酒店优惠活动实体
    /// </summary>
    [DataContract]
    public class HotelPromotionDataObject
    {

        //public HotelPromotion()
        //{
        //    CustomerRoles = new HashSet<CustomerRole>();

        //    PromotionImages = new HashSet<PromotionImage>();


        //    HotelRoomCategorys = new HashSet<HotelRoomCategory>();
        //}

        [DataMember]
        public Guid Id { get; set; }

        /// <summary>
        ///酒店Id
        /// </summary>
        [DataMember]
        public Guid HotelId { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        [DataMember]
        [Required(ErrorMessage ="请输入名称")]
        [Display(Name="名称")]
        public string Name { get; set; }

        /// <summary>
        /// 活动描述
        /// </summary>
        [DataMember]
        [Display(Name = "描述")]
        public string Description { get; set; }

        /// <summary>
        /// 活动开始日期
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "请输入开始日期")]
        [Display(Name = "开始日期")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 活动结束日期
        /// </summary>
        [DataMember]
        [Required(ErrorMessage = "请输入结束日期")]
        [Display(Name = "结束日期")]
        public DateTime EndDate { get; set; }


        /// <summary>
        /// 是否启用
        /// </summary>
        [DataMember]
        [Required]
        public bool IsEnable { get; set; }

        [DataMember]
        [Display(Name = "是否启用")]
        public string IsEnableText
        {
            get
            {
                return IsEnable ? "是" : "否";
            }
        }

        /// <summary>
        /// 是否是默认活动
        /// </summary>
        [DataMember]
        [Required]
        public bool IsDefault { get; set; }


        [DataMember]
        [Display(Name = "是否默认")]
        public string IsDefaultText
        {
            get
            {
                return IsDefault ? "是" : "否";
            }
        }

        /// <summary>
        /// 是否允许重复计算
        /// </summary>
        [DataMember]
        [Required]
        public bool AllowRepeate { get; set; }

        [DataMember]
        [Display(Name = "是否允许重复计算")]
        public string AllowRepeateText
        {
            get
            {
                return AllowRepeate ? "是" : "否";
            }
        }

        /// <summary>
        /// 参与活动的消费者角色
        /// </summary>
        [DataMember]
        public  List<CustomerRoleDataObject> CustomerRoles { get; set; }

        /// <summary>
        /// 参与活动的房间分类
        /// </summary>
        [DataMember]
        public List<HotelRoomCategoryDataObject> HotelRoomCategorys { get;set;}

        //public virtual  Hotel Hotel { get; set; }

        /// <summary>
        /// 活动图片
        /// </summary>
        [DataMember]
        public  List<PromotionImageDataObject> PromotionImages { get; set; }






    }
}
