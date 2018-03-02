using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;
using JXHotel.Domain.Repository;
using JXHotel.Repository.Specification;

namespace JXHotel.Repository
{
    public class CustomerRoleRepository : RoleRepository<CustomerRole, Customer>,ICustomerRoleRepository
    {
        public CustomerRoleRepository(IRepositoryContext context) : base(context)
        {
        }

        public override CustomerRole GetRoleForUser(Customer user)
        {
            var  context= this.EFContext.dbContext as JXHotelDbContext;
            return context.Customer.Find(user.Id).CustomerRole;
        }

       public   List<CustomerRole> GetCustomerRoleByHotelPromotionId(Guid hotelPromotionId)
        {
            var context = this.EFContext.dbContext as JXHotelDbContext;
            return  context.HotelPromotions.Find(hotelPromotionId).CustomerRoles.ToList();
             
        }

        public List<CustomerRole> GetCustomerRoleByHotelPromotionName(string hotelPromotionName)
        {
            var context = this.EFContext.dbContext as JXHotelDbContext;
            return  context.HotelPromotions.Where(new HotelPromotionNameEqualSpecification(hotelPromotionName).GetExpression()).FirstOrDefault().CustomerRoles;
        }
    }
}
