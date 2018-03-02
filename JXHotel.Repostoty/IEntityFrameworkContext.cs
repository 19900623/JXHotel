using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using JXHotel.Domain.Repository;


namespace JXHotel.Repository
{
  public  interface IEntityFrameworkContext : IRepositoryContext
    {
        DbContext dbContext { get; }
    }
}
