using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JXHotel.Domain.Event
{
    /// <summary>
    /// 预定取消领域事件
    /// </summary>
    public class ReservationCanceledEvent :DomainEvent
    {

        public ReservationCanceledEvent()
        {

        }
        public ReservationCanceledEvent(IEntity source) :base(source)
        {

        }

        /// <summary>
        /// 取消日期
        /// </summary>
        public DateTime CanceledDate { get; set; }

        /// <summary>
        /// 消费者邮件地址
        /// </summary>
        public String CustomerEmailAddress { get; set; }

    }
}
