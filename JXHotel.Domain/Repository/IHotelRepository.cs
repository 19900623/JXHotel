using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;

namespace JXHotel.Domain.Repository
{
   public interface IHotelRepository  :IRepository<Hotel>
    {
        /// <summary>
        /// 创建酒店图片
        /// </summary>
        /// <param name="hotelImages"></param>
        /// <returns></returns>
         void AddHotelImage(Guid hotelId, List<HotelImage> hotelImages);

        /// <summary>
        /// 更新酒店图片
        /// </summary>
        /// <param name="hotelImages"></param>
        /// <returns></returns>
         List<HotelImage> UpdateHotelImage(Guid hotelId, List<HotelImage> hotelImages);

        /// <summary>
        /// 删除酒店图片
        /// </summary>
        /// <param name="id">需要删除的酒店图片id值</param>
         void DeleteHotelImage(Guid hotelId, List<string> ids);


        /// <summary>
        /// 根据酒店图片id获取酒店图片
        /// </summary>
        /// <param name="hotelId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        HotelImage GetHotelImageByKey(Guid hotelId, Guid id);


        /// <summary>
        /// 根据酒店id获取酒店图片
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        List<HotelImage> GetHotelImagesByHotelId(Guid hotelId);
       

        /// <summary>
        /// 根据酒店名称获取酒店图片
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        List<HotelImage> GetHotelImagesByHotelName(string hotelName);



        /// <summary>
        /// 创建酒店账号
        /// </summary>
        /// <param name="HotelAccounts"></param>
        /// <returns></returns>
        void AddHotelAccount(Guid hotelId, List<HotelAccount> HotelAccounts);

        /// <summary>
        /// 更新酒店账号
        /// </summary>
        /// <param name="HotelAccountDataObject"></param>
        /// <returns></returns>
        List<HotelAccount> UpdateHotelAccount(Guid hotelId, List<HotelAccount> HotelAccounts);

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
        HotelAccount GetHotelAccountByKey(Guid hotelId, Guid id);


        /// <summary>
        /// 根据酒店id获取酒店账号
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        List<HotelAccount> GetHotelAccountsByHotelId(Guid hotelId);

        /// <summary>
        /// 根据酒店名称获取酒店账号
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        List<HotelAccount> GetHotelAccountsByHotelName(string hotelName);



        /// <summary>
        /// 创建酒店评论
        /// </summary>
        /// <param name="HotelComments"></param>
        /// <returns></returns>
        void AddHotelComment(Guid hotelId, List<HotelComment> HotelComments);

        /// <summary>
        /// 更新酒店评论
        /// </summary>
        /// <param name="HotelComments"></param>
        /// <returns></returns>
        List<HotelComment> UpdateHotelComment(Guid hotelId, List<HotelComment> HotelComments);

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
        HotelComment GetHotelCommentByKey(Guid hotelId, Guid id);


        /// <summary>
        /// 根据酒店id获取酒店评论
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        List<HotelComment> GetHotelCommentsByHotelId(Guid hotelId);

        /// <summary>
        /// 根据酒店名称获取酒店评论
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        List<HotelComment> GetHotelCommentsByHotelName(string hotelName);


    }
}
