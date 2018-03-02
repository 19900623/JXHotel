using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Repository;
using JXHotel.Domain.Model;

namespace JXHotel.Domain.Service
{
    public class HotelPromotionCustomerRoleService : IHotelPromotionCustomerRoleService 
    {
        private readonly IRepositoryContext repositoryContext;
        private readonly ICustomerRoleRepository customerRoleRepository;
        private readonly IHotelPromotionRepository<HotelPromotion> hotelPromotionRepository;

        public HotelPromotionCustomerRoleService(IRepositoryContext repositoryContext, ICustomerRoleRepository customerRepository
                                                                                      , IHotelPromotionRepository<HotelPromotion> hotelPromotionRepository)
        {
            this.repositoryContext = repositoryContext;
            this.customerRoleRepository = customerRepository;
            this.hotelPromotionRepository = hotelPromotionRepository;
        }

        /// <summary>
        /// 将活动指向消费者角色
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <param name="CustomerRoleID"></param>
        public void AssignCustomerRole(Guid hotelPromotionId, Guid CustomerRoleID)
        {
            HotelPromotion hotelPromotion  = hotelPromotionRepository.GetByKey(hotelPromotionId);
            CustomerRole customerRole = customerRoleRepository.GetByKey(CustomerRoleID);
            hotelPromotion.CustomerRoles.Add(customerRole);
            hotelPromotionRepository.Update(hotelPromotion);
            repositoryContext.Commit();

        }

        /// <summary>
        /// 将活动从消费者角色中移除
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <param name="CustomerRoleID"></param>
        public void UnassignCustomerRole(Guid hotelPromotionId, Guid CustomerRoleID)
        {
            HotelPromotion hotelPromotion = hotelPromotionRepository.GetByKey(hotelPromotionId);
            CustomerRole customerRole = customerRoleRepository.GetByKey(CustomerRoleID);
            hotelPromotion.CustomerRoles.Remove(customerRole);
            hotelPromotionRepository.Update(hotelPromotion);
            repositoryContext.Commit();
        }
    }
}
