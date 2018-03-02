using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Service
{
    /// <summary>
    /// 活动与消费者角色聚合服务接口
    /// </summary>
   public interface IHotelPromotionCustomerRoleService
    {
        /// <summary>
        /// 将活动指向消费者角色
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <param name="CustomerRoleID"></param>
        void AssignCustomerRole(Guid hotelPromotionId, Guid CustomerRoleID);

        /// <summary>
        /// 将活动从消费者角色中移除
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <param name="CustomerRoleID"></param>
        void UnassignCustomerRole(Guid hotelPromotionId, Guid CustomerRoleID);
    }
}
