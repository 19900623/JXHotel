using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.DataObject;

namespace JXHotel.Application.Contract
{
    /// <summary>
    /// 酒店优惠活动应用层接口
    /// </summary>
  public  interface IHotelPromotionService<THotelPromotionDataObject> where THotelPromotionDataObject : HotelPromotionDataObject
    {
        #region 酒店优惠活动
        /// <summary>
        /// 创建酒店优惠活动
        /// </summary>
        /// <param name="HotelPromotionDataObject"></param>
        /// <returns></returns>
        List<THotelPromotionDataObject> CreateHotelPromotion(List<THotelPromotionDataObject> HotelPromotionDataObject);

        /// <summary>
        /// 获取所有酒店优惠活动
        /// </summary>
        /// <param name="spec">查询方式</param>
        /// <returns></returns>
        List<THotelPromotionDataObject> GetHotelPromotions(QuerySpec spec);


        /// <summary>
        /// 根据Id值获取酒店优惠活动
        /// </summary>
        /// <param name="Id">id值</param>
        /// <param name="spec">查询方式</param>
        /// <returns></returns>
        THotelPromotionDataObject GetHotelPromotionByKey(Guid Id, QuerySpec spec);

        /// <summary>
        /// 根据酒店优惠活动名称获取酒店优惠活动
        /// </summary>
        /// <param name="name">酒店优惠活动名称</param>
        /// <param name="spec">查询方式</param>
        /// <returns></returns>
        THotelPromotionDataObject GetHotelPromotionByName(string name, QuerySpec spec);

        /// <summary>
        /// 删除酒店优惠活动
        /// </summary>
        /// <param name="ids">需要删除的酒店优惠活动</param>
        void DeleteHotelPromotion(List<string> ids);

        /// <summary>
        /// 更新酒店优惠活动信息
        /// </summary>
        /// <param name="HotelPromotionDataObject">需要更新的酒店优惠活动</param>
        /// <returns></returns>
        List<THotelPromotionDataObject> UpdateHotelPromotion(List<THotelPromotionDataObject> HotelPromotionDataObject);

        /// <summary>
        /// 根据酒店id获取酒店活动
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        List<THotelPromotionDataObject> GetHotelPromotionsByHotelId(Guid hotelId);

        /// <summary>
        /// 根据消费者角色id获取酒店活动
        /// </summary>
        /// <param name="customerRoleId"></param>
        /// <returns></returns>
        List<THotelPromotionDataObject> GetHotelPromotionsByCustomerRoleId(Guid customerRoleId);

        /// <summary>
        /// 根据酒店房间分类id获取酒店活动
        /// </summary>
        /// <param name="hotelRoomCategoryId"></param>
        /// <returns></returns>
        List<THotelPromotionDataObject> GetHotelPromotionsByHotelRoomCategoryId(Guid hotelRoomCategoryId);

        /// <summary>
        /// 根据消费者id获取酒店活动
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        List<THotelPromotionDataObject> GetHotelPromotionsByCustomerId(Guid customerId);

        /// <summary>
        /// 根据房间id获取酒店活动
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        List<THotelPromotionDataObject> GetHotelPromotionsByRoomId(Guid roomId);

        #endregion

        #region 活动图片
        /// <summary>
        /// 创建活动图片
        /// </summary>
        /// <param name="PromotionImageDataObject"></param>
        /// <returns></returns>
        void AddPromotionImage(Guid PromotionId, List<PromotionImageDataObject> PromotionImageDataObject);

        /// <summary>
        /// 更新活动图片
        /// </summary>
        /// <param name="PromotionImageDataObject"></param>
        /// <returns></returns>
        List<PromotionImageDataObject> UpdatePromotionImage(Guid PromotionId, List<PromotionImageDataObject> PromotionImageDataObject);

        /// <summary>
        /// 删除活动图片
        /// </summary>
        /// <param name="ids">需要删除的活动图片id值</param>
        void DeletePromotionImage(Guid PromotionId, List<string> id);

        /// <summary>
        /// 获取所有活动图片
        /// </summary>
        /// <returns></returns>
        List<PromotionImageDataObject> GetPromotionImages(Guid PromotionId);

        /// <summary>
        /// 根据活动图片id获取活动图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PromotionImageDataObject GetPromotionImageByKey(Guid PromotionId, Guid id);


        /// <summary>
        /// 根据酒店id获取活动图片
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        List<PromotionImageDataObject> GetPromotionImagesByHotelId(Guid hotelId);

        /// <summary>
        /// 根据酒店名称获取活动图片
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        List<PromotionImageDataObject> GetPromotionImagesByHotelName(string hotelName);

        #endregion

        #region 消费者角色
        /// <summary>
        /// 根据活动id获取消费者角色
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <returns></returns>
        List<CustomerRoleDataObject> GetCustomerRoleByHotelPromotionId(Guid hotelPromotionId);

        /// <summary>
        /// 根据活动名称获取消费者角色
        /// </summary>
        /// <param name="hotelPromotionName"></param>
        /// <returns></returns>
        List<CustomerRoleDataObject> GetCustomerRoleByHotelPromotionName(string  hotelPromotionName);

        /// <summary>
        /// 将活动指向消费者角色
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <param name="CustomerRoleID"></param>
        void AssignCustomerRole(Guid hotelPromotionId, Guid CustomerRoleID);

       /// <summary>
       /// 将活动从消费者角色中移除
       /// </summary>
       /// <param name="hotelPromotionId"></param>
       /// <param name="CustomerRoleID"></param>
        void UnassignCustomerRole(Guid hotelPromotionId, Guid CustomerRoleID);
        #endregion

        #region 房间分类
        /// <summary>
        /// 根据活动id获取房间分类
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <returns></returns>
        List<HotelRoomCategoryDataObject> GetHotelRoomCategoryByHotelPromotionId(Guid hotelPromotionId);

        /// <summary>
        /// 根据活动名称获取房间分类
        /// </summary>
        /// <param name="hotelPromotionName"></param>
        /// <returns></returns>
        List<HotelRoomCategoryDataObject> GetHotelRoomCategoryByHotelPromotionName(string  hotelPromotionName);

        /// <summary>
        /// 将活动指向房间分类
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <param name="HotelRoomCategoryID"></param>
        void AssignHotelRoomCategory(Guid hotelPromotionId, Guid HotelRoomCategoryID);

        /// <summary>
        /// 将活动从房间分类中移除
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <param name="HotelRoomCategoryID"></param>
        void UnassignHotelRoomCategory(Guid hotelPromotionId, Guid HotelRoomCategoryID);
        #endregion
    }
}
