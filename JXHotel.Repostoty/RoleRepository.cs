using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;
using JXHotel.Domain.Repository;

namespace JXHotel.Repository
{
    public abstract class RoleRepository<TRole,TUser> : EntityFrameworkRepository<TRole>, IRoleRepository<TRole,TUser>   where  TRole:Role where TUser:User
    {
        public RoleRepository(IRepositoryContext context) : base(context)
        {

        }

        public abstract TRole  GetRoleForUser(TUser user);
        
    }
}
