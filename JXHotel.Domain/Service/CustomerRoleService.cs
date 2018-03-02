using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Repository;
using JXHotel.Domain.Model;

namespace JXHotel.Domain.Service
{
    /// <summary>
    /// 消费聚合与消费者角色聚合服务
    /// </summary>
    public class CustomerRoleService : ICustomerRoleService
    {
        private readonly IRepositoryContext repositoryContext;
        private readonly ICustomerRepository customerRepository;
        private readonly ICustomerRoleRepository customerRoleRepository;

        public CustomerRoleService(IRepositoryContext repositoryContext, ICustomerRepository customerRepository,ICustomerRoleRepository customerRoleRepository)
        {
            this.repositoryContext = repositoryContext;
            this.customerRepository = customerRepository;
            this.customerRoleRepository = customerRoleRepository;
        }

        public void AssignRole(Guid userID, Guid roleID)
        {
            Customer customer = customerRepository.GetByKey(userID);
            customer.CustomerRoleId = roleID;
            customerRepository.Update(customer);
            repositoryContext.Commit();

        }
    }
}
