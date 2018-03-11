using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JXHotel.Infrastructure;
using JXHotel.Application.Contract;
using JXHotel.DataObject;
using Newtonsoft.Json;

namespace JXHotel.WebApi.Controllers
{
    public class AppAccountController : ApiController
    {

        private readonly IAppAccountService appAccountServiceImp = ServiceLocator.Instance.GetService<IAppAccountService>();

        /// <summary>
        /// 获取所有app银行卡账号
        /// </summary>
        /// <returns></returns>
        public string Get()
        {
           
             var  dtos = appAccountServiceImp.GetAppAccount();
             return JsonConvert.SerializeObject(dtos);          
        }

        /// <summary>
        /// 根据账号Id值获取账号
        /// </summary>
        /// <param name="id">账号Id值</param>
        /// <returns></returns>
        string GetByKey(string  id)
        {
            var  dto = appAccountServiceImp.GetAppAccountByKey(new Guid(id));
            return JsonConvert.SerializeObject(dto);
        }


        /// <summary>
        /// 根据账号名称获取账号
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        string GetByName(string name)
        {
            var dto = appAccountServiceImp.GetAppAccountByName(name);
            return JsonConvert.SerializeObject(dto);
        }


        /// <summary>
        /// 新增app银行卡账号
        /// </summary>
        /// <param name="appAccountDataObject"></param>
        /// <returns></returns>
         public  string  Post(List<AppAccountDataObject> appAccountDataObject)
         {
            var dtos = appAccountServiceImp.CreateAppAccount(appAccountDataObject);
            return JsonConvert.SerializeObject(dtos);
         }

        // PUT: api/AppAccount/5
        public string Put(List<AppAccountDataObject> appAccountDataObject)
        {
            var dtos = appAccountServiceImp.UpdateAppAccount(appAccountDataObject);
            return JsonConvert.SerializeObject(dtos);
        }

        // DELETE: api/AppAccount/5
        public void Delete(List<string> ids)
        {
            appAccountServiceImp.DeleteAppAccount(ids);
        }
    }
}
