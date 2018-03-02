using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Event;
using JXHotel.Domain.Model;
using JXHotel.Event.Bus;

namespace JXHotel.Domain.Event.Handler
{
    /// <summary>
    /// 预定付款事件处理器
    /// </summary>
   public class ReservationPaidedEventHandler :IDomainEventHandler<ReservationPaidedEvent>
    {
        private readonly IEventBus bus;
        public ReservationPaidedEventHandler(IEventBus bus)
        {
            this.bus = bus;
        }

        public void Handle(ReservationPaidedEvent evnt)
        {
            Reservation reservation = evnt.Source as Reservation;
            reservation.Status = ReservationStatus.Paid;
            bus.Publish<ReservationPaidedEvent>(evnt);
        }
    }
}
