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
    /// 房间预订聚合根
    /// </summary>
    [DataContract]
    public class ReservationDataObject
    {
        [DataMember]
        public Guid Id { get; set; }

        /// <summary>
        ///房间Id
        /// </summary>
        [DataMember]
        public Guid RoomId { get; set; }

        /// <summary>
        /// 消费者Id
        /// </summary>
        [DataMember]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// 预定开始日期
        /// </summary>
        [DataMember]
        [Display(Name = "开始日期")]
        [Required(ErrorMessage ="请输入开始日期")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 预定结束日期
        /// </summary>
        [DataMember]
        [Display(Name = "结束日期")]
        [Required(ErrorMessage = "请输入结束日期")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 预定状态
        /// </summary>
        [DataMember]
        [Required]
        public ReservationStatusDataObject Status { get; set; }

        [DataMember]
        [Display(Name ="状态")]
        public string StatusText
        {
            get
            {
                switch(this.Status)
                {
                    case ReservationStatusDataObject.Cancel:
                        return "取消";
                    case ReservationStatusDataObject.Created:
                        return "创建";
                    case ReservationStatusDataObject.Paid:
                        return "已付款";
                    case ReservationStatusDataObject.Complete:
                        return "完成";
                    default:
                        return null;
                }
            }
        }

        //public virtual Room Room { get; set; }


        //public virtual Customer Customer { get; set; }


    }
}
