using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;
using JXHotel.Domain.Repository;
using JXHotel.Repository.Specification;

namespace JXHotel.Repository
{
    public class ReservationRepository : EntityFrameworkRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(IRepositoryContext context) : base(context)
        {

        }

        public List<Reservation> GetReservationsByUserName(string userName)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            return   dbContext.Customer.Where(new UserNameEqualsSpecification<Customer>(userName).GetExpression()).FirstOrDefault().Reservations;
        }

        /// <summary>
        /// 根据房间名称获取预定
        /// </summary>
        /// <param name="roomName"></param>
        /// <returns></returns>
       public List<Reservation> GetReservationsByRoomName(string roomName)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            return dbContext.Rooms.Where(new RoomNameEqualSpecification(roomName).GetExpression()).FirstOrDefault().Reservations;
        }


        /// <summary>
        /// 根据酒店Id获取预定信息
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
       public List<Reservation> GetReservationsForHotel(Guid hotelId)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;

            var query = from r in dbContext.Rooms
                    join res in dbContext.Reservations on r.Id equals res.RoomId

                    where r.HotelId.Equals(hotelId)
                    select res;
            return query.ToList();
        }

    }
}
