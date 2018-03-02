using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Repository;
using JXHotel.Domain.Model;

namespace JXHotel.Repository
{
  public  class AppUserRepository :UserRepository<AppUser>,IAppUserRepository
    {
        public AppUserRepository(IRepositoryContext context) : base(context)
        {

        }

    }
}
