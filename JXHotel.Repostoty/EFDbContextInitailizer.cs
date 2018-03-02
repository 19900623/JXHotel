using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace JXHotel.Repository
{
  public sealed  class EFDbContextInitailizer  : DropCreateDatabaseIfModelChanges<JXHotelDbContext>
    {

        protected override void Seed(JXHotelDbContext context)
        {   
            base.Seed(context);
        }

        public static void Initialize()
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<JXHotelDbContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<JXHotelDbContext>());
        }
    }
}
