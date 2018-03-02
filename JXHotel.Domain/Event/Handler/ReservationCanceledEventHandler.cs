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
    /// 预定取消事件处理器
    /// </summary>
    public class ReservationCanceledEventHandler : IDomainEventHandler<ReservationCanceledEvent>
    {
        private readonly IEventBus bus;

        public ReservationCanceledEventHandler(IEventBus bus)
        {

            this.bus = bus;
        }

        public void Handle(ReservationCanceledEvent evnt)
        {
            Reservation reservation = evnt.Source as Reservation;
            reservation.Status = ReservationStatus.Cancel;
            bus.Publish<ReservationCanceledEvent>(evnt);
        }
    }
}
