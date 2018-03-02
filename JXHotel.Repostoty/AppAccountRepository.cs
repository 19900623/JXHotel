using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;
using JXHotel.Domain.Repository;

namespace JXHotel.Repository
{
    public class AppAccountRepository : EntityFrameworkRepository<AppAccount>, IAppAccountRepository
    {
        public AppAccountRepository(IRepositoryContext context) : base(context)
        {

        }
    }
}
