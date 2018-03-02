using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Service
{
    /// <summary>
    /// 酒店房间与房间分类聚合服务接口
    /// </summary>
   public  interface IHotelRoomCategoryService
    {
        /// <summary>
        /// 将房间指向分类
        /// </summary>
        /// <param name="RoomID"></param>
        /// <param name="categoryID"></param>
         void AssignCategory(Guid RoomID, Guid categoryID);


        

        
    }
}
