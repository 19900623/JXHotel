using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JXHotel.Infrastructure;
using JXHotel.Application.Contract;
using JXHotel.Application;
using JXHotel.DataObject;
using Newtonsoft.Json;

namespace JXHotel.WebApi.Controllers
{
    public class ReservationController : ApiController
    {

        private readonly IReservationService reservationServiceImp = ServiceLocator.Instance.GetService<IReservationService>();

        /// <summary>
        /// 创建酒店预定
        /// </summary>
        /// <param name="reservationDataObject"></param>
        /// <returns></returns>
        public string  PostReservation(List<ReservationDataObject> reservationDataObject)
        {
            var reservations = reservationServiceImp.CreateReservation(reservationDataObject);
            return JsonConvert.SerializeObject(reservations);
        }

        /// <summary>
        /// 获取所有预定信息
        /// </summary>
        /// <returns></returns>
        public string Get()
        {
            var reservations = reservationServiceImp.GetReservations(QuerySpec.Empty);
            return JsonConvert.SerializeObject(reservations);
        }

        /// <summary>
        /// 根据Id值获取预定信息
        /// </summary>
        /// <param name="id">预定Id值</param>
        /// <returns></returns>
        public string GetByKey(string  id)
        {
            var reservation = reservationServiceImp.GetReservationByKey(new Guid(id), QuerySpec.Empty);
            return JsonConvert.SerializeObject(reservation);
        }

        /// <summary>
        /// 根据消费者Id获取预定信息
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public string GetForCustomer(string  customerId)
        {
            var reservations = reservationServiceImp.GetReservationsForCustomer(new Guid(customerId));
            return JsonConvert.SerializeObject(reservations);
        }

        /// <summary>
        /// 根据酒店Id获取预定信息
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public string GetForHotel(string  hotelId)
        {
            var reservations = reservationServiceImp.GetReservationsForHotel(new Guid(hotelId));
            return JsonConvert.SerializeObject(reservations);
        }


        /// <summary>
        /// 根据房间Id获取预定信息
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public string GetForRoom(string  roomId)
        {
            var reservations = reservationServiceImp.GetReservationsForRoom(new Guid(roomId));
            return JsonConvert.SerializeObject(reservations);
        }


        /// <summary>
        /// 预定付款
        /// </summary>
        /// <param name="ReservationId">预定Id</param>
       public void PutPaid(string  ReservationId)
        {
            reservationServiceImp.Paid(new Guid(ReservationId));
        }


        /// <summary>
        /// 预定取消
        /// </summary>
        /// <param name="ReservationId">预定Id</param>
        public void PutCancel(string  ReservationId)
        {
            reservationServiceImp.Cancel(new Guid(ReservationId));
        }
    }
}
