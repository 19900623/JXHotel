using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.DataObject;

namespace JXHotel.Application.Contract
{
    /// <summary>
    /// 酒店预定应用层
    /// </summary>
   public interface IReservationService
    {
        /// <summary>
        /// 创建酒店预定
        /// </summary>
        /// <param name="reservationDataObject"></param>
        /// <returns></returns>
        List<ReservationDataObject> CreateReservation(List<ReservationDataObject> reservationDataObject);

        /// <summary>
        /// 获取所有预定信息
        /// </summary>
        /// <returns></returns>
        List<ReservationDataObject> GetReservations(QuerySpec spec);

        /// <summary>
        /// 根据Id值获取预定信息
        /// </summary>
        /// <param name="id">预定Id值</param>
        /// <returns></returns>
        ReservationDataObject GetReservationByKey(Guid id, QuerySpec spec);

        /// <summary>
        /// 根据消费者Id获取预定信息
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        List<ReservationDataObject> GetReservationsForCustomer(Guid customerId);

        /// <summary>
        /// 根据酒店Id获取预定信息
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        List<ReservationDataObject> GetReservationsForHotel(Guid hotelId);


        /// <summary>
        /// 根据房间Id获取预定信息
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        List<ReservationDataObject> GetReservationsForRoom(Guid roomId);


        /// <summary>
        /// 预定付款
        /// </summary>
        /// <param name="ReservationId">预定Id</param>
        void Paid(Guid ReservationId);


        /// <summary>
        /// 预定取消
        /// </summary>
        /// <param name="ReservationId">预定Id</param>
        void Cancel(Guid ReservationId);






    }
}
