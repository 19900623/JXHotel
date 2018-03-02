using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Event;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 房间预订聚合根
    /// </summary>
   public class Reservation:AggregateRoot
    {
        /// <summary>
        ///房间Id
        /// </summary>
        public Guid RoomId { get; set; }

        /// <summary>
        /// 消费者Id
        /// </summary>
        public Guid CustomerId { get; set; }

        /// <summary>
        /// 预定开始日期
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 预定结束日期
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 预定状态
        /// </summary>
        public ReservationStatus Status { get; set; }

        public virtual Room Room { get; set; }


        public virtual Customer Customer { get; set; }


        /// <summary>
        /// 付款
        /// </summary>
        public void Paid()
        {
            ReservationPaidedEvent evnt = new ReservationPaidedEvent(this);
            evnt.CustomerEmailAddress = this.Customer.Email;
            evnt.PaidedDate = DateTime.Now;
            DomainEvent.Publish<ReservationPaidedEvent>(evnt);
        }


        /// <summary>
        /// 取消
        /// </summary>
        public void Cancel()
        {
            ReservationCanceledEvent evnt = new ReservationCanceledEvent(this);
            evnt.CustomerEmailAddress = this.Customer.Email;
            evnt.CanceledDate = DateTime.Now;
            DomainEvent.Publish<ReservationCanceledEvent>(evnt);

        }

    }
}
