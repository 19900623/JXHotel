using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;
using JXHotel.Domain.Repository;

namespace JXHotel.Repository
{
    public class HotelRoleRepository : RoleRepository<HotelRole, HotelUser>, IHotelRoleRepository
    {
        public HotelRoleRepository(IRepositoryContext context) : base(context)
        {

        }

        public override HotelRole GetRoleForUser(HotelUser user)
        {
            var context = this.EFContext.dbContext as JXHotelDbContext;
            return context.HotelUser.Find(user.Id).HotelRole;
        }
    }
}
