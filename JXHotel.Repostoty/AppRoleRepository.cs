using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;
using JXHotel.Domain.Repository;

namespace JXHotel.Repository
{
    public class AppRoleRepository : RoleRepository<AppRole, AppUser>, IAppRoleRepository
    {
        public AppRoleRepository(IRepositoryContext context) : base(context)
        {

        }

        public override AppRole GetRoleForUser(AppUser user)
        {
            var context = this.EFContext.dbContext as JXHotelDbContext;
            return context.AppUser.Find(user.Id).AppRole;
        }
    }
}
