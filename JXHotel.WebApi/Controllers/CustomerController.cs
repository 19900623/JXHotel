using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JXHotel.Infrastructure;
using JXHotel.Application.Contract;
using JXHotel.Application;
using JXHotel.DataObject;
using Newtonsoft.Json;

namespace JXHotel.WebApi.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly ICustomerService customerServiceImp = ServiceLocator.Instance.GetService<ICustomerService>();
        /// <summary>
        ///创建用户
        /// </summary>
        /// <param name="userDataObject"></param>
        /// <returns></returns>
        public  string  Post(List<CustomerDataObject> userDataObject)
        {
            var customers = customerServiceImp.CreateUser(userDataObject);
            return JsonConvert.SerializeObject(customers);
        }


        /// <summary>
        /// 验证用户密码
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public  string  GetValidate(string userName, string password)
        {
            var isValidate = customerServiceImp.ValidateUser(userName, password);
            return JsonConvert.SerializeObject(isValidate);
        }


        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userDataObject"></param>
        /// <returns></returns>
        public string  Put(List<CustomerDataObject> userDataObject)
        {
            var customers = customerServiceImp.UpdateUser(userDataObject);
            return JsonConvert.SerializeObject(customers);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userIds"></param>
        public void DeleteUser(List<string> userIds)
        {
            customerServiceImp.DeleteUser(userIds);
        }

        /// <summary>
        /// 根据用户的全局唯一标识获取用户信息。
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string  GetByKey(string ID)
        {
            var customer = customerServiceImp.GetUserByKey(new Guid(ID), QuerySpec.Empty);
            return JsonConvert.SerializeObject(customer);
        }


        /// <summary>
        /// 根据用户的电子邮件地址获取用户信息。
        /// </summary>
        /// <param name="email">用户的电子邮件地址。</param>
        /// <returns>包含了用户信息的数据传输对象。</returns>
        public string GetByEmail(string email)
        {
            var customer = customerServiceImp.GetUserByEmail(email, QuerySpec.Empty);
            return JsonConvert.SerializeObject(customer);
        }

        /// <summary>
        /// 根据用户的用户名获取用户信息。
        /// </summary>
        /// <param name="userName">用户的用户名。</param>
        /// <returns>包含了用户信息的数据传输对象。</returns>
        public string  GetUserByName(string userName)
        {
            var customer = customerServiceImp.GetUserByName(userName, QuerySpec.Empty);
            return JsonConvert.SerializeObject(customer);
        }

        /// <summary>
        /// 获取所有用户的信息。
        /// </summary>
        /// <param name="spec">查询方式。</param>
        /// <returns>包含了所有用户信息的数据传输对象列表。</returns>
        public string  Get()
        {
            var customers = customerServiceImp.GetUsers(QuerySpec.Empty);
            return JsonConvert.SerializeObject(customers);
        }



        /// <summary>
        /// 获取所有角色。
        /// </summary>
        /// <returns>所有角色。</returns>   
        public string GetRoles()
        {
            var roles = customerServiceImp.GetRoles();
            return JsonConvert.SerializeObject(roles);
        }


        /// <summary>
        /// 根据指定的ID值，获取角色。
        /// </summary>
        /// <param name="id">指定的角色ID值。</param>
        /// <returns>角色。</returns>
        public   string GetRoleByKey(string  id)
        {
            var role = customerServiceImp.GetRoleByKey(new Guid(id));
            return JsonConvert.SerializeObject(role);
        }

        /// <summary>
        /// 根据指定的角色名，获取角色。
        /// </summary>
        /// <param name="name">角色名</param>
        /// <returns>角色</returns>
        public string GetRoleByName(string name)
        {

            var role = customerServiceImp.GetRoleByName(name);
            return JsonConvert.SerializeObject(role);
        }

        /// <summary>
        /// 创建角色。
        /// </summary>
        /// <param name="roleDataObject">需要创建的角色。</param>
        /// <returns>已创建的角色。</returns>
         public string  PostRole(List<CustomerRoleDataObject> roleDataObject)
        {
            var roles = customerServiceImp.CreateRole(roleDataObject);
            return JsonConvert.SerializeObject(roles);
        }


        /// <summary>
        /// 更新角色。
        /// </summary>
        /// <param name="roleDataObject">需要更新的角色。</param>
        /// <returns>已更新的角色。</returns>
        public string  PutRole(List<CustomerRoleDataObject> roleDataObject)
        {
            var roles = customerServiceImp.UpdateRole(roleDataObject);
            return JsonConvert.SerializeObject(roles);
        }

        /// <summary>
        /// 删除角色。
        /// </summary>
        /// <param name="roleID">需要删除的角色ID值。</param>
         public  void DeleteRoles(List<string> roleID)
        {
            customerServiceImp.DeleteRoles(roleID);
        }

        /// <summary>
        /// 将指定的用户赋予指定的角色。
        /// </summary>
        /// <param name="userID">需要赋予角色的用户ID值。</param>
        /// <param name="roleID">需要向用户赋予的角色ID值。</param>
       public  void PutAssignRole(string  userID, string  roleID)
        {
            customerServiceImp.AssignRole(new Guid(userID), new Guid(roleID));
        }



        /// <summary>
        /// 根据指定的用户名，获取该用户所属的角色。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <returns>角色。</returns>
        public string  GetRoleByUserName(string userName)
        {
            var role = customerServiceImp.GetUserRoleByUserName(userName);
            return JsonConvert.SerializeObject(role);
        }




        /// <summary>
        /// 根据用户名获取用户预定信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
       public string GetReservations(string userName)
        {
            var reservations = customerServiceImp.GetReservations(userName);
            return JsonConvert.SerializeObject(reservations);
        }

       

        /// <summary>
        /// 根据用户Id值获取银行卡账号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       public string  GetCustomerAccountByKey(string  id)
        {
            var reservation = customerServiceImp.GetCustomerAccountByKey(new Guid(id));
            return JsonConvert.SerializeObject(reservation);
        }


        /// <summary>
        /// 根据用户名获取用户银行卡信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
       public string  GetCustomerAccountsByName(string userName)
        {
            var reservation = customerServiceImp.GetCustomerAccountsByName(userName);
            return JsonConvert.SerializeObject(reservation);
        }

        /// <summary>
        /// 创建银行卡账号
        /// </summary>
        /// <param name="customerAccountDataObject">需要创建的银行卡账号</param>
        /// <param name="userId">消费者Id值</param>
        /// <returns></returns>
       public void PostCustomerAccount(string  userId, List<CustomerAccountDataObject> customerAccountDataObject)
        {
            customerServiceImp.AddCustomerAccount(new Guid(userId), customerAccountDataObject);
        }

        /// <summary>
        /// 删除银行卡账号
        /// </summary>
        /// <param name="customerAccountDataObject">需要删除的银行卡账号</param>
        /// <param name="userId">消费者id值</param>
       public void DeleteCustomerAccount(string  userId, List<CustomerAccountDataObject> customerAccountDataObject)
        {
            customerServiceImp.DeleteCustomerAccount(new Guid(userId), customerAccountDataObject);
        }


        /// <summary>
        /// 更新银行卡信息
        /// </summary>
        /// <param name="customerAccountDataObject">需要更新的银行卡信息</param>
        /// <param name="userId">消费者id值</param>
        /// <returns></returns>
       public string  PutCustomerAccount(string  userId, List<CustomerAccountDataObject> customerAccountDataObject)
        {
           var  customerAccounts =  customerServiceImp.UpdateCustomerAccount(new Guid(userId), customerAccountDataObject);
            return JsonConvert.SerializeObject(customerAccounts);
        }
    }
}
