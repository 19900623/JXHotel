using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;
using JXHotel.Domain.Repository;

namespace JXHotel.Domain.Service
{
    /// <summary>
    /// 酒店用户与酒店用户角色聚合服务
    /// </summary>
    public class HotelUserRoleService : IHotelUserRoleService
    {
        private readonly IRepositoryContext repositoryContext;
        private readonly IHotelUserRepository hotelUserRepository;
        private readonly IHotelRoleRepository hotelRoleRepository;

        public HotelUserRoleService(IRepositoryContext repositoryContext,IHotelUserRepository hotelUserRepository,IHotelRoleRepository hotelRoleRepository)
        {
            this.repositoryContext = repositoryContext;
            this.hotelUserRepository = hotelUserRepository;
            this.hotelRoleRepository = hotelRoleRepository;
        }

        public void AssignRole(Guid userID, Guid roleID)
        {
            HotelUser hotelUser = hotelUserRepository.GetByKey(userID);
            hotelUser.HotelRoleId = roleID;
            hotelUserRepository.Update(hotelUser);
            repositoryContext.Commit();
        }
    }
}
