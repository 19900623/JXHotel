using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 酒店优惠活动
    /// </summary>
    public class HotelPromotion : AggregateRoot
    {

        public HotelPromotion()
        {
            CustomerRoles = new List<CustomerRole>();

            PromotionImages = new List<PromotionImage>();


            HotelRoomCategorys = new List<HotelRoomCategory>();
        }



        /// <summary>
        ///酒店Id
        /// </summary>
        public Guid HotelId { get; set; }

        /// <summary>
        /// 活动名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 活动描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 活动开始日期
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 活动结束日期
        /// </summary>
        public DateTime EndDate { get; set; }


        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// 是否是默认活动
        /// </summary>
        public bool IsDefault { get; set; }

        /// <summary>
        /// 是否允许重复计算
        /// </summary>
        public bool AllowRepeate { get; set; }

        /// <summary>
        /// 参与活动的消费者角色
        /// </summary>
        public virtual List<CustomerRole> CustomerRoles { get; set; }

        /// <summary>
        /// 参与活动的房间分类
        /// </summary>
        public virtual List<HotelRoomCategory> HotelRoomCategorys { get;set;}

        public virtual  Hotel Hotel { get; set; }


        public virtual List<PromotionImage> PromotionImages { get; set; }






    }
}
