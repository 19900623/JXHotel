using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JXHotel.Application.Contract;
using JXHotel.DataObject;
using JXHotel.Domain.Repository;
using JXHotel.Domain.Specification;
using JXHotel.Domain.Service;
using JXHotel.Domain.Model;
using JXHotel.Repository.Specification;

namespace JXHotel.Application.Imp
{
    /// <summary>
    /// app用户应用层
    /// </summary>
    public class AppUserService : ApplicationService,IAppUserService
    {

        private readonly IAppUserRepository appUserRepository;
        private readonly IAppRoleRepository appRoleRepository;
        private readonly IAppUserRoleService appUserRoleService;

        public AppUserService(IRepositoryContext context,IAppUserRepository appUserRepository
                                                         ,IAppRoleRepository appRoleRepository
                                                         ,IAppUserRoleService appUserRoleService) : base(context)
        {
            this.appUserRepository = appUserRepository;
            this.appRoleRepository = appRoleRepository;
            this.appUserRoleService = appUserRoleService;
        }

        public void AssignRole(Guid userID, Guid roleID)
        {
            appUserRoleService.AssignRole(userID, roleID);
        }

        public List<AppRoleDataObject> CreateRole(List<AppRoleDataObject> roleDataObject)
        {
            return this.PerformCreateObjects<List<AppRoleDataObject>, AppRoleDataObject, AppRole>(roleDataObject, appRoleRepository);
        }

        public List<AppUserDataObject> CreateUser(List<AppUserDataObject> userDataObject)
        {
            return this.PerformCreateObjects<List<AppUserDataObject>, AppUserDataObject, AppUser>(userDataObject, appUserRepository);
        }

        public void DeleteRoles(List<string> roleID)
        {
            this.PerformDeleteObjects<AppRole>(roleID, appRoleRepository);
        }

        public void DeleteUser(List<string> userIds)
        {
            this.PerformDeleteObjects<AppUser>(userIds, appUserRepository);
        }

        public AppRoleDataObject GetRoleByKey(Guid id)
        {
            AppRole appRole = appRoleRepository.GetByKey(id);
            AppRoleDataObject appRoleDataObject = AutoMapper.Mapper.Map<AppRole, AppRoleDataObject>(appRole);
            return appRoleDataObject;
        }

        public AppRoleDataObject GetRoleByName(string name)
        {
            AppRole AppRole = appRoleRepository.Find(Specification<AppRole>.Eval(cr => cr.Name.Equals(name)));
            AppRoleDataObject appRoleDataObject = AutoMapper.Mapper.Map<AppRole, AppRoleDataObject>(AppRole);
            return appRoleDataObject;
        }

        public List<AppRoleDataObject> GetRoles()
        {
            var roles = appRoleRepository.FindAll();
            List<AppRoleDataObject> appRoleDataObjects = AutoMapper.Mapper.Map<List<AppRole>, List<AppRoleDataObject>>(roles.ToList());
            return appRoleDataObjects;
        }

        public AppUserDataObject GetUserByEmail(string email, QuerySpec spec)
        {
            AppUser appUser;
            if (spec.Verbose)
            {
                appUser = appUserRepository.GetUserByEmail(email);
            }
            else
            {
                appUser = appUserRepository.Find(new UserNameEqualsSpecification<AppUser>(email), cer => cer.AppRole);
            }
            AppUserDataObject appUserDataObject = AutoMapper.Mapper.Map<AppUser, AppUserDataObject>(appUser);
            return appUserDataObject;
        }

        public AppUserDataObject GetUserByKey(Guid ID, QuerySpec spec)
        {
            AppUser appUser;
            if (spec.Verbose)
            {
                appUser = appUserRepository.GetByKey(ID);
            }
            else
            {
                appUser = appUserRepository.Find(Specification<AppUser>.Eval(cer => cer.Id.Equals(ID)), cer => cer.AppRole);
            }
            AppUserDataObject appUserDataObject = AutoMapper.Mapper.Map<AppUser, AppUserDataObject>(appUser);
            return appUserDataObject;
        }

        public AppUserDataObject GetUserByName(string userName, QuerySpec spec)
        {
            AppUser appUser;
            if (spec.Verbose)
            {
                appUser = appUserRepository.GetUserByName(userName);
            }
            else
            {
                appUser = appUserRepository.Find(new UserNameEqualsSpecification<AppUser>(userName), cer => cer.AppRole);
            }
            AppUserDataObject appUserDataObject = AutoMapper.Mapper.Map<AppUser, AppUserDataObject>(appUser);
            return appUserDataObject;
        }

        public AppRoleDataObject GetUserRoleByUserName(string userName)
        {
            AppUser appUser = appUserRepository.GetUserByName(userName);
            AppRole approle = appRoleRepository.GetByKey(appUser.AppRoleId);
            return AutoMapper.Mapper.Map<AppRole, AppRoleDataObject>(approle);
        }

        public List<AppUserDataObject> GetUsers(QuerySpec spec)
        {
            IEnumerable<AppUser> appUsers;
            if (spec.Verbose)
            {
                appUsers = appUserRepository.FindAll();
            }
            else
            {
                appUsers = appUserRepository.FindAll(new AnySpecification<AppUser>(), cer => cer.AppRole);
            }
            List<AppUserDataObject> appUserDataObjects = AutoMapper.Mapper.Map<List<AppUser>, List<AppUserDataObject>>(appUsers.ToList());
            return appUserDataObjects;
        }

        public List<AppRoleDataObject> UpdateRole(List<AppRoleDataObject> roleDataObject)
        {
            return this.PerformUpdateObjects<List<AppRoleDataObject>, AppRoleDataObject, AppRole>(roleDataObject, appRoleRepository
                                                                                                                                , role => role.Id.ToString()
                                                                                                                                , null);
        }

        public List<AppUserDataObject> UpdateUser(List<AppUserDataObject> userDataObject)
        {
            return this.PerformUpdateObjects<List<AppUserDataObject>, AppUserDataObject, AppUser>(userDataObject, appUserRepository
                                                                                             , cdo => cdo.Id.ToString()
                                                                                             , null);
        }

        public bool ValidateUser(string userName, string password)
        {
            bool isValidate = appUserRepository.CheckPassword(userName, password);
            return isValidate;
        }
    }
}
