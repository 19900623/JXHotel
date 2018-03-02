using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Service
{
    /// <summary>
    /// 酒店与酒店分类聚合服务接口
    /// </summary>
   public  interface IHotelCategoryService
    {
        /// <summary>
        /// 将酒店指向分类
        /// </summary>
        /// <param name="hotelID"></param>
        /// <param name="categoryID"></param>
        void AssignCategory(Guid hotelID, Guid categoryID);


        /// <summary>
        /// 将酒店从分类中移除
        /// </summary>
        /// <param name="hotelID"></param>
        /// <param name="categoryID"></param>
        void UnassignCategory(Guid hotelID, Guid categoryID);
        

        
    }
}
