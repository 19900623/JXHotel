using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;

namespace JXHotel.Domain.Repository
{
    /// <summary>
    /// 消费者角色仓储接口
    /// </summary>
  public  interface ICustomerRoleRepository :IRoleRepository<CustomerRole,Customer>
    {
        /// <summary>
        /// 根据活动id获取消费者角色
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <returns></returns>
        List<CustomerRole> GetCustomerRoleByHotelPromotionId(Guid hotelPromotionId);

        /// <summary>
        /// 根据活动名称获取消费者角色
        /// </summary>
        /// <param name="hotelPromotionName"></param>
        /// <returns></returns>
        List<CustomerRole> GetCustomerRoleByHotelPromotionName(string hotelPromotionName);
    }
}
