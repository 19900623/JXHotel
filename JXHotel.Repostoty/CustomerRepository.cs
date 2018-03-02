using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;
using JXHotel.Domain.Repository;
using JXHotel.Domain.Specification;
using JXHotel.Infrastructure;

namespace JXHotel.Repository
{
    public class CustomerRepository : UserRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IRepositoryContext context) : base(context)
        {

        }

        public void AddCustomerAccount(Guid userId, List<CustomerAccount> customerAccounts)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            Customer customer = dbContext.Customer.Find(userId);
            customer.CustomerAccount.AddRange(customerAccounts);
            this.Context.RegisterModify<Customer>(customer);
            this.Context.Commit();
            
        }


        public void DeleteCustomerAccount(Guid userId, List<CustomerAccount> customerAccounts)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            Customer customer = dbContext.Customer.Find(userId);
            customer.CustomerAccount.RemoveAll(item => customerAccounts.Select(a => a.Id).Contains(item.Id));
            this.Context.RegisterModify<Customer>(customer);
            this.Context.Commit();
        }

        public List<CustomerAccount> UpdateCustomerAccount(Guid userId, List<CustomerAccount> customerAccounts)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            Customer customer = dbContext.Customer.Find(userId);
            List<CustomerAccount> listCustomerAccount = customer.CustomerAccount;
           
            foreach (CustomerAccount updatecustomerAccount in customerAccounts)
            {   
                for (int i = 0; i < customerAccounts.Count; i++)
                {
                    if (customerAccounts[i].Id.Equals(updatecustomerAccount.Id))
                        customerAccounts[i] = updatecustomerAccount;
                }
            }
            this.Context.RegisterModify<Customer>(customer);
            this.Context.Commit();
            return customerAccounts;
        }

    }
}
