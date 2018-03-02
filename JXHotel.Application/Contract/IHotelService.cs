using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.DataObject;

namespace JXHotel.Application.Contract
{
    /// <summary>
    /// 酒店应用层接口
    /// </summary>
    public interface IHotelService
    {
        #region 酒店
        /// <summary>
        /// 创建酒店
        /// </summary>
        /// <param name="HotelDataObject"></param>
        /// <returns></returns>
        List<HotelDataObject> CreateHotel(List<HotelDataObject> HotelDataObject);

        /// <summary>
        /// 获取所有酒店
        /// </summary>
        /// <param name="spec">查询方式</param>
        /// <returns></returns>
        List<HotelDataObject> GetHotels(QuerySpec spec);


        /// <summary>
        /// 根据Id值获取酒店
        /// </summary>
        /// <param name="Id">id值</param>
        /// <param name="spec">查询方式</param>
        /// <returns></returns>
        HotelDataObject GetHotelByKey(Guid Id, QuerySpec spec);

        /// <summary>
        /// 根据酒店名称获取酒店
        /// </summary>
        /// <param name="name">酒店名称</param>
        /// <param name="spec">查询方式</param>
        /// <returns></returns>
        HotelDataObject GetHotelByName(string name, QuerySpec spec);

        /// <summary>
        /// 删除酒店
        /// </summary>
        /// <param name="ids">需要删除的酒店</param>
        void DeleteHotel(List<string> ids);

        /// <summary>
        /// 更新酒店信息
        /// </summary>
        /// <param name="HotelDataObject">需要更新的酒店</param>
        /// <returns></returns>
        List<HotelDataObject> UpdateHotel(List<HotelDataObject> HotelDataObject);

        #endregion

        #region 酒店分类
        /// <summary>
        /// 创建酒店分类
        /// </summary>
        /// <param name="hotelCategoryDataObject">需要创建的分类</param>
        /// <returns></returns>
        List<HotelCategoryDataObject> CreateHotelCategory(List<HotelCategoryDataObject> hotelCategoryDataObject);

        /// <summary>
        /// 获取所有酒店分类信息
        /// </summary>
        /// <returns></returns>
        List<HotelCategoryDataObject> GetHotelCategorys();

        /// <summary>
        /// 根据分类Id值获取分类信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        HotelCategoryDataObject GetHotelCategoryByKey(Guid Id);

        /// <summary>
        /// 根据分类名称获取分类信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        HotelCategoryDataObject GetHotelCategoryByName(string name);

        /// <summary>
        /// 根据酒店名称获取酒店分类
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        List<HotelCategoryDataObject> GetHotelCategoryByHotelName(string hotelName);


        /// <summary>
        /// 更新酒店分类
        /// </summary>
        /// <param name="hotelCategoryDataObject"></param>
        /// <returns></returns>
        List<HotelCategoryDataObject> UpdateHotelCategory(List<HotelCategoryDataObject> hotelCategoryDataObject);

        /// <summary>
        /// 删除酒店分类
        /// </summary>
        /// <param name="id">需要删除酒店分类的id值</param>
        void DeleteHotelCategory(List<string> ids);

        /// <summary>
        /// 将酒店指向分类
        /// </summary>
        /// <param name="hotelID"></param>
        /// <param name="categoryID"></param>
        void AssignCategory(Guid hotelID, Guid categoryID);

        /// <summary>
        /// 将酒店从分类中移除
        /// </summary>
        /// <param name="hotelID"></param>
        /// <param name="categoryID"></param>
        void UnassignCategory(Guid hotelID, Guid categoryID);

        #endregion

        #region 房间
        /// <summary>
        /// 根据酒店名称获取酒店房间
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        List<RoomDataObject> GetRoomsByHotelName(string hotelName);

        #endregion

        #region 酒店图片
        /// <summary>
        /// 创建酒店图片
        /// </summary>
        /// <param name="hotelImageDataObject"></param>
        /// <returns></returns>
        void AddHotelImage(Guid hotelId,List<HotelImageDataObject> hotelImageDataObject);

        /// <summary>
        /// 更新酒店图片
        /// </summary>
        /// <param name="hotelImageDataObject"></param>
        /// <returns></returns>
        List<HotelImageDataObject> UpdateHotelImage(Guid hotelId,List<HotelImageDataObject> hotelImageDataObject);

        /// <summary>
        /// 删除酒店图片
        /// </summary>
        /// <param name="id">需要删除的酒店图片id值</param>
        void DeleteHotelImage(Guid hotelId,List<string> ids);

        

        /// <summary>
        /// 根据酒店图片id获取酒店图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        HotelImageDataObject GetHotelImageByKey(Guid hotelId,Guid id);


        /// <summary>
        /// 根据酒店id获取酒店图片
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        List<HotelImageDataObject> GetHotelImagesByHotelId(Guid hotelId);

        /// <summary>
        /// 根据酒店名称获取酒店图片
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        List<HotelImageDataObject> GetHotelImagesByHotelName(string hotelName);

        #endregion

        #region 酒店账号

        /// <summary>
        /// 创建酒店账号
        /// </summary>
        /// <param name="HotelAccountDataObject"></param>
        /// <returns></returns>
        void AddHotelAccount(Guid hotelId, List<HotelAccountDataObject> HotelAccountDataObject);

        /// <summary>
        /// 更新酒店账号
        /// </summary>
        /// <param name="HotelAccountDataObject"></param>
        /// <returns></returns>
        List<HotelAccountDataObject> UpdateHotelAccount(Guid hotelId, List<HotelAccountDataObject> HotelAccountDataObject);

        /// <summary>
        /// 删除酒店账号
        /// </summary>
        /// <param name="ids">需要删除的酒店账号id值</param>
        void DeleteHotelAccount(Guid hotelId, List<string> ids);

        

        /// <summary>
        /// 根据酒店账号id获取酒店账号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        HotelAccountDataObject GetHotelAccountByKey(Guid hotelId, Guid id);


        /// <summary>
        /// 根据酒店id获取酒店账号
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        List<HotelAccountDataObject> GetHotelAccountsByHotelId(Guid hotelId);

        /// <summary>
        /// 根据酒店名称获取酒店账号
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        List<HotelAccountDataObject> GetHotelAccountsByHotelName(string hotelName);

        #endregion

        #region 酒店评论

        /// <summary>
        /// 创建酒店评论
        /// </summary>
        /// <param name="HotelCommentDataObject"></param>
        /// <returns></returns>
        void AddHotelComment(Guid hotelId, List<HotelCommentDataObject> HotelCommentDataObject);

        /// <summary>
        /// 更新酒店评论
        /// </summary>
        /// <param name="HotelCommentDataObject"></param>
        /// <returns></returns>
        List<HotelCommentDataObject> UpdateHotelComment(Guid hotelId, List<HotelCommentDataObject> HotelCommentDataObject);

        /// <summary>
        /// 删除酒店评论
        /// </summary>
        /// <param name="ids">需要删除的酒店评论id值</param>
        void DeleteHotelComment(Guid hotelId, List<string> ids);

        

        /// <summary>
        /// 根据酒店评论id获取酒店评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        HotelCommentDataObject GetHotelCommentByKey(Guid hotelId, Guid id);


        /// <summary>
        /// 根据酒店id获取酒店评论
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        List<HotelCommentDataObject> GetHotelCommentsByHotelId(Guid hotelId);

        /// <summary>
        /// 根据酒店名称获取酒店评论
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        List<HotelCommentDataObject> GetHotelCommentsByHotelName(string hotelName);

        #endregion
    }
}
