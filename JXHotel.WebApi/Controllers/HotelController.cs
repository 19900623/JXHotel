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
    public class HotelController : ApiController
    {
        private readonly IHotelService hotelServiceImp = ServiceLocator.Instance.GetService<IHotelService>();

        #region 酒店
        /// <summary>
        /// 创建酒店
        /// </summary>
        /// <param name="HotelDataObject"></param>
        /// <returns></returns>
        public string  Post(List<HotelDataObject> HotelDataObject)
        {
            var hotels = hotelServiceImp.CreateHotel(HotelDataObject);
            return JsonConvert.SerializeObject(hotels);
        }

        /// <summary>
        /// 获取所有酒店
        /// </summary>
        /// <returns></returns>
        public string Get(QuerySpec spec)
        {
            var hotels = hotelServiceImp.GetHotels(QuerySpec.Empty);
            return JsonConvert.SerializeObject(hotels);
        }


        /// <summary>
        /// 根据Id值获取酒店
        /// </summary>
        /// <param name="Id">id值</param>
        /// <returns></returns>
        public string GetByKey(string Id)
        {
            var hotel = hotelServiceImp.GetHotelByKey(new Guid(Id),QuerySpec.Empty);
            return JsonConvert.SerializeObject(hotel);
        }

        /// <summary>
        /// 根据酒店名称获取酒店
        /// </summary>
        /// <param name="name">酒店名称</param>
        /// <returns></returns>
        public string GetByName(string name)
        {
            var hotel = hotelServiceImp.GetHotelByName(name, QuerySpec.Empty);
            return JsonConvert.SerializeObject(hotel);
        }

        /// <summary>
        /// 删除酒店
        /// </summary>
        /// <param name="ids">需要删除的酒店</param>
       public void Delete(List<string> ids)
        {
            hotelServiceImp.DeleteHotel(ids);
        }

        /// <summary>
        /// 更新酒店信息
        /// </summary>
        /// <param name="HotelDataObject">需要更新的酒店</param>
        /// <returns></returns>
        public string UpdateHotel(List<HotelDataObject> HotelDataObject)
        {
            var hotels = hotelServiceImp.UpdateHotel(HotelDataObject);
            return JsonConvert.SerializeObject(hotels);
        }

        #endregion

        #region 酒店分类
        /// <summary>
        /// 创建酒店分类
        /// </summary>
        /// <param name="hotelCategoryDataObject">需要创建的分类</param>
        /// <returns></returns>
        public string PostHotelCategory(List<HotelCategoryDataObject> hotelCategoryDataObject)
        {
            var hotelCategorys = hotelServiceImp.CreateHotelCategory(hotelCategoryDataObject);
            return JsonConvert.SerializeObject(hotelCategorys);
        }

        /// <summary>
        /// 获取所有酒店分类信息
        /// </summary>
        /// <returns></returns>
        public string GetHotelCategorys()
        {
            var hotelCategorys = hotelServiceImp.GetHotelCategorys();
            return JsonConvert.SerializeObject(hotelCategorys);
        }

        /// <summary>
        /// 根据分类Id值获取分类信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string GetHotelCategoryByKey(string  Id)
        {
            var hotelCategory = hotelServiceImp.GetHotelCategoryByKey(new Guid(Id));
            return JsonConvert.SerializeObject(hotelCategory);
        }

        /// <summary>
        /// 根据分类名称获取分类信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetHotelCategoryByName(string name)
        {
            var hotelCategory = hotelServiceImp.GetHotelCategoryByName(name);
            return JsonConvert.SerializeObject(hotelCategory);
        }

        /// <summary>
        /// 根据酒店名称获取酒店分类
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        public string GetHotelCategoryByHotelName(string hotelName)
        {
            var hotelCategory = hotelServiceImp.GetHotelCategoryByHotelName(hotelName);
            return JsonConvert.SerializeObject(hotelCategory);
        }


        /// <summary>
        /// 更新酒店分类
        /// </summary>
        /// <param name="hotelCategoryDataObject"></param>
        /// <returns></returns>
        public string PutHotelCategory(List<HotelCategoryDataObject> hotelCategoryDataObject)
        {
            var hotelCategorys = hotelServiceImp.UpdateHotelCategory(hotelCategoryDataObject);
            return JsonConvert.SerializeObject(hotelCategorys);
        }

        /// <summary>
        /// 删除酒店分类
        /// </summary>
        /// <param name="id">需要删除酒店分类的id值</param>
        public void DeleteHotelCategory(List<string> ids)
        {
            hotelServiceImp.DeleteHotelCategory(ids);
        }

        /// <summary>
        /// 将酒店指向分类
        /// </summary>
        /// <param name="hotelID"></param>
        /// <param name="categoryID"></param>
       public void PutAssignCategory(string  hotelID, string  categoryID)
        {
            hotelServiceImp.AssignCategory(new Guid(hotelID), new Guid(categoryID));
        }

        /// <summary>
        /// 将酒店从分类中移除
        /// </summary>
        /// <param name="hotelID"></param>
        /// <param name="categoryID"></param>
       public  void UnassignCategory(string  hotelID, string  categoryID)
        {
            hotelServiceImp.UnassignCategory(new Guid(hotelID), new Guid(categoryID));
        }

        #endregion

        #region 房间
        /// <summary>
        /// 根据酒店名称获取酒店房间
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
       public string  GetRoomsByHotelName(string hotelName)
        {
            var room = hotelServiceImp.GetRoomsByHotelName(hotelName);
            return JsonConvert.SerializeObject(room);
        }

        #endregion

        #region 酒店图片
        /// <summary>
        /// 创建酒店图片
        /// </summary>
        /// <param name="hotelImageDataObject"></param>
        /// <returns></returns>
       public  void PostHotelImage(string  hotelId, List<HotelImageDataObject> hotelImageDataObject)
        {
            hotelServiceImp.AddHotelImage(new Guid(hotelId), hotelImageDataObject);
        }

        /// <summary>
        /// 更新酒店图片
        /// </summary>
        /// <param name="hotelImageDataObject"></param>
        /// <returns></returns>
        public string PutHotelImage(string  hotelId, List<HotelImageDataObject> hotelImageDataObject)
        {
            var hotelImages = hotelServiceImp.UpdateHotelImage(new Guid(hotelId), hotelImageDataObject);
            return JsonConvert.SerializeObject(hotelImages);
        }

        /// <summary>
        /// 删除酒店图片
        /// </summary>
        /// <param name="id">需要删除的酒店图片id值</param>
       public void DeleteHotelImage(string  hotelId, List<string> ids)
        {
            hotelServiceImp.DeleteHotelImage(new Guid(hotelId), ids);
        }



        /// <summary>
        /// 根据酒店图片id获取酒店图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetHotelImageByKey(string  hotelId, string  id)
        {
            var hotelImage = hotelServiceImp.GetHotelImageByKey(new Guid(hotelId), new Guid(id));
            return JsonConvert.SerializeObject(hotelImage);
        }


        /// <summary>
        /// 根据酒店id获取酒店图片
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public string GetHotelImagesByHotelId(string  hotelId)
        {
            var hotelImages = hotelServiceImp.GetHotelImagesByHotelId(new Guid(hotelId));
            return JsonConvert.SerializeObject(hotelImages);
        }

        /// <summary>
        /// 根据酒店名称获取酒店图片
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        public string  GetHotelImagesByHotelName(string hotelName)
        {
            var hotelImages = hotelServiceImp.GetHotelImagesByHotelName(hotelName);
            return JsonConvert.SerializeObject(hotelImages);
        }

        #endregion

        #region 酒店账号

        /// <summary>
        /// 创建酒店账号
        /// </summary>
        /// <param name="HotelAccountDataObject"></param>
        /// <returns></returns>
        public void PostHotelAccount(string  hotelId, List<HotelAccountDataObject> HotelAccountDataObject)
        {
             hotelServiceImp.AddHotelAccount(new Guid(hotelId), HotelAccountDataObject);
        }

        /// <summary>
        /// 更新酒店账号
        /// </summary>
        /// <param name="HotelAccountDataObject"></param>
        /// <returns></returns>
        public string PutHotelAccount(string  hotelId, List<HotelAccountDataObject> HotelAccountDataObject)
        {
            var hotelAccounts = hotelServiceImp.UpdateHotelAccount(new Guid(hotelId), HotelAccountDataObject);
            return JsonConvert.SerializeObject(hotelAccounts);
        }

        /// <summary>
        /// 删除酒店账号
        /// </summary>
        /// <param name="ids">需要删除的酒店账号id值</param>
       public void DeleteHotelAccount(string  hotelId, List<string> ids)
        {
            hotelServiceImp.DeleteHotelAccount(new Guid(hotelId), ids);
        }



        /// <summary>
        /// 根据酒店账号id获取酒店账号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetHotelAccountByKey(string  hotelId, string  id)
        {
            var hotelAccount = hotelServiceImp.GetHotelAccountByKey(new Guid(hotelId), new Guid(id));
            return JsonConvert.SerializeObject(hotelAccount);
        }


        /// <summary>
        /// 根据酒店id获取酒店账号
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public string GetHotelAccountsByHotelId(string  hotelId)
        {
            var hotelAccount = hotelServiceImp.GetHotelAccountsByHotelId(new Guid(hotelId));
            return JsonConvert.SerializeObject(hotelAccount);
        }

        /// <summary>
        /// 根据酒店名称获取酒店账号
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        public string GetHotelAccountsByHotelName(string hotelName)
        {
            var hotelAccount = hotelServiceImp.GetHotelAccountsByHotelName(hotelName);
            return JsonConvert.SerializeObject(hotelAccount);
        }

        #endregion

        #region 酒店评论

        /// <summary>
        /// 创建酒店评论
        /// </summary>
        /// <param name="HotelCommentDataObject"></param>
        /// <returns></returns>
       public void PostHotelComment(string  hotelId, List<HotelCommentDataObject> HotelCommentDataObject)
        {
            hotelServiceImp.AddHotelComment(new Guid(hotelId), HotelCommentDataObject);
        }

        /// <summary>
        /// 更新酒店评论
        /// </summary>
        /// <param name="HotelCommentDataObject"></param>
        /// <returns></returns>
        public string PutHotelComment(string  hotelId, List<HotelCommentDataObject> HotelCommentDataObject)
        {
            var hotelComments = hotelServiceImp.UpdateHotelComment(new Guid(hotelId), HotelCommentDataObject);
            return JsonConvert.SerializeObject(hotelComments);
        }

        /// <summary>
        /// 删除酒店评论
        /// </summary>
        /// <param name="ids">需要删除的酒店评论id值</param>
       public void DeleteHotelComment(string  hotelId, List<string> ids)
        {
            hotelServiceImp.DeleteHotelComment(new Guid(hotelId), ids);
        }



        /// <summary>
        /// 根据酒店评论id获取酒店评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetHotelCommentByKey(string  hotelId, string  id)
        {
            var hotelComment = hotelServiceImp.GetHotelCommentByKey(new Guid(hotelId), new Guid(id));
            return JsonConvert.SerializeObject(hotelComment);
        }


        /// <summary>
        /// 根据酒店id获取酒店评论
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public string GetHotelCommentsByHotelId(string  hotelId)
        {
            var hotelComments = hotelServiceImp.GetHotelCommentsByHotelId(new Guid(hotelId));
            return JsonConvert.SerializeObject(hotelComments);
        }

        /// <summary>
        /// 根据酒店名称获取酒店评论
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        public string GetHotelCommentsByHotelName(string hotelName)
        {
            var hotelComments = hotelServiceImp.GetHotelCommentsByHotelName(hotelName);
            return JsonConvert.SerializeObject(hotelComments);
        }

        #endregion
    }
}
