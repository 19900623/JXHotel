using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.DataObject;

namespace JXHotel.Application.Contract
{
    /// <summary>
    /// 用户应用层
    /// </summary>
  public  interface IUserService<TUserDataObject, TRoleDataObject>  where TUserDataObject:UserDataObject where TRoleDataObject :RoleDataObject
    {
        /// <summary>
        ///创建用户
        /// </summary>
        /// <param name="userDataObject"></param>
        /// <returns></returns>
        List<TUserDataObject> CreateUser(List<TUserDataObject> userDataObject);


        /// <summary>
        /// 验证用户密码
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool ValidateUser(string userName, string password);


        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userDataObject"></param>
        /// <returns></returns>
        List<TUserDataObject> UpdateUser(List<TUserDataObject> userDataObject);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="userIds"></param>
        void DeleteUser(List<string> userIds);

        /// <summary>
        /// 根据用户的全局唯一标识获取用户信息。
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="spec">查询方式</param>
        /// <returns></returns>
        TUserDataObject GetUserByKey(Guid ID, QuerySpec spec);


        /// <summary>
        /// 根据用户的电子邮件地址获取用户信息。
        /// </summary>
        /// <param name="email">用户的电子邮件地址。</param>
        /// <param name="spec">查询方式。</param>
        /// <returns>包含了用户信息的数据传输对象。</returns>
        TUserDataObject GetUserByEmail(string email, QuerySpec spec);

        /// <summary>
        /// 根据用户的用户名获取用户信息。
        /// </summary>
        /// <param name="userName">用户的用户名。</param>
        /// <param name="spec">查询方式。</param>
        /// <returns>包含了用户信息的数据传输对象。</returns>
        TUserDataObject GetUserByName(string userName, QuerySpec spec);

        /// <summary>
        /// 获取所有用户的信息。
        /// </summary>
        /// <param name="spec">查询方式。</param>
        /// <returns>包含了所有用户信息的数据传输对象列表。</returns>
        List<TUserDataObject> GetUsers(QuerySpec spec);



        /// <summary>
        /// 获取所有角色。
        /// </summary>
        /// <returns>所有角色。</returns>   
        List<TRoleDataObject> GetRoles();


        /// <summary>
        /// 根据指定的ID值，获取角色。
        /// </summary>
        /// <param name="id">指定的角色ID值。</param>
        /// <returns>角色。</returns>
        TRoleDataObject GetRoleByKey(Guid id);

        /// <summary>
        /// 根据指定的角色名，获取角色。
        /// </summary>
        /// <param name="name">角色名</param>
        /// <returns>角色</returns>
        TRoleDataObject GetRoleByName(string name);

        /// <summary>
        /// 创建角色。
        /// </summary>
        /// <param name="roleDataObject">需要创建的角色。</param>
        /// <returns>已创建的角色。</returns>
        List<TRoleDataObject> CreateRole(List<TRoleDataObject> roleDataObject);


        /// <summary>
        /// 更新角色。
        /// </summary>
        /// <param name="roleDataObject">需要更新的角色。</param>
        /// <returns>已更新的角色。</returns>
        List<TRoleDataObject> UpdateRole(List<TRoleDataObject> roleDataObject);

        /// <summary>
        /// 删除角色。
        /// </summary>
        /// <param name="roleID">需要删除的角色ID值。</param>
        void DeleteRoles(List<string>  roleID);

        /// <summary>
        /// 将指定的用户赋予指定的角色。
        /// </summary>
        /// <param name="userID">需要赋予角色的用户ID值。</param>
        /// <param name="roleID">需要向用户赋予的角色ID值。</param>
        void AssignRole(Guid userID, Guid roleID);

       

        /// <summary>
        /// 根据指定的用户名，获取该用户所属的角色。
        /// </summary>
        /// <param name="userName">用户名。</param>
        /// <returns>角色。</returns>
        TRoleDataObject GetUserRoleByUserName(string userName);




    }
}
