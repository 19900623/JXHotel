using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;
using JXHotel.Domain.Repository;
using JXHotel.Domain.Specification;

namespace JXHotel.Repository
{   
    /// <summary>
    /// 酒店优惠活动仓储
    /// </summary>
    /// <typeparam name="THotelPromotion"></typeparam>
    public class HotelPromotionRepository<THotelPromotion> : EntityFrameworkRepository<THotelPromotion>, IHotelPromotionRepository<THotelPromotion> where THotelPromotion:HotelPromotion
    {
        public HotelPromotionRepository(IRepositoryContext context) : base(context)
        {
        }

        /// <summary>
        /// 根据消费者id获取酒店活动
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<THotelPromotion> GetHotelPromotionsByCustomerId(Guid customerId)
        {
            var context = EFContext.dbContext as JXHotelDbContext;
            return  context.Customer.Find(customerId).CustomerRole.HotelPromotions.OfType<THotelPromotion>().ToList();
            
        }

        /// <summary>
        /// 根据消费者角色获取酒店活动
        /// </summary>
        /// <param name="customerRoleId"></param>
        /// <returns></returns>
        public List<THotelPromotion> GetHotelPromotionsByCustomerRoleId(Guid customerRoleId)
        {
            var context = EFContext.dbContext as JXHotelDbContext;
            return context.CustomerRoles.Find(customerRoleId).HotelPromotions.OfType<THotelPromotion>().ToList();
        }

        /// <summary>
        /// 根据酒店房间分类id获取酒店活动
        /// </summary>
        /// <param name="hotelRoomCategoryId"></param>
        /// <returns></returns>
        public List<THotelPromotion> GetHotelPromotionsByHotelRoomCategoryId(Guid hotelRoomCategoryId)
        {
            var context = EFContext.dbContext as JXHotelDbContext;
             return  context.HotelRoomCategorys.Find(hotelRoomCategoryId).HotelPromotions.OfType<THotelPromotion>().ToList();

        }

        /// <summary>
        /// 根据房间id获取酒店活动
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public List<THotelPromotion> GetHotelPromotionsByRoomId(Guid roomId)
        {
            var context = EFContext.dbContext as JXHotelDbContext;
            return   context.Rooms.Find(roomId).HotelRoomCategory.HotelPromotions.OfType<THotelPromotion>().ToList();
        }


        #region 活动图片
        /// <summary>
        /// 增加活动图片
        /// </summary>
        /// <param name="PromotionImage"></param>
        /// <returns></returns>
       public void AddPromotionImage(Guid PromotionId, List<PromotionImage> PromotionImage)
        {
            var context = EFContext.dbContext as JXHotelDbContext;
            HotelPromotion hotelPromotion = context.HotelPromotions.Find(PromotionId);
            hotelPromotion.PromotionImages.AddRange(PromotionImage);
            this.Context.RegisterModify<HotelPromotion>(hotelPromotion);
            this.Context.Commit();
        }

        /// <summary>
        /// 更新活动图片
        /// </summary>
        /// <param name="PromotionImage"></param>
        /// <returns></returns>
        public List<PromotionImage> UpdatePromotionImage(Guid PromotionId, List<PromotionImage> PromotionImages)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            HotelPromotion hotelPromotion = dbContext.HotelPromotions.Find(PromotionId);
            List<PromotionImage> listPromotionImage = hotelPromotion.PromotionImages;

            foreach (PromotionImage updatePromotionImage in PromotionImages)
            {
                for (int i = 0; i < listPromotionImage.Count; i++)
                {
                    if (listPromotionImage[i].Id.Equals(updatePromotionImage.Id))
                        listPromotionImage[i] = updatePromotionImage;
                }
            }
            this.Context.RegisterModify<HotelPromotion>(hotelPromotion);
            this.Context.Commit();
            return PromotionImages;
        }

        /// <summary>
        /// 删除活动图片
        /// </summary>
        /// <param name="ids">需要删除的活动图片id值</param>
        public void DeletePromotionImage(Guid PromotionId, List<string> ids)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            HotelPromotion hotelPromotion = dbContext.HotelPromotions.Find(PromotionId);
            hotelPromotion.PromotionImages.RemoveAll(item => ids.Contains(item.Id.ToString()));
            this.Context.RegisterModify<HotelPromotion>(hotelPromotion);
            this.Context.Commit();
        }

        /// <summary>
        /// 获取所有活动图片
        /// </summary>
        /// <returns></returns>
        public List<PromotionImage> GetPromotionImages(Guid PromotionId)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            return dbContext.HotelPromotions.Find(PromotionId).PromotionImages;
        }

        /// <summary>
        /// 根据活动图片id获取活动图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PromotionImage GetPromotionImageByKey(Guid PromotionId, Guid id)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            return dbContext.HotelPromotions.Find(PromotionId).PromotionImages.Where(a=>a.Id.Equals(id)).FirstOrDefault();
        }


        /// <summary>
        /// 根据酒店id获取活动图片
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public List<PromotionImage> GetPromotionImagesByHotelId(Guid hotelId)
        {
          return    this.Find(Specification<THotelPromotion>.Eval(h => h.HotelId.Equals(hotelId))).PromotionImages;
        }

        /// <summary>
        /// 根据酒店名称获取活动图片
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        public List<PromotionImage> GetPromotionImagesByHotelName(string hotelName)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            Hotel hotel = dbContext.Hotels.Find(Specification<Hotel>.Eval(h => h.Name.Equals(hotelName)));
            return this.Find(Specification<THotelPromotion>.Eval(h => h.HotelId.Equals(hotel.Id))).PromotionImages;

        }

        #endregion

    }
}
