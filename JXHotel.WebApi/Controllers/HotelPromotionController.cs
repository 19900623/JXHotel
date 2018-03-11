using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JXHotel.Infrastructure;
using JXHotel.Application.Contract;
using JXHotel.Application;
using JXHotel.DataObject;
using Newtonsoft.Json;

namespace JXHotel.WebApi.Controllers
{
    public class HotelPromotionController<THotelPromotionDataObject> : ApiController  where THotelPromotionDataObject : HotelPromotionDataObject
    {

        protected    IHotelPromotionService<THotelPromotionDataObject> hotelPromotionServiceImp
        {
            get;set;
        }

        #region 酒店优惠活动
        /// <summary>
        /// 创建酒店优惠活动
        /// </summary>
        /// <param name="HotelPromotionDataObject"></param>
        /// <returns></returns>
       public string  Post(List<THotelPromotionDataObject> HotelPromotionDataObject)
        {
            var hotelPromotions = hotelPromotionServiceImp.CreateHotelPromotion(HotelPromotionDataObject);
            return JsonConvert.SerializeObject(hotelPromotions);
        }

        /// <summary>
        /// 获取所有酒店优惠活动
        /// </summary>
        /// <returns></returns>
       public string   Get()
        {
            var hotelPromotions = hotelPromotionServiceImp.GetHotelPromotions(QuerySpec.Empty);
            return JsonConvert.SerializeObject(hotelPromotions);
        }


        /// <summary>
        /// 根据Id值获取酒店优惠活动
        /// </summary>
        /// <param name="Id">id值</param>
        /// <returns></returns>
        public string GetByKey(string  Id)
        {
            var hotelPromotion = hotelPromotionServiceImp.GetHotelPromotionByKey(new Guid(Id),QuerySpec.Empty);
            return JsonConvert.SerializeObject(hotelPromotion);
        }

        /// <summary>
        /// 根据酒店优惠活动名称获取酒店优惠活动
        /// </summary>
        /// <param name="name">酒店优惠活动名称</param>
        /// <returns></returns>
        public string  GetByName(string name)
        {
            var hotelPromotion = hotelPromotionServiceImp.GetHotelPromotionByName(name, QuerySpec.Empty);
            return JsonConvert.SerializeObject(hotelPromotion);
        }

        /// <summary>
        /// 删除酒店优惠活动
        /// </summary>
        /// <param name="ids">需要删除的酒店优惠活动</param>
        public  void Delete(List<string> ids)
        {
            hotelPromotionServiceImp.DeleteHotelPromotion(ids);
        }

        /// <summary>
        /// 更新酒店优惠活动信息
        /// </summary>
        /// <param name="HotelPromotionDataObject">需要更新的酒店优惠活动</param>
        /// <returns></returns>
        public string Put(List<THotelPromotionDataObject> HotelPromotionDataObject)
        {
            var hotelPromotions = hotelPromotionServiceImp.UpdateHotelPromotion(HotelPromotionDataObject);
            return JsonConvert.SerializeObject(hotelPromotions);
        }

        /// <summary>
        /// 根据酒店id获取酒店活动
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public string GetByHotelId(string  hotelId)
        {
            var hotelPromotions = hotelPromotionServiceImp.GetHotelPromotionsByHotelId(new Guid(hotelId));
            return JsonConvert.SerializeObject(hotelPromotions);
        }

        /// <summary>
        /// 根据消费者角色id获取酒店活动
        /// </summary>
        /// <param name="customerRoleId"></param>
        /// <returns></returns>
        public string GetByCustomerRoleId(string  customerRoleId)
        {
            var hotelPromotions = hotelPromotionServiceImp.GetHotelPromotionsByCustomerRoleId(new Guid(customerRoleId));
            return JsonConvert.SerializeObject(hotelPromotions);
        }

        /// <summary>
        /// 根据酒店房间分类id获取酒店活动
        /// </summary>
        /// <param name="hotelRoomCategoryId"></param>
        /// <returns></returns>
        public string  GetByHotelRoomCategoryId(string  hotelRoomCategoryId)
        {
            var hotelPromotions = hotelPromotionServiceImp.GetHotelPromotionsByHotelRoomCategoryId(new Guid(hotelRoomCategoryId));
            return JsonConvert.SerializeObject(hotelPromotions);
        }

        /// <summary>
        /// 根据消费者id获取酒店活动
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public string GetByCustomerId(string  customerId)
        {
            var hotelPromotions = hotelPromotionServiceImp.GetHotelPromotionsByCustomerId(new Guid(customerId));
            return JsonConvert.SerializeObject(hotelPromotions);
        }

        /// <summary>
        /// 根据房间id获取酒店活动
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public string  GetByRoomId(string  roomId)
        {
            var hotelPromotions = hotelPromotionServiceImp.GetHotelPromotionsByRoomId(new Guid(roomId));
            return JsonConvert.SerializeObject(hotelPromotions);
        }

        #endregion

        #region 活动图片
        /// <summary>
        /// 创建活动图片
        /// </summary>
        /// <param name="PromotionImageDataObject"></param>
        /// <returns></returns>
        public  void PostImage(string  PromotionId, List<PromotionImageDataObject> PromotionImageDataObject)
        {
            hotelPromotionServiceImp.AddPromotionImage(new Guid(PromotionId), PromotionImageDataObject);
        }

        /// <summary>
        /// 更新活动图片
        /// </summary>
        /// <param name="PromotionImageDataObject"></param>
        /// <returns></returns>
        public string PutImage(string  PromotionId, List<PromotionImageDataObject> PromotionImageDataObject)
        {
            var images = hotelPromotionServiceImp.UpdatePromotionImage(new Guid(PromotionId), PromotionImageDataObject);
            return JsonConvert.SerializeObject(images);
        }

        /// <summary>
        /// 删除活动图片
        /// </summary>
        /// <param name="ids">需要删除的活动图片id值</param>
       public void DeleteImage(string  PromotionId, List<string> id)
        {
            hotelPromotionServiceImp.DeletePromotionImage(new Guid(PromotionId), id);
        }

        /// <summary>
        /// 获取所有活动图片
        /// </summary>
        /// <returns></returns>
        public string GetImages(string  PromotionId)
        {
            var images = hotelPromotionServiceImp.GetPromotionImages(new Guid(PromotionId));
            return JsonConvert.SerializeObject(images);
        }

        /// <summary>
        /// 根据活动图片id获取活动图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetImageByKey(string  PromotionId, string  id)
        {
            var image = hotelPromotionServiceImp.GetPromotionImageByKey(new Guid(PromotionId), new Guid(id));
            return JsonConvert.SerializeObject(image);
        }


        /// <summary>
        /// 根据酒店id获取活动图片
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public string GetImagesByHotelId(string  hotelId)
        {
            var images = hotelPromotionServiceImp.GetPromotionImagesByHotelId(new Guid(hotelId));
            return JsonConvert.SerializeObject(images);
        }

        /// <summary>
        /// 根据酒店名称获取活动图片
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        public string GetImagesByHotelName(string hotelName)
        {
            var images = hotelPromotionServiceImp.GetPromotionImagesByHotelName(hotelName);
            return JsonConvert.SerializeObject(images);
        }

        #endregion

        #region 消费者角色
        /// <summary>
        /// 根据活动id获取消费者角色
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <returns></returns>
        public string GetCustomerRoleByHotelPromotionId(string  hotelPromotionId)
        {
            var role = hotelPromotionServiceImp.GetCustomerRoleByHotelPromotionId(new Guid(hotelPromotionId));
            return JsonConvert.SerializeObject(role);
        }

        /// <summary>
        /// 根据活动名称获取消费者角色
        /// </summary>
        /// <param name="hotelPromotionName"></param>
        /// <returns></returns>
        public string GetCustomerRoleByHotelPromotionName(string hotelPromotionName)
        {
            var role = hotelPromotionServiceImp.GetCustomerRoleByHotelPromotionName(hotelPromotionName);
            return JsonConvert.SerializeObject(role);
        }

        /// <summary>
        /// 将活动指向消费者角色
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <param name="CustomerRoleID"></param>
        public void PutAssignCustomerRole(string  hotelPromotionId, string  CustomerRoleID)
        {
            hotelPromotionServiceImp.AssignCustomerRole(new Guid(hotelPromotionId), new Guid(CustomerRoleID));
        }

        /// <summary>
        /// 将活动从消费者角色中移除
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <param name="CustomerRoleID"></param>
        public void PutUnassignCustomerRole(string  hotelPromotionId, string  CustomerRoleID)
        {
            hotelPromotionServiceImp.UnassignCustomerRole(new Guid(hotelPromotionId), new Guid(CustomerRoleID));
        }
        #endregion

        #region 房间分类
        /// <summary>
        /// 根据活动id获取房间分类
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <returns></returns>
        public string GetHotelRoomCategoryByHotelPromotionId(string  hotelPromotionId)
        {
            var categorys = hotelPromotionServiceImp.GetHotelRoomCategoryByHotelPromotionId(new Guid(hotelPromotionId));
            return JsonConvert.SerializeObject(categorys);
        }

        /// <summary>
        /// 根据活动名称获取房间分类
        /// </summary>
        /// <param name="hotelPromotionName"></param>
        /// <returns></returns>
        public string GetHotelRoomCategoryByHotelPromotionName(string hotelPromotionName)
        {
            var categorys = hotelPromotionServiceImp.GetHotelRoomCategoryByHotelPromotionName(hotelPromotionName);
            return JsonConvert.SerializeObject(categorys);
        }

        /// <summary>
        /// 将活动指向房间分类
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <param name="HotelRoomCategoryID"></param>
        public void PutAssignHotelRoomCategory(string  hotelPromotionId, string  HotelRoomCategoryID)
        {
            hotelPromotionServiceImp.AssignHotelRoomCategory(new Guid(hotelPromotionId), new Guid(HotelRoomCategoryID));
        }

        /// <summary>
        /// 将活动从房间分类中移除
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <param name="HotelRoomCategoryID"></param>
        public void PutUnassignHotelRoomCategory(string  hotelPromotionId, string  HotelRoomCategoryID)
        {
            hotelPromotionServiceImp.UnassignHotelRoomCategory(new Guid(hotelPromotionId), new Guid(HotelRoomCategoryID)); 
        }
        #endregion
    }
}
