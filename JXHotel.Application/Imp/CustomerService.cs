using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Application.Contract;
using JXHotel.DataObject;
using JXHotel.Domain.Model;
using JXHotel.Domain.Repository;
using AutoMapper;
using JXHotel.Domain.Specification;
using JXHotel.Domain.Service;
using JXHotel.Repository.Specification;

namespace JXHotel.Application.Imp
{
    /// <summary>
    /// 消费者应用层
    /// </summary>
    public class CustomerService : ApplicationService, ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ICustomerRoleRepository customerRoleRepository;
        private readonly IReservationRepository reservationRepository;
        private readonly ICustomerRoleService customerRoleService;
        public CustomerService(IRepositoryContext context,ICustomerRepository customerRepository
                               ,ICustomerRoleRepository customerRoleRepository
                               ,IReservationRepository reservationRepository
                               ,ICustomerRoleService customerRoleService) : base(context)
        {
            this.customerRepository = customerRepository;
            this.customerRoleRepository = customerRoleRepository;
            this.reservationRepository = reservationRepository;
            this.customerRoleService = customerRoleService;


        }

        public List<CustomerDataObject> GetUsers(QuerySpec spec)
        {
            IEnumerable<Customer> customers;
            if(spec.Verbose)
            {
                customers = customerRepository.FindAll();
            }
            else
            {
                customers = customerRepository.FindAll(new AnySpecification<Customer>(), cer => cer.CustomerRole);
            }
            List<CustomerDataObject> customerDataObjects = AutoMapper.Mapper.Map<List<Customer>, List<CustomerDataObject>>(customers.ToList());
            return customerDataObjects;
        }


        public CustomerDataObject GetUserByEmail(string email, QuerySpec spec)
        {
            Customer customer;
            if (spec.Verbose)
            {
                customer = customerRepository.GetUserByEmail(email);
            }
            else
            {
                customer = customerRepository.Find( new UserNameEqualsSpecification<Customer>(email), cer => cer.CustomerRole);
            }
            CustomerDataObject customerDataObject = AutoMapper.Mapper.Map<Customer, CustomerDataObject>(customer);
            return customerDataObject;
        }

        public CustomerDataObject GetUserByKey(Guid ID, QuerySpec spec)
        {
            Customer customer;
            if (spec.Verbose)
            {
                customer = customerRepository.GetByKey(ID);
            }
            else
            {
                customer = customerRepository.Find(Specification<Customer>.Eval(cer=>cer.Id.Equals(ID)), cer => cer.CustomerRole);
            }
            CustomerDataObject customerDataObject = AutoMapper.Mapper.Map<Customer, CustomerDataObject>(customer);
            return customerDataObject;
        }

        public CustomerDataObject GetUserByName(string userName, QuerySpec spec)
        {
            Customer customer;
            if (spec.Verbose)
            {
                customer = customerRepository.GetUserByName(userName);
            }
            else
            {
                customer = customerRepository.Find(new UserNameEqualsSpecification<Customer>(userName), cer => cer.CustomerRole);
            }
            CustomerDataObject customerDataObject = AutoMapper.Mapper.Map<Customer, CustomerDataObject>(customer);
            return customerDataObject;
        }

        public List<CustomerDataObject> CreateUser(List<CustomerDataObject> userDataObject)
        {
             return this.PerformCreateObjects<List<CustomerDataObject>, CustomerDataObject, Customer>(userDataObject, customerRepository, null, null);
        }

        public List<CustomerDataObject> UpdateUser(List<CustomerDataObject> userDataObject)
        {
            return this.PerformUpdateObjects<List<CustomerDataObject>, CustomerDataObject, Customer>(userDataObject, customerRepository
                                                                                              , cdo => cdo.Id.ToString() 
                                                                                              , null);
        }

        public void DeleteUser(List<string> userIds)
        {
            this.PerformDeleteObjects<Customer>(userIds, customerRepository);
        }

        public bool ValidateUser(string userName, string password)
        {
            bool isValidate = customerRepository.CheckPassword(userName, password);
            return isValidate;
        }


        public List<CustomerRoleDataObject> CreateRole(List<CustomerRoleDataObject> roleDataObject)
        {
           return  this.PerformCreateObjects<List<CustomerRoleDataObject>, CustomerRoleDataObject, CustomerRole>(roleDataObject, customerRoleRepository);
        }

        public void DeleteRoles(List<string> roleID)
        {
            this.PerformDeleteObjects<CustomerRole>(roleID,customerRoleRepository);
        }

        public List<CustomerRoleDataObject> UpdateRole(List<CustomerRoleDataObject> roleDataObject)
        {
           return  this.PerformUpdateObjects<List<CustomerRoleDataObject>, CustomerRoleDataObject, CustomerRole>(roleDataObject, customerRoleRepository
                                                                                                                                , role => role.Id.ToString()
                                                                                                                                ,null);
        }


        public void AssignRole(Guid userID, Guid roleID)
        {
            customerRoleService.AssignRole(userID, roleID);
        }

      


        public CustomerRoleDataObject GetRoleByKey(Guid id)
        {
            CustomerRole customerRole = customerRoleRepository.GetByKey(id);
            CustomerRoleDataObject customerRoleDataObject = AutoMapper.Mapper.Map<CustomerRole, CustomerRoleDataObject>(customerRole);
            return customerRoleDataObject;
        }

        public CustomerRoleDataObject GetRoleByName(string name)
        {
            CustomerRole customerRole = customerRoleRepository.Find(Specification<CustomerRole>.Eval(cr=>cr.Name.Equals(name)));
            CustomerRoleDataObject customerRoleDataObject = AutoMapper.Mapper.Map<CustomerRole, CustomerRoleDataObject>(customerRole);
            return customerRoleDataObject;
        }

        public List<CustomerRoleDataObject> GetRoles()
        {
            var roles = customerRoleRepository.FindAll();
            List<CustomerRoleDataObject> customerRoleDataObjects = AutoMapper.Mapper.Map<List<CustomerRole>, List<CustomerRoleDataObject>>(roles.ToList());
            return customerRoleDataObjects;
        }



        public CustomerRoleDataObject GetUserRoleByUserName(string userName)
        {
            Customer customer = customerRepository.GetUserByName(userName);
            CustomerRole customerRole =  customerRoleRepository.GetByKey(customer.CustomerRoleId);
            return AutoMapper.Mapper.Map<CustomerRole, CustomerRoleDataObject>(customerRole);
        }


        public void AddCustomerAccount(Guid userId,List<CustomerAccountDataObject> customerAccountDataObject)
        {
            //Customer customer=  this.customerRepository.GetByKey(userId);
            //List<CustomerAccount> customerAccounts= AutoMapper.Mapper.Map<List<CustomerAccountDataObject>, List<CustomerAccount>>(customerAccountDataObject);
            //customer.CustomerAccount.AddRange(customerAccounts);
            //this.Context.RegisterModify<Customer>(customer);
            //this.Context.Commit();
            List<CustomerAccount> customerAccounts = AutoMapper.Mapper.Map<List<CustomerAccountDataObject>, List<CustomerAccount>>(customerAccountDataObject);
            customerRepository.AddCustomerAccount(userId, customerAccounts);
            
        }
   

        public void DeleteCustomerAccount(Guid userId,List<CustomerAccountDataObject> customerAccountDataObject)
        {
            List<CustomerAccount> customerAccounts = AutoMapper.Mapper.Map<List<CustomerAccountDataObject>, List<CustomerAccount>>(customerAccountDataObject);
            customerRepository.DeleteCustomerAccount(userId, customerAccounts);
        }

        public List<CustomerAccountDataObject> UpdateCustomerAccount(Guid userId, List<CustomerAccountDataObject> customerAccountDataObject)
        {
            List<CustomerAccount> customerAccounts = AutoMapper.Mapper.Map<List<CustomerAccountDataObject>, List<CustomerAccount>>(customerAccountDataObject);
            List<CustomerAccount> updatecustomerAccounts  =   customerRepository.UpdateCustomerAccount(userId, customerAccounts);
            return AutoMapper.Mapper.Map<List<CustomerAccount>, List<CustomerAccountDataObject>>(updatecustomerAccounts);
        }



        public List<CustomerAccountDataObject> GetCustomerAccountByKey(Guid id)
        {
            List<CustomerAccount> listCustomerAccount = customerRepository.GetByKey(id).CustomerAccount;
            return AutoMapper.Mapper.Map<List<CustomerAccount>, List<CustomerAccountDataObject>>(listCustomerAccount);
        }

       

        public List<CustomerAccountDataObject> GetCustomerAccountsByName(string userName)
        {
            List<CustomerAccount> listCustomerAccount = customerRepository.Find(new UserNameEqualsSpecification<Customer>(userName)).CustomerAccount;
            return AutoMapper.Mapper.Map<List<CustomerAccount>, List<CustomerAccountDataObject>>(listCustomerAccount);
        }

        public List<ReservationDataObject> GetReservations(string userName)
        {
            List<Reservation> listReservation = reservationRepository.GetReservationsByUserName(userName);
            return AutoMapper.Mapper.Map<List<Reservation>, List<ReservationDataObject>>(listReservation);
        }

    

      

       

       

     

     

       

       
    }
}
