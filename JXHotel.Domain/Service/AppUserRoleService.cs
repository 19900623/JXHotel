using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Repository;
using JXHotel.Domain.Model;

namespace JXHotel.Domain.Service
{
    /// <summary>
    /// appuser聚合与appuserrole聚合服务
    /// </summary>
    public class AppUserRoleService : IAppUserRoleService
    {
        private readonly IRepositoryContext repositoryContext;
        private readonly IAppUserRepository appUserRepository;
        private readonly IAppRoleRepository appRoleRepository;

        public AppUserRoleService(IRepositoryContext repositoryContext,IAppUserRepository appUserRepository,IAppRoleRepository appRoleRepository)
        {
            this.repositoryContext = repositoryContext;
            this.appUserRepository = appUserRepository;
            this.appRoleRepository = appRoleRepository;
        }

        public void AssignRole(Guid userID, Guid roleID)
        {
            AppUser appUser = appUserRepository.GetByKey(userID);
            appUser.AppRoleId = roleID;
            appUserRepository.Update(appUser);
            repositoryContext.Commit();
        }
    }
}
