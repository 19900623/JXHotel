using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Event;
using JXHotel.Infrastructure;
using JXHotel.Domain.Event;
using JXHotel.Domain.Model;

namespace JXHotel.Event.Handler
{
    /// <summary>
    /// 表示向外发送邮件的事件处理器。
    /// </summary>
    ///<remarks>详情参见:http://www.cnblogs.com/daxnet/archive/2013/01/05/2846085.html</remarks>
    [HandlesAsynchronously]
    public class SendEmailHandler : IEventHandler<ReservationPaidedEvent>, IEventHandler<ReservationCanceledEvent>
    {
        public SendEmailHandler()
        { }

        #region IEventHandler<ReservationPaidedEvent> Members
        /// <summary>
        /// 处理给定的事件。
        /// </summary>
        /// <param name="evnt">需要处理的事件。</param>
        public void Handle(ReservationPaidedEvent evnt)
        {
            try
            {
                Reservation Reservation = evnt.Source as Reservation;
                // 此处仅为演示，所以邮件内容很简单。可以根据自己的实际情况做一些复杂的邮件功能，比如
                // 使用邮件模板或者邮件风格等。
                Utils.SendEmail(evnt.CustomerEmailAddress,
                    "您的预定已经款",
                    string.Format("您的预定订单 {0} 已于 {1} 付款。",
                    Reservation.Id.ToString().ToUpper(), evnt.PaidedDate));
            }
            catch (Exception ex)
            {
                // 如遇异常，直接记Log
                Utils.Log(ex);
            }
        }

        #endregion

        #region IEventHandler<ReservationCanceledEvent> Members
        /// <summary>
        /// 处理给定的事件。
        /// </summary>
        /// <param name="evnt">需要处理的事件。</param>
        public void Handle(ReservationCanceledEvent evnt)
        {
            try
            {
                Reservation Reservation = evnt.Source as Reservation;
                // 此处仅为演示，所以邮件内容很简单。可以根据自己的实际情况做一些复杂的邮件功能，比如
                // 使用邮件模板或者邮件风格等。
                Utils.SendEmail(evnt.CustomerEmailAddress,
                    "您的预定已经取消",
                    string.Format("您的预定 {0} 已于 {1} 取消。有关订单的更多信息，请与系统管理员联系。",
                     Reservation.Id.ToString().ToUpper(), evnt.CanceledDate));
            }
            catch (Exception ex)
            {
                // 如遇异常，直接记Log
                Utils.Log(ex);
            }
        }

        #endregion

        
    }
}
