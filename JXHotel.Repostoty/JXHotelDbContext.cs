using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using JXHotel.Domain.Model;
using JXHotel.Repository.ModelConfiguration;

namespace JXHotel.Repository
{
  public  class JXHotelDbContext  :DbContext
    {
        public JXHotelDbContext():base("JXHotel")
        {
           
        }

      public  DbSet<Customer> Customer
        {
            get { return Set<Customer>(); }
        }

     public   DbSet<AppUser> AppUser
        {
            get
            {
                return Set<AppUser>();
            }
        }

      public  DbSet<HotelUser> HotelUser
        {
            get
            {
                return Set<HotelUser>();
            }
        }


      public  DbSet<Role> Roles
        {
            get{ return Set<Role>(); }
        }

       public DbSet<CustomerRole> CustomerRoles
        {
            get { return Set<CustomerRole>(); }
        }

        public DbSet<HotelRole> HotelRoles
        {
            get { return Set<HotelRole>(); }
        }

        public DbSet<AppRole> AppRole
        {
            get { return Set<AppRole>(); }
        }


     public   DbSet<AppAccount> AppAccounts
        {
            get { return Set<AppAccount>(); }
        }

        
      public  DbSet<Hotel> Hotels
        {
            get { return Set<Hotel>(); }
        }

     public   DbSet<HotelCategory> HotelCategorys
        {
            get { return Set<HotelCategory>(); }
        }

     public  DbSet<Room> Rooms
        {
            get { return Set<Room>(); }
        }

     public   DbSet<HotelRoomCategory> HotelRoomCategorys
        {
            get { return Set<HotelRoomCategory>(); }
        }


     public   DbSet<HotelPromotion> HotelPromotions
        {
            get { return Set<HotelPromotion>(); }
        }

     public DbSet<DiscountPromotion> DiscountPromotions
        {
            get { return Set<DiscountPromotion>(); }
        }

     public DbSet<OverMinusPromotion> OverMinusPromotions
        {
            get { return Set<OverMinusPromotion>(); }
        }

     public DbSet<OverGivePromotion> OverGivePromotions
        {
            get { return Set<OverGivePromotion>(); }
        }

       public DbSet<Reservation> Reservations
        {
            get { return Set<Reservation>(); }

        }

      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations
                .Add(new CustomerTypeConfiguration())
                .Add(new AppUserTypeConfiguration())
                .Add(new HotelUserTypeConfiguration())
                .Add(new RoleTypeConfiguration())
                .Add(new AppAccountTypeConfigurtion())
                .Add(new HotelTypeConfiguration())
                .Add(new HotelCategoryTypeConfigurtion())
                .Add(new RoomTypeConfigurtion())
                .Add(new HotelRoomCategoryTypeConfigurtion())
                .Add(new HotelPromotionTypeConfigurtion())
                .Add(new ReservationTypeCofiguratiion());

            base.OnModelCreating(modelBuilder);
        }

    }
}
