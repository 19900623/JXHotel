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
    public class AppUserController : ApiController
    {
        private readonly IAppUserService appUserServiceImp = ServiceLocator.Instance.GetService<IAppUserService>();

        // GET: api/AppUser
        public string Get()
        {
            var users = appUserServiceImp.GetUsers(QuerySpec.Empty);
            return JsonConvert.SerializeObject(users);
        }

        // GET: api/AppUser/5
        public string GetByKey(string id)
        {
            var user = appUserServiceImp.GetUserByKey(new Guid(id), QuerySpec.Empty);
            return JsonConvert.SerializeObject(user);
        }

        public string GetByEmail(string email)
        {
            var user = appUserServiceImp.GetUserByEmail(email, QuerySpec.Empty);
            return JsonConvert.SerializeObject(user);
        }

        public string GetByName(string name)
        {
            var user = appUserServiceImp.GetUserByName(name, QuerySpec.Empty);
            return JsonConvert.SerializeObject(user);
        }

        public string GetValidate(string userName, string password)
        {
            bool isValidate = appUserServiceImp.ValidateUser(userName, password);
            return JsonConvert.SerializeObject(isValidate);
        }


        // POST: api/AppUser
        public string Post(List<AppUserDataObject> userDataObject)
        {
            var users = appUserServiceImp.CreateUser(userDataObject);
            return JsonConvert.SerializeObject(users);
        }

        // PUT: api/AppUser/5
        public string Put(List<AppUserDataObject> userDataObject)
        {
            var users = appUserServiceImp.UpdateUser(userDataObject);
            return JsonConvert.SerializeObject(users);
        }

        // DELETE: api/AppUser/5
        public void Delete(List<string> userIds)
        {
            appUserServiceImp.DeleteUser(userIds);
        }




        /// <summary>
        /// 获取所有角色。
        /// </summary>
        /// <returns>所有角色。</returns>   
        public string GetRoles()
        {
            var roles = appUserServiceImp.GetRoles();
            return JsonConvert.SerializeObject(roles);
        }


        /// <summary>
        /// 根据指定的ID值，获取角色。
        /// </summary>
        /// <param name="id">指定的角色ID值。</param>
        /// <returns>角色。</returns>
        public string GetRoleByKey(string id)
        {
            var role = appUserServiceImp.GetRoleByKey(new Guid(id));
            return JsonConvert.SerializeObject(role);
        }

        /// <summary>
        /// 根据指定的角色名，获取角色。
        /// </summary>
        /// <param name="name">角色名</param>
        /// <returns>角色</returns>
        public string GetRoleByName(string name)
        {
            var role = appUserServiceImp.GetRoleByName(name);
            return JsonConvert.SerializeObject(role);
        }

        /// <summary>
        /// 创建角色。
        /// </summary>
        /// <param name="roleDataObject">需要创建的角色。</param>
        /// <returns>已创建的角色。</returns>
        public string PostRole(List<AppRoleDataObject> roleDataObject)
        {
            var roles = appUserServiceImp.CreateRole(roleDataObject);
            return JsonConvert.SerializeObject(roles);
        }


        /// <summary>
        /// 更新角色。
        /// </summary>
        /// <param name="roleDataObject">需要更新的角色。</param>
        /// <returns>已更新的角色。</returns>
        public string  PutRole(List<AppRoleDataObject> roleDataObject)
        {
            var roles = appUserServiceImp.UpdateRole(roleDataObject);
            return JsonConvert.SerializeObject(roles);
        }

        /// <summary>
        /// 删除角色。
        /// </summary>
        /// <param name="roleID">需要删除的角色ID值。</param>
       public void DeleteRoles(List<string> roleID)
        {
            appUserServiceImp.DeleteRoles(roleID);
        }

        /// <summary>
        /// 将指定的用户赋予指定的角色。
        /// </summary>
        /// <param name="userID">需要赋予角色的用户ID值。</param>
        /// <param name="roleID">需要向用户赋予的角色ID值。</param>
       public void PutAssignRole(string  userID, string roleID)
        {
            appUserServiceImp.AssignRole(new Guid(userID), new Guid(roleID));
        }



        /// <summary>
        /// 根据指定的用户名，获取该用户所属的角色。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <returns>角色。</returns>
       public  string  GetRoleByUserName(string userName)
        {
            var role = appUserServiceImp.GetUserRoleByUserName(userName);
            return JsonConvert.SerializeObject(role);
        }


    }
}
