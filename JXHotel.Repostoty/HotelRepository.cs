using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Repository;
using JXHotel.Domain.Model;
using JXHotel.Repository.Specification;

namespace JXHotel.Repository
{
  public  class HotelRepository  : EntityFrameworkRepository<Hotel>,IHotelRepository
    {
        public HotelRepository(IRepositoryContext context):base(context)
        {

        }


        /// <summary>
        /// 创建酒店图片
        /// </summary>
        /// <param name="hotelImages"></param>
        /// <returns></returns>
      public  void AddHotelImage(Guid hotelId, List<HotelImage> hotelImages)
        {
            var context = EFContext.dbContext as JXHotelDbContext;
            Hotel hotel = context.Hotels.Find(hotelId);
            hotel.HotelImages.AddRange(hotelImages);
            this.Context.RegisterModify<Hotel>(hotel);
            this.Context.Commit();
        }

        /// <summary>
        /// 更新酒店图片
        /// </summary>
        /// <param name="hotelImages"></param>
        /// <returns></returns>
      public  List<HotelImage> UpdateHotelImage(Guid hotelId, List<HotelImage> hotelImages)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            Hotel hotel = dbContext.Hotels.Find(hotelId);
            List<HotelImage> listHotelImage = hotel.HotelImages;

            foreach (HotelImage updatehotelImage in hotelImages)
            {
                for (int i = 0; i < listHotelImage.Count; i++)
                {
                    if (listHotelImage[i].Id.Equals(updatehotelImage.Id))
                        listHotelImage[i] = updatehotelImage;
                }
            }
            this.Context.RegisterModify<Hotel>(hotel);
            this.Context.Commit();
            return hotelImages;
        }

        /// <summary>
        /// 删除酒店图片
        /// </summary>
        /// <param name="id">需要删除的酒店图片id值</param>
      public   void DeleteHotelImage(Guid hotelId, List<string> ids)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            Hotel hotel = dbContext.Hotels.Find(hotelId);
            hotel.HotelImages.RemoveAll(item => ids.Contains(item.Id.ToString()));
            this.Context.RegisterModify<Hotel>(hotel);
            this.Context.Commit();
        }


        /// <summary>
        /// 根据酒店图片id获取酒店图片
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
      public  HotelImage GetHotelImageByKey(Guid hotelId, Guid id)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            HotelImage  hotelImage=   dbContext.Hotels.Find(hotelId).HotelImages.Where(image => image.Id.Equals(id)).FirstOrDefault();
            return hotelImage;
        }

        /// <summary>
        /// 根据酒店id获取酒店图片
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
      public  List<HotelImage> GetHotelImagesByHotelId(Guid hotelId)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            List<HotelImage> hotelImages = dbContext.Hotels.Find(hotelId).HotelImages;
            return hotelImages;
        }


        /// <summary>
        /// 根据酒店名称获取酒店图片
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
     public   List<HotelImage> GetHotelImagesByHotelName(string hotelName)
        {
           return   this.Find(new HotelNameEqualSpecification(hotelName), image => image.HotelImages).HotelImages;
        }



        /// <summary>
        /// 创建酒店账号
        /// </summary>
        /// <param name="HotelAccounts"></param>
        /// <returns></returns>
       public void AddHotelAccount(Guid hotelId, List<HotelAccount> HotelAccounts)
        {
            var context = EFContext.dbContext as JXHotelDbContext;
            Hotel hotel = context.Hotels.Find(hotelId);
            hotel.HotelAccounts.AddRange(HotelAccounts);
            this.Context.RegisterModify<Hotel>(hotel);
            this.Context.Commit();
        }

        /// <summary>
        /// 更新酒店账号
        /// </summary>
        /// <param name="HotelAccountDataObject"></param>
        /// <returns></returns>
        public List<HotelAccount> UpdateHotelAccount(Guid hotelId, List<HotelAccount> HotelAccounts)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            Hotel hotel = dbContext.Hotels.Find(hotelId);
            List<HotelAccount> listHotelAccount = hotel.HotelAccounts;

            foreach (HotelAccount updatehotelAccount in HotelAccounts)
            {
                for (int i = 0; i < listHotelAccount.Count; i++)
                {
                    if (listHotelAccount[i].Id.Equals(updatehotelAccount.Id))
                        listHotelAccount[i] = updatehotelAccount;
                }
            }
            this.Context.RegisterModify<Hotel>(hotel);
            this.Context.Commit();
            return HotelAccounts;
        }

        /// <summary>
        /// 删除酒店账号
        /// </summary>
        /// <param name="ids">需要删除的酒店账号id值</param>
        public void DeleteHotelAccount(Guid hotelId, List<string> ids)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            Hotel hotel = dbContext.Hotels.Find(hotelId);
            hotel.HotelAccounts.RemoveAll(item => ids.Contains(item.Id.ToString()));
            this.Context.RegisterModify<Hotel>(hotel);
            this.Context.Commit();
        }



        /// <summary>
        /// 根据酒店账号id获取酒店账号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HotelAccount GetHotelAccountByKey(Guid hotelId, Guid id)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            HotelAccount hotelAccount = dbContext.Hotels.Find(hotelId).HotelAccounts.Where(account => account.Id.Equals(id)).FirstOrDefault();
            return hotelAccount;
        }


        /// <summary>
        /// 根据酒店id获取酒店账号
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public List<HotelAccount> GetHotelAccountsByHotelId(Guid hotelId)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            List<HotelAccount> hotelAccounts = dbContext.Hotels.Find(hotelId).HotelAccounts;
            return hotelAccounts;
        }

        /// <summary>
        /// 根据酒店名称获取酒店账号
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        public List<HotelAccount> GetHotelAccountsByHotelName(string hotelName)
        {
            return this.Find(new HotelNameEqualSpecification(hotelName), image => image.HotelAccounts).HotelAccounts;
        }


        /// <summary>
        /// 创建酒店评论
        /// </summary>
        /// <param name="HotelComments"></param>
        /// <returns></returns>
       public void AddHotelComment(Guid hotelId, List<HotelComment> HotelComments)
        {
            var context = EFContext.dbContext as JXHotelDbContext;
            Hotel hotel = context.Hotels.Find(hotelId);
            hotel.HotelComments.AddRange(HotelComments);
            this.Context.RegisterModify<Hotel>(hotel);
            this.Context.Commit();
        }

        /// <summary>
        /// 更新酒店评论
        /// </summary>
        /// <param name="HotelComments"></param>
        /// <returns></returns>
        public List<HotelComment> UpdateHotelComment(Guid hotelId, List<HotelComment> HotelComments)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            Hotel hotel = dbContext.Hotels.Find(hotelId);
            List<HotelComment> listHotelComment = hotel.HotelComments;

            foreach (HotelComment updateHotelComment in HotelComments)
            {
                for (int i = 0; i < listHotelComment.Count; i++)
                {
                    if (listHotelComment[i].Id.Equals(updateHotelComment.Id))
                        listHotelComment[i] = updateHotelComment;
                }
            }
            this.Context.RegisterModify<Hotel>(hotel);
            this.Context.Commit();
            return HotelComments;
        }

        /// <summary>
        /// 删除酒店评论
        /// </summary>
        /// <param name="ids">需要删除的酒店评论id值</param>
        public void DeleteHotelComment(Guid hotelId, List<string> ids)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            Hotel hotel = dbContext.Hotels.Find(hotelId);
            hotel.HotelComments.RemoveAll(item => ids.Contains(item.Id.ToString()));
            this.Context.RegisterModify<Hotel>(hotel);
            this.Context.Commit();
        }



        /// <summary>
        /// 根据酒店评论id获取酒店评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HotelComment GetHotelCommentByKey(Guid hotelId, Guid id)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            HotelComment hotelComment = dbContext.Hotels.Find(hotelId).HotelComments.Where(account => account.Id.Equals(id)).FirstOrDefault();
            return hotelComment;
        }


        /// <summary>
        /// 根据酒店id获取酒店评论
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public List<HotelComment> GetHotelCommentsByHotelId(Guid hotelId)
        {
            JXHotelDbContext dbContext = this.EFContext.dbContext as JXHotelDbContext;
            List<HotelComment> hotelComments = dbContext.Hotels.Find(hotelId).HotelComments;
            return hotelComments;
        }

        /// <summary>
        /// 根据酒店名称获取酒店评论
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        public List<HotelComment> GetHotelCommentsByHotelName(string hotelName)
        {
            return this.Find(new HotelNameEqualSpecification(hotelName), hotel => hotel.HotelAccounts).HotelComments;
        }

    }
}
