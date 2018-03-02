using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;

namespace JXHotel.Domain.Repository
{
  public   interface ICustomerRepository:IUserRepository<Customer>
    {
        /// <summary>
        /// 增加消费者银行卡账号
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="customerAccounts"></param>
        void AddCustomerAccount(Guid userId, List<CustomerAccount> customerAccounts);

        /// <summary>
        /// 删除消费者银行卡账号
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="customerAccountDataObjects"></param>
        void DeleteCustomerAccount(Guid userId, List<CustomerAccount> customerAccountDataObjects);

        /// <summary>
        /// 更新消费者银行卡账号
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="customerAccounts"></param>
        /// <returns></returns>
        List<CustomerAccount> UpdateCustomerAccount(Guid userId, List<CustomerAccount> customerAccounts);
        
    }
}
