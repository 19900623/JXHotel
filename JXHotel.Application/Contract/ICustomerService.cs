using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.DataObject;

namespace JXHotel.Application.Contract
{
    /// <summary>
    /// 消费者应用层
    /// </summary>
  public  interface ICustomerService :IUserService<CustomerDataObject,CustomerRoleDataObject>
    {

        
        /// <summary>
        /// 根据用户名获取用户预定信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        List<ReservationDataObject> GetReservations(string userName);

        ///// <summary>
        ///// 获取所有银行卡账号
        ///// </summary>
        ///// <returns></returns>
        //List<CustomerAccountDataObject> GetCustomerAccounts();

        /// <summary>
        /// 根据用户Id值获取银行卡账号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<CustomerAccountDataObject> GetCustomerAccountByKey(Guid id);


        /// <summary>
        /// 根据用户名获取用户银行卡信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        List<CustomerAccountDataObject>  GetCustomerAccountsByName(string userName);

        /// <summary>
        /// 创建银行卡账号
        /// </summary>
        /// <param name="customerAccountDataObject">需要创建的银行卡账号</param>
        /// <param name="userId">消费者Id值</param>
        /// <returns></returns>
        void AddCustomerAccount(Guid userId,List<CustomerAccountDataObject> customerAccountDataObject);

        /// <summary>
        /// 删除银行卡账号
        /// </summary>
        /// <param name="customerAccountDataObject">需要删除的银行卡账号</param>
        /// <param name="userId">消费者id值</param>
        void DeleteCustomerAccount(Guid userId,List<CustomerAccountDataObject> customerAccountDataObject);


        /// <summary>
        /// 更新银行卡信息
        /// </summary>
        /// <param name="customerAccountDataObject">需要更新的银行卡信息</param>
        /// <param name="userId">消费者id值</param>
        /// <returns></returns>
        List<CustomerAccountDataObject> UpdateCustomerAccount(Guid userId,List<CustomerAccountDataObject> customerAccountDataObject);


        ///// <summary>
        ///// 将指定的账号赋予指定的用户。
        ///// </summary>
        ///// <param name="CustomerAccountID">需要赋予用户的账号ID值。</param>
        ///// <param name="CustomerID">用户ID值。</param>
        //void AssignAccount(Guid CustomerAccountID, Guid CustomerID);

        ///// <summary>
        ///// 将指定的用户账号从用户中移除。
        ///// </summary>
        ///// <param name="CustomerAccount">账号ID值。</param>
        //void UnassignAccount(Guid CustomerAccount);




    }
}
