using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.DataObject;

namespace JXHotel.Application.Contract
{
    /// <summary>
    /// App银行账号应用层
    /// </summary>
  public  interface IAppAccountService
    {
        /// <summary>
        /// 新增app银行卡账号
        /// </summary>
        /// <param name="appAccountDataObject"></param>
        /// <returns></returns>
        List<AppAccountDataObject> CreateAppAccount(List<AppAccountDataObject> appAccountDataObject);

        /// <summary>
        /// 获取所有app银行卡账号
        /// </summary>
        /// <returns></returns>
        List<AppAccountDataObject>  GetAppAccount();

        /// <summary>
        /// 根据账号Id值获取账号
        /// </summary>
        /// <param name="id">账号Id值</param>
        /// <returns></returns>
        AppAccountDataObject GetAppAccountByKey(Guid id);


        /// <summary>
        /// 根据账号名称获取账号
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        AppAccountDataObject GetAppAccountByName(string name);

        /// <summary>
        ///  删除app账号
        /// </summary>
        /// <param name="ids">需要删除的app账号</param>
        void DeleteAppAccount(List<string> ids);


        /// <summary>
        ///  更新app账号
        /// </summary>
        /// <param name="appAccountDataObject">需要更新的app账号</param>
        /// <returns></returns>
        List<AppAccountDataObject> UpdateAppAccount(List<AppAccountDataObject> appAccountDataObject);





    }
}
