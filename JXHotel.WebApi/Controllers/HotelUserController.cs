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
    public class HotelUserController : ApiController
    {
        private readonly IHotelUserService hotelUserServiceImp = ServiceLocator.Instance.GetService<IHotelUserService>();

        /// <summary>
        ///创建用户
        /// </summary>
        /// <param name="userDataObject"></param>
        /// <returns></returns>
        public string Post(List<HotelUserDataObject> userDataObject)
        {
            var hotelUsers = hotelUserServiceImp.CreateUser(userDataObject);
            return JsonConvert.SerializeObject(hotelUsers);
        }


        /// <summary>
        /// 验证用户密码
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string GetValidate(string userName, string password)
        {
            var isValidate = hotelUserServiceImp.ValidateUser(userName, password);
            return JsonConvert.SerializeObject(isValidate);
        }


        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userDataObject"></param>
        /// <returns></returns>
        public string Put(List<HotelUserDataObject> userDataObject)
        {
            var hotelUsers = hotelUserServiceImp.UpdateUser(userDataObject);
            return JsonConvert.SerializeObject(hotelUsers);
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userIds"></param>
        public void DeleteUser(List<string> userIds)
        {
            hotelUserServiceImp.DeleteUser(userIds);
        }

        /// <summary>
        /// 根据用户的全局唯一标识获取用户信息。
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetByKey(string ID)
        {
            var hotelUser = hotelUserServiceImp.GetUserByKey(new Guid(ID), QuerySpec.Empty);
            return JsonConvert.SerializeObject(hotelUser);
        }


        /// <summary>
        /// 根据用户的电子邮件地址获取用户信息。
        /// </summary>
        /// <param name="email">用户的电子邮件地址。</param>
        /// <returns>包含了用户信息的数据传输对象。</returns>
        public string GetByEmail(string email)
        {
            var hotelUser = hotelUserServiceImp.GetUserByEmail(email, QuerySpec.Empty);
            return JsonConvert.SerializeObject(hotelUser);
        }

        /// <summary>
        /// 根据用户的用户名获取用户信息。
        /// </summary>
        /// <param name="userName">用户的用户名。</param>
        /// <returns>包含了用户信息的数据传输对象。</returns>
        public string GetUserByName(string userName)
        {
            var hotelUser = hotelUserServiceImp.GetUserByName(userName, QuerySpec.Empty);
            return JsonConvert.SerializeObject(hotelUser);
        }

        /// <summary>
        /// 获取所有用户的信息。
        /// </summary>
        /// <param name="spec">查询方式。</param>
        /// <returns>包含了所有用户信息的数据传输对象列表。</returns>
        public string Get()
        {
            var hotelUsers = hotelUserServiceImp.GetUsers(QuerySpec.Empty);
            return JsonConvert.SerializeObject(hotelUsers);
        }



        /// <summary>
        /// 获取所有角色。
        /// </summary>
        /// <returns>所有角色。</returns>   
        public string GetRoles()
        {
            var roles = hotelUserServiceImp.GetRoles();
            return JsonConvert.SerializeObject(roles);
        }


        /// <summary>
        /// 根据指定的ID值，获取角色。
        /// </summary>
        /// <param name="id">指定的角色ID值。</param>
        /// <returns>角色。</returns>
        public string GetRoleByKey(string id)
        {
            var role = hotelUserServiceImp.GetRoleByKey(new Guid(id));
            return JsonConvert.SerializeObject(role);
        }

        /// <summary>
        /// 根据指定的角色名，获取角色。
        /// </summary>
        /// <param name="name">角色名</param>
        /// <returns>角色</returns>
        public string GetRoleByName(string name)
        {

            var role = hotelUserServiceImp.GetRoleByName(name);
            return JsonConvert.SerializeObject(role);
        }

        /// <summary>
        /// 创建角色。
        /// </summary>
        /// <param name="roleDataObject">需要创建的角色。</param>
        /// <returns>已创建的角色。</returns>
        public string PostRole(List<HotelRoleDataObject> roleDataObject)
        {
            var roles = hotelUserServiceImp.CreateRole(roleDataObject);
            return JsonConvert.SerializeObject(roles);
        }


        /// <summary>
        /// 更新角色。
        /// </summary>
        /// <param name="roleDataObject">需要更新的角色。</param>
        /// <returns>已更新的角色。</returns>
        public string PutRole(List<HotelRoleDataObject> roleDataObject)
        {
            var roles = hotelUserServiceImp.UpdateRole(roleDataObject);
            return JsonConvert.SerializeObject(roles);
        }

        /// <summary>
        /// 删除角色。
        /// </summary>
        /// <param name="roleID">需要删除的角色ID值。</param>
        public void DeleteRoles(List<string> roleID)
        {
            hotelUserServiceImp.DeleteRoles(roleID);
        }

        /// <summary>
        /// 将指定的用户赋予指定的角色。
        /// </summary>
        /// <param name="userID">需要赋予角色的用户ID值。</param>
        /// <param name="roleID">需要向用户赋予的角色ID值。</param>
        public void PutAssignRole(string userID, string roleID)
        {
            hotelUserServiceImp.AssignRole(new Guid(userID), new Guid(roleID));
        }



        /// <summary>
        /// 根据指定的用户名，获取该用户所属的角色。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <returns>角色。</returns>
        public string GetRoleByUserName(string userName)
        {
            var role = hotelUserServiceImp.GetUserRoleByUserName(userName);
            return JsonConvert.SerializeObject(role);
        }
    }
}
