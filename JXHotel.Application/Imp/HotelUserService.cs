using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JXHotel.Application.Contract;
using JXHotel.Domain.Model;
using JXHotel.Domain.Repository;
using JXHotel.Domain.Service;
using JXHotel.Domain.Specification;
using JXHotel.Repository.Specification;
using JXHotel.DataObject;

namespace JXHotel.Application.Imp
{  
    /// <summary>
    /// 酒店用户应用层
    /// </summary>
    public class HotelUserService : ApplicationService, IHotelUserService
    {
        private readonly IHotelUserRepository hotelUserRepository;
        private readonly IHotelRoleRepository hotelRoleRepository;
        private readonly IHotelUserRoleService hotelUserRoleService;
        private readonly IHotelRepository hotelRepository;

        public HotelUserService(IRepositoryContext context,IHotelUserRepository hotelUserRepository
                                                          ,IHotelRoleRepository hotelRoleRepository
                                                          ,IHotelRepository hotelRepository
                                                          ,IHotelUserRoleService hotelUserRoleService) : base(context)
        {
            this.hotelUserRepository = hotelUserRepository;
            this.hotelRoleRepository = hotelRoleRepository;
            this.hotelRepository = hotelRepository;
            this.hotelUserRoleService = hotelUserRoleService;
        }

        public void AssignRole(Guid userID, Guid roleID)
        {
            hotelUserRoleService.AssignRole(userID, roleID);
        }

        public List<HotelRoleDataObject> CreateRole(List<HotelRoleDataObject> roleDataObject)
        {
            return this.PerformCreateObjects<List<HotelRoleDataObject>, HotelRoleDataObject, HotelRole>(roleDataObject, hotelRoleRepository);
        }

        public List<HotelUserDataObject> CreateUser(List<HotelUserDataObject> userDataObject)
        {
            return this.PerformCreateObjects<List<HotelUserDataObject>, HotelUserDataObject, HotelUser>(userDataObject, hotelUserRepository);
        }

        public void DeleteRoles(List<string> roleID)
        {
            this.PerformDeleteObjects<HotelRole>(roleID, hotelRoleRepository);
        }

        public void DeleteUser(List<string> userIds)
        {
            this.PerformDeleteObjects<HotelUser>(userIds, hotelUserRepository);
        }

        public HotelDataObject GetHotelById(Guid UserId)
        {
            HotelUser hotelUser = hotelUserRepository.GetByKey(UserId);
            Hotel hotel = hotelRepository.GetByKey(hotelUser.HotelId);
            return AutoMapper.Mapper.Map<Hotel, HotelDataObject>(hotel);

        }

        public HotelDataObject GetHotelByName(string userName)
        {
            HotelUser hotelUser = hotelUserRepository.GetUserByName(userName);
            Hotel hotel = hotelRepository.GetByKey(hotelUser.HotelId);
            return AutoMapper.Mapper.Map<Hotel, HotelDataObject>(hotel);
        }

        public HotelRoleDataObject GetRoleByKey(Guid id)
        {
            HotelRole hotelRole = hotelRoleRepository.GetByKey(id);
            HotelRoleDataObject hotelRoleDataObject = AutoMapper.Mapper.Map<HotelRole, HotelRoleDataObject>(hotelRole);
            return hotelRoleDataObject;
        }

        public HotelRoleDataObject GetRoleByName(string name)
        {
            HotelRole hotelRole = hotelRoleRepository.Find(Specification<HotelRole>.Eval(cr => cr.Name.Equals(name)));
            HotelRoleDataObject hotelRoleDataObject = AutoMapper.Mapper.Map<HotelRole, HotelRoleDataObject>(hotelRole);
            return hotelRoleDataObject;
        }

        public List<HotelRoleDataObject> GetRoles()
        {
            var roles = hotelRoleRepository.FindAll();
            List<HotelRoleDataObject> hotelRoleDataObjects = AutoMapper.Mapper.Map<List<HotelRole>, List<HotelRoleDataObject>>(roles.ToList());
            return hotelRoleDataObjects;
        }

        public HotelUserDataObject GetUserByEmail(string email, QuerySpec spec)
        {
            HotelUser hotelUser;
            if (spec.Verbose)
            {
                hotelUser = hotelUserRepository.GetUserByEmail(email);
            }
            else
            {
                hotelUser = hotelUserRepository.Find(new UserNameEqualsSpecification<HotelUser>(email), cer => cer.HotelRole);
            }
            HotelUserDataObject hotelUserDataObject = AutoMapper.Mapper.Map<HotelUser, HotelUserDataObject>(hotelUser);
            return hotelUserDataObject;
        }

        public HotelUserDataObject GetUserByKey(Guid ID, QuerySpec spec)
        {
            HotelUser hotelUser;
            if (spec.Verbose)
            {
                hotelUser = hotelUserRepository.GetByKey(ID);
            }
            else
            {
                hotelUser = hotelUserRepository.Find(Specification<HotelUser>.Eval(cer => cer.Id.Equals(ID)), cer => cer.HotelRole);
            }
            HotelUserDataObject hotelUserDataObject = AutoMapper.Mapper.Map<HotelUser, HotelUserDataObject>(hotelUser);
            return hotelUserDataObject;
        }

        public HotelUserDataObject GetUserByName(string userName, QuerySpec spec)
        {
            HotelUser hotelUser;
            if (spec.Verbose)
            {
                hotelUser = hotelUserRepository.GetUserByName(userName);
            }
            else
            {
                hotelUser = hotelUserRepository.Find(new UserNameEqualsSpecification<HotelUser>(userName), cer => cer.HotelRole);
            }
            HotelUserDataObject hotelUserDataObject = AutoMapper.Mapper.Map<HotelUser, HotelUserDataObject>(hotelUser);
            return hotelUserDataObject;
        }

        public HotelRoleDataObject GetUserRoleByUserName(string userName)
        {
            HotelUser hotelUser = hotelUserRepository.GetUserByName(userName);
            HotelRole hotelrole = hotelRoleRepository.GetByKey(hotelUser.HotelRoleId);
            return AutoMapper.Mapper.Map<HotelRole, HotelRoleDataObject>(hotelrole);
        }

        public List<HotelUserDataObject> GetUsers(QuerySpec spec)
        {
            IEnumerable<HotelUser> hotelUsers;
            if (spec.Verbose)
            {
                hotelUsers = hotelUserRepository.FindAll();
            }
            else
            {
                hotelUsers = hotelUserRepository.FindAll(new AnySpecification<HotelUser>(), cer => cer.HotelRole);
            }
            List<HotelUserDataObject> hotelUserDataObjects = AutoMapper.Mapper.Map<List<HotelUser>, List<HotelUserDataObject>>(hotelUsers.ToList());
            return hotelUserDataObjects;
        }

        public List<HotelRoleDataObject> UpdateRole(List<HotelRoleDataObject> roleDataObject)
        {
            return this.PerformUpdateObjects<List<HotelRoleDataObject>, HotelRoleDataObject, HotelRole>(roleDataObject, hotelRoleRepository
                                                                                                                                , role => role.Id.ToString()
                                                                                                                                , null);
        }

        public List<HotelUserDataObject> UpdateUser(List<HotelUserDataObject> userDataObject)
        {
            return this.PerformUpdateObjects<List<HotelUserDataObject>, HotelUserDataObject, HotelUser>(userDataObject, hotelUserRepository
                                                                                             , cdo => cdo.Id.ToString()
                                                                                             , null);
        }

        public bool ValidateUser(string userName, string password)
        {
            bool isValidate = hotelUserRepository.CheckPassword(userName, password);
            return isValidate;
        }
    }
}
