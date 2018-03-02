using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Event
{
    /// <summary>
    /// 预定付款领域事件
    /// </summary>
   public class ReservationPaidedEvent :DomainEvent
    {
        public ReservationPaidedEvent() { }
        public ReservationPaidedEvent(IEntity source) : base(source) { }


        /// <summary>
        /// 付款日期
        /// </summary>
       public  DateTime PaidedDate { get; set; }

       /// <summary>
       /// 消费者邮件地址
       /// </summary>
       public String CustomerEmailAddress { get; set; } 

       


    }
}
