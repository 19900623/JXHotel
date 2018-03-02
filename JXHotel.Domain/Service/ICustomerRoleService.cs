using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;
namespace JXHotel.Domain.Service
{
    /// <summary>
    /// 消费者聚合与消费者角色聚合服务接口
    /// </summary>
  public   interface ICustomerRoleService  :IUserRoleService<Customer,CustomerRole>
    {

    }
}
