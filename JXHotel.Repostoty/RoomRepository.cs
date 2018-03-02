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
    public class RoomRepository : EntityFrameworkRepository<Room>, IRoomRepository
    {
        public RoomRepository(IRepositoryContext context) : base(context)
        {

        }

        /// <summary>
        /// 根据酒店名称获取酒店房间
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
       public  List<Room> GetRoomsByHotelName(string hotelName)
        {
            var context = this.EFContext.dbContext as JXHotelDbContext;
            return context.Hotels.Where(new HotelNameEqualSpecification(hotelName).GetExpression()).FirstOrDefault().Rooms;       
        }


        #region 房间图片
        /// <summary>
        /// 创建房间图片
        /// </summary>
        /// <param name="RoomImages"></param>
        /// <returns></returns>
       public void AddRoomImage(Guid roomId, List<RoomImage> RoomImages)
        {
            var context = EFContext.dbContext as JXHotelDbContext;
            Room room = context.Rooms.Find(roomId);
            room.RoomImages.AddRange(RoomImages);
            //this.Context.RegisterModify<Room>(horoomtel);
            this.Update(room);
            this.Context.Commit();
        }

        /// <summary>
        /// 更新房间图片
        /// </summary>
        /// <param name="RoomImages"></param>
        /// <returns></returns>
        public List<RoomImage> UpdateRoomImage(Guid roomId, List<RoomImage> RoomImages)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            Room room = dbContext.Rooms.Find(roomId);
            List<RoomImage> listRoomImage = room.RoomImages;

            foreach (RoomImage updateRoomImage in RoomImages)
            {
                for (int i = 0; i < listRoomImage.Count; i++)
                {
                    if (listRoomImage[i].Id.Equals(updateRoomImage.Id))
                        listRoomImage[i] = updateRoomImage;
                }
            }
            // this.Context.RegisterModify<Room>(room);
            this.Update(room);
            this.Context.Commit();
            return RoomImages;
        }

        /// <summary>
        /// 删除房间图片
        /// </summary>
        /// <param name="ids">需要删除的房间图片id值</param>
        public void DeleteRoomImage(Guid roomId, List<string> ids)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            Room room = dbContext.Rooms.Find(roomId);
            room.RoomImages.RemoveAll(item => ids.Contains(item.Id.ToString()));
            this.Update(room);
            this.Context.Commit();
        }



        /// <summary>
        /// 根据房间图片id获取房间图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public RoomImage GetRoomImageByKey(Guid roomId, Guid id)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            RoomImage roomImage = dbContext.Rooms.Find(roomId).RoomImages.Where(Image => Image.Id.Equals(id)).FirstOrDefault();
            return roomImage;
        }


        /// <summary>
        /// 根据房间id获取房间图片
        /// </summary>
        /// <param name="RoomId"></param>
        /// <returns></returns>
        public List<RoomImage> GetRoomImagesByRoomId(Guid roomId)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            List<RoomImage> roomImages = dbContext.Rooms.Find(roomId).RoomImages;
            return roomImages;
        }

        /// <summary>
        /// 根据房间名称获取房间图片
        /// </summary>
        /// <param name="RoomName"></param>
        /// <returns></returns>
        public List<RoomImage> GetRoomImagesByRoomName(string roomName)
        {
            return this.Find(new RoomNameEqualSpecification(roomName), room => room.RoomImages).RoomImages;
        }

        #endregion
    }
}
