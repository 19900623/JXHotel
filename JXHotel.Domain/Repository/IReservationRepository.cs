using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Repository;
using JXHotel.Domain.Model;

namespace JXHotel.Domain.Repository
{
    /// <summary>
    /// 预定仓储接口
    /// </summary>
 public   interface IReservationRepository  :IRepository<Reservation>
    {
        /// <summary>
        /// 根据消费者名称获取预定
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        List<Reservation> GetReservationsByUserName(string userName);

        /// <summary>
        /// 根据房间名称获取预定
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
        List<Reservation> GetReservationsByRoomName(string roomName);

        /// <summary>
        /// 根据酒店Id获取预定信息
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        List<Reservation> GetReservationsForHotel(Guid hotelId);
    }
}
