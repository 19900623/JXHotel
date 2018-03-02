using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Application.Contract;
using JXHotel.Domain.Model;
using JXHotel.Domain.Repository;
using JXHotel.Domain.Specification;
using JXHotel.DataObject;
using JXHotel.Infrastructure.Transaction;
using JXHotel.Event.Bus;
using AutoMapper;

namespace JXHotel.Application.Imp
{
    /// <summary>
    /// 酒店预定应用层
    /// </summary>
    public class ReservationService : ApplicationService, IReservationService
    {

        private readonly IReservationRepository reservationRepository;
        private readonly IEventBus bus;

        public ReservationService(IRepositoryContext context,IReservationRepository reservationRepository,IEventBus bus) : base(context)
        {
            this.reservationRepository = reservationRepository;
            this.bus = bus;
        }

        /// <summary>
        /// 创建酒店预定
        /// </summary>
        /// <param name="reservationDataObject"></param>
        /// <returns></returns>
       public List<ReservationDataObject> CreateReservation(List<ReservationDataObject> reservationDataObject)
        {
            return this.PerformCreateObjects<List<ReservationDataObject>, ReservationDataObject, Reservation>(reservationDataObject, reservationRepository);
        }

        /// <summary>
        /// 获取所有预定信息
        /// </summary>
        /// <returns></returns>
        public List<ReservationDataObject> GetReservations(QuerySpec spec)
        {
            IEnumerable<Reservation> reservations;
            if (!spec.Verbose)
            {
                reservations = reservationRepository.FindAll();
            }
            else
            {
                reservations = reservationRepository.FindAll(new AnySpecification<Reservation>(), r => r.Room,r=>r.Customer);
            }
            List<ReservationDataObject> reservationDataObjects = AutoMapper.Mapper.Map<List<Reservation>, List<ReservationDataObject>>(reservations.ToList());
            return reservationDataObjects;
        }

        /// <summary>
        /// 根据Id值获取预定信息
        /// </summary>
        /// <param name="id">预定Id值</param>
        /// <returns></returns>
        public ReservationDataObject GetReservationByKey(Guid id, QuerySpec spec)
        {
            Reservation reservation;
            if (!spec.Verbose)
            {
                reservation = reservationRepository.GetByKey(id);
            }
            else
            {
                reservation = reservationRepository.Find(Specification<Reservation>.Eval(r => r.Id.Equals(id)), r => r.Room, r => r.Customer);

            }
            return AutoMapper.Mapper.Map<Reservation, ReservationDataObject>(reservation);
        }

        /// <summary>
        /// 根据消费者Id获取预定信息
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<ReservationDataObject> GetReservationsForCustomer(Guid customerId)
        {
            List<Reservation> listReservation = reservationRepository.FindAll(Specification<Reservation>.Eval(r => r.CustomerId.Equals(customerId))).ToList();
            return AutoMapper.Mapper.Map<List<Reservation>, List<ReservationDataObject>>(listReservation);
        }

        /// <summary>
        /// 根据酒店Id获取预定信息
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public List<ReservationDataObject> GetReservationsForHotel(Guid hotelId)
        {
            List<Reservation> listReservation = reservationRepository.GetReservationsForHotel(hotelId);
            return AutoMapper.Mapper.Map<List<Reservation>, List<ReservationDataObject>>(listReservation);
        }


        /// <summary>
        /// 根据房间Id获取预定信息
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public List<ReservationDataObject> GetReservationsForRoom(Guid roomId)
        {
            List<Reservation> listReservation = reservationRepository.FindAll(Specification<Reservation>.Eval(r => r.RoomId.Equals(roomId))).ToList();
            return AutoMapper.Mapper.Map<List<Reservation>, List<ReservationDataObject>>(listReservation);
        }


        /// <summary>
        /// 预定付款
        /// </summary>
        /// <param name="ReservationId">预定Id</param>
       public void Paid(Guid ReservationId)
        {
            using (ITransactionCoordinator coordinator = TransactionCoordinatorFactory.Create(Context, bus))
            {
                Reservation reservation = reservationRepository.GetByKey(ReservationId);
                reservation.Paid();
                reservationRepository.Update(reservation);
                coordinator.Commit();
            }
        }


        /// <summary>
        /// 预定取消
        /// </summary>
        /// <param name="ReservationId">预定Id</param>
       public void Cancel(Guid ReservationId)
        {
            using (ITransactionCoordinator coordinator = TransactionCoordinatorFactory.Create(Context, bus))
            {
                Reservation reservation = reservationRepository.GetByKey(ReservationId);
                reservation.Cancel();
                reservationRepository.Update(reservation);
                coordinator.Commit();
            }
        }
    }
}
