using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;

namespace JXHotel.Domain.Repository
{
    /// <summary>
    /// 酒店优惠活动接口
    /// </summary>
    /// <typeparam name="THotelPromotion"></typeparam>
  public  interface IHotelPromotionRepository<THotelPromotion>  :IRepository<THotelPromotion>  where  THotelPromotion:HotelPromotion
    {
        /// <summary>
        /// 根据消费者角色获取酒店活动
        /// </summary>
        /// <param name="customerRoleId"></param>
        /// <returns></returns>
        List<THotelPromotion> GetHotelPromotionsByCustomerRoleId(Guid customerRoleId);

        /// <summary>
        /// 根据酒店房间分类id获取酒店活动
        /// </summary>
        /// <param name="hotelRoomCategoryId"></param>
        /// <returns></returns>
        List<THotelPromotion> GetHotelPromotionsByHotelRoomCategoryId(Guid hotelRoomCategoryId);

        /// <summary>
        /// 根据消费者id获取酒店活动
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        List<THotelPromotion> GetHotelPromotionsByCustomerId(Guid customerId);

        /// <summary>
        /// 根据房间id获取酒店活动
        /// </summary>
        /// <param name = "roomId" ></ param >
        /// < returns ></ returns >
        List <THotelPromotion> GetHotelPromotionsByRoomId(Guid roomId);


        #region 活动图片
        /// <summary>
        /// 增加活动图片
        /// </summary>
        /// <param name="PromotionImage"></param>
        /// <returns></returns>
        void  AddPromotionImage(Guid PromotionId, List<PromotionImage> PromotionImage);

        /// <summary>
        /// 更新活动图片
        /// </summary>
        /// <param name="PromotionImage"></param>
        /// <param name="PromotionId"></param>
        /// <returns></returns>
        List<PromotionImage> UpdatePromotionImage(Guid PromotionId, List<PromotionImage> PromotionImage);

        /// <summary>
        /// 删除活动图片
        /// </summary>
        /// <param name="id">需要删除的活动图片id值</param>
        void DeletePromotionImage(Guid PromotionId,List<string> id);

        /// <summary>
        /// 获取所有活动图片
        /// </summary>
        /// <returns></returns>
         List<PromotionImage> GetPromotionImages(Guid PromotionId);

        /// <summary>
        /// 根据活动图片id获取活动图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         PromotionImage GetPromotionImageByKey(Guid PromotionId, Guid id);


        /// <summary>
        /// 根据酒店id获取活动图片
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
         List<PromotionImage> GetPromotionImagesByHotelId(Guid hotelId);

        /// <summary>
        /// 根据酒店名称获取活动图片
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
         List<PromotionImage> GetPromotionImagesByHotelName(string hotelName);

        #endregion


    }
}
