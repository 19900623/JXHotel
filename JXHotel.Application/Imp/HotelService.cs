using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Application.Contract;
using JXHotel.Domain.Repository;
using JXHotel.Domain.Model;
using JXHotel.Domain.Service;
using JXHotel.Domain.Specification;
using JXHotel.DataObject;

namespace JXHotel.Application.Imp
{
    /// <summary>
    /// 酒店应用层
    /// </summary>
  public  class HotelService  :ApplicationService ,IHotelService
    {

        private readonly IHotelRepository hotelRepository;
        private readonly IHotelCategoryRepository hotelCategoryRepository;
        private readonly IRoomRepository roomRepository;
        private readonly IHotelCategoryService hotelCategoryService;

        public HotelService(IRepositoryContext context,IHotelRepository hotelRepository
                                                      ,IHotelCategoryRepository hotelCategoryRepository
                                                      ,IRoomRepository roomRepository
                                                      , IHotelCategoryService hotelCategoryService) : base(context)
        {
            this.hotelRepository = hotelRepository;
            this.hotelCategoryRepository = hotelCategoryRepository;
            this.roomRepository = roomRepository;
            this.hotelCategoryService = hotelCategoryService;
        }

        #region 酒店
        /// <summary>
        /// 创建酒店
        /// </summary>
        /// <param name="HotelDataObject"></param>
        /// <returns></returns>
       public  List<HotelDataObject> CreateHotel(List<HotelDataObject> HotelDataObject)
        {
            return  this.PerformCreateObjects<List<HotelDataObject>, HotelDataObject, Hotel>(HotelDataObject, hotelRepository);
        }

        /// <summary>
        /// 获取所有酒店
        /// </summary>
        /// <param name="spec">查询方式</param>
        /// <returns></returns>
        public List<HotelDataObject> GetHotels(QuerySpec spec)
        {
            IEnumerable<Hotel> hotels;
            if(!spec.Verbose)
            {
                hotels = hotelRepository.FindAll();
            }
            else
            {
                hotels = hotelRepository.FindAll(new AnySpecification<Hotel>(),h=>h.HotelCategorys);
            }
            List<HotelDataObject> hotelDataObjects = AutoMapper.Mapper.Map<List<Hotel>, List<HotelDataObject>>(hotels.ToList());
            return hotelDataObjects;
        }


        /// <summary>
        /// 根据Id值获取酒店
        /// </summary>
        /// <param name="Id">id值</param>
        /// <param name="spec">查询方式</param>
        /// <returns></returns>
        public HotelDataObject GetHotelByKey(Guid Id, QuerySpec spec)
        {
            Hotel hotel;
            if (!spec.Verbose)
            {
                hotel= hotelRepository.GetByKey(Id);
            }
            else
            {
                hotel = hotelRepository.Find(Specification<Hotel>.Eval(h => h.Id.Equals(Id)), h => h.HotelCategorys);

            }
            return AutoMapper.Mapper.Map<Hotel, HotelDataObject>(hotel);
        }

        /// <summary>
        /// 根据酒店名称获取酒店
        /// </summary>
        /// <param name="name">酒店名称</param>
        /// <param name="spec">查询方式</param>
        /// <returns></returns>
        public HotelDataObject GetHotelByName(string name, QuerySpec spec)
        {
            Hotel hotel;
            if (!spec.Verbose)
            {
                hotel = hotelRepository.Find(Specification<Hotel>.Eval(h => h.Name.Equals(name)));
            }
            else
            {
                hotel = hotelRepository.Find(Specification<Hotel>.Eval(h => h.Name.Equals(name)), h => h.HotelCategorys);

            }
            return AutoMapper.Mapper.Map<Hotel, HotelDataObject>(hotel);
        }

        /// <summary>
        /// 删除酒店
        /// </summary>
        /// <param name="ids">需要删除的酒店</param>
        public void DeleteHotel(List<string> ids)
        {
            this.PerformDeleteObjects<Hotel>(ids, hotelRepository);
        }

        /// <summary>
        /// 更新酒店信息
        /// </summary>
        /// <param name="HotelDataObject">需要更新的酒店</param>
        /// <returns></returns>
        public List<HotelDataObject> UpdateHotel(List<HotelDataObject> HotelDataObject)
        {
            return this.PerformUpdateObjects<List<HotelDataObject>, HotelDataObject, Hotel>(HotelDataObject, hotelRepository
                                                                                           , tdo => tdo.Id.ToString(), null);
        }

        #endregion

        #region 酒店分类
        /// <summary>
        /// 创建酒店分类
        /// </summary>
        /// <param name="hotelCategoryDataObject">需要创建的分类</param>
        /// <returns></returns>
        public List<HotelCategoryDataObject> CreateHotelCategory(List<HotelCategoryDataObject> hotelCategoryDataObject)
        {
          return  this.PerformCreateObjects<List<HotelCategoryDataObject>, HotelCategoryDataObject, HotelCategory>(hotelCategoryDataObject, hotelCategoryRepository);
        }

        /// <summary>
        /// 获取所有酒店分类信息
        /// </summary>
        /// <returns></returns>
        public List<HotelCategoryDataObject> GetHotelCategorys()
        {
            List<HotelCategory> listHotelCategory = hotelCategoryRepository.FindAll().ToList();
            return AutoMapper.Mapper.Map<List<HotelCategory>, List<HotelCategoryDataObject>>(listHotelCategory);
        }

        /// <summary>
        /// 根据分类Id值获取分类信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public HotelCategoryDataObject GetHotelCategoryByKey(Guid Id)
        {
            HotelCategory HotelCategory = hotelCategoryRepository.GetByKey(Id);
            return AutoMapper.Mapper.Map<HotelCategory, HotelCategoryDataObject>(HotelCategory);
        }

        /// <summary>
        /// 根据分类名称获取分类信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public HotelCategoryDataObject GetHotelCategoryByName(string name)
        {
            HotelCategory HotelCategory = hotelCategoryRepository.Find(Specification<HotelCategory>.Eval(h=>h.Name.Equals(name)));
            return AutoMapper.Mapper.Map<HotelCategory, HotelCategoryDataObject>(HotelCategory);
        }

        /// <summary>
        /// 根据酒店名称获取酒店分类
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        public List<HotelCategoryDataObject> GetHotelCategoryByHotelName(string hotelName)
        {
            List<HotelCategory> listHotelCategory = hotelCategoryRepository.GetHotelCategoryByHotelName(hotelName);
            return AutoMapper.Mapper.Map<List<HotelCategory>, List<HotelCategoryDataObject>>(listHotelCategory);
        }


        /// <summary>
        /// 更新酒店分类
        /// </summary>
        /// <param name="hotelCategoryDataObject"></param>
        /// <returns></returns>
        public List<HotelCategoryDataObject> UpdateHotelCategory(List<HotelCategoryDataObject> hotelCategoryDataObject)
        {
           return   this.PerformUpdateObjects<List<HotelCategoryDataObject>, HotelCategoryDataObject, HotelCategory>(hotelCategoryDataObject, hotelCategoryRepository
                                                                                                            , dto => dto.Id.ToString(), null);
        }

        /// <summary>
        /// 删除酒店分类
        /// </summary>
        /// <param name="id">需要删除酒店分类的id值</param>
        public void DeleteHotelCategory(List<string> ids)
        {
            this.PerformDeleteObjects<HotelCategory>(ids, hotelCategoryRepository);
        }

        /// <summary>
        /// 将酒店指向分类
        /// </summary>
        /// <param name="hotelID"></param>
        /// <param name="categoryID"></param>
        public void AssignCategory(Guid hotelID, Guid categoryID)
        {
            hotelCategoryService.AssignCategory(hotelID, categoryID);
        }

        /// <summary>
        /// 将酒店从分类中移除
        /// </summary>
        /// <param name="hotelID"></param>
        /// <param name="categoryID"></param>
        public void UnassignCategory(Guid hotelID, Guid categoryID)
        {
            hotelCategoryService.UnassignCategory(hotelID, categoryID);
        }

        #endregion

        #region 房间
        /// <summary>
        /// 根据酒店名称获取酒店房间
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        public List<RoomDataObject> GetRoomsByHotelName(string hotelName)
        {
           List<Room> listRoom=   roomRepository.GetRoomsByHotelName(hotelName);
            return AutoMapper.Mapper.Map<List<Room>, List<RoomDataObject>>(listRoom);
        }

        #endregion

        #region 酒店图片
        /// <summary>
        /// 创建酒店图片
        /// </summary>
        /// <param name="hotelImageDataObject"></param>
        /// <returns></returns>
        public void AddHotelImage(Guid hotelId, List<HotelImageDataObject> hotelImageDataObject)
        {
            List<HotelImage> listHotelImage = AutoMapper.Mapper.Map<List<HotelImageDataObject>, List<HotelImage>>(hotelImageDataObject);
            hotelRepository.AddHotelImage(hotelId, listHotelImage);
        }

        /// <summary>
        /// 更新酒店图片
        /// </summary>
        /// <param name="hotelImageDataObject"></param>
        /// <returns></returns>
        public List<HotelImageDataObject> UpdateHotelImage(Guid hotelId, List<HotelImageDataObject> hotelImageDataObject)
        {
            List<HotelImage> listHotelImage = AutoMapper.Mapper.Map<List<HotelImageDataObject>, List<HotelImage>>(hotelImageDataObject);
            List<HotelImage> updatelistHotelImage = hotelRepository.UpdateHotelImage(hotelId, listHotelImage);
            return AutoMapper.Mapper.Map<List<HotelImage>, List<HotelImageDataObject>>(updatelistHotelImage);
        }

        /// <summary>
        /// 删除酒店图片
        /// </summary>
        /// <param name="id">需要删除的酒店图片id值</param>
        public void DeleteHotelImage(Guid hotelId, List<string> ids)
        {
            hotelRepository.DeleteHotelImage(hotelId, ids);
        }

        

        /// <summary>
        /// 根据酒店图片id获取酒店图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HotelImageDataObject GetHotelImageByKey(Guid hotelId, Guid id)
        {
            HotelImage hotelImage = hotelRepository.GetHotelImageByKey(hotelId, id);
            return AutoMapper.Mapper.Map<HotelImage, HotelImageDataObject>(hotelImage);
        }


        /// <summary>
        /// 根据酒店id获取酒店图片
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public List<HotelImageDataObject> GetHotelImagesByHotelId(Guid hotelId)
        {
            List<HotelImage> listHotelImage = hotelRepository.GetHotelImagesByHotelId(hotelId);
            return AutoMapper.Mapper.Map<List<HotelImage>, List<HotelImageDataObject>>(listHotelImage);
        }

        /// <summary>
        /// 根据酒店名称获取酒店图片
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        public List<HotelImageDataObject> GetHotelImagesByHotelName(string hotelName)
        {
            List<HotelImage> listHotelImage = hotelRepository.GetHotelImagesByHotelName(hotelName);
            return AutoMapper.Mapper.Map<List<HotelImage>, List<HotelImageDataObject>>(listHotelImage);
        }

        #endregion

        #region 酒店账号

        /// <summary>
        /// 创建酒店账号
        /// </summary>
        /// <param name="HotelAccountDataObject"></param>
        /// <returns></returns>
        public void AddHotelAccount(Guid hotelId,List<HotelAccountDataObject> HotelAccountDataObject)
        {
            List<HotelAccount> listHotelAccount = AutoMapper.Mapper.Map<List<HotelAccountDataObject>, List<HotelAccount>>(HotelAccountDataObject);
            hotelRepository.AddHotelAccount(hotelId, listHotelAccount);
        }

        /// <summary>
        /// 更新酒店账号
        /// </summary>
        /// <param name="HotelAccountDataObject"></param>
        /// <returns></returns>
        public List<HotelAccountDataObject> UpdateHotelAccount(Guid hotelId, List<HotelAccountDataObject> HotelAccountDataObject)
        {
            List<HotelAccount> listHotelAccount = AutoMapper.Mapper.Map<List<HotelAccountDataObject>, List<HotelAccount>>(HotelAccountDataObject);
            List<HotelAccount> updatelistHotelAccount=  hotelRepository.UpdateHotelAccount(hotelId, listHotelAccount);
            return AutoMapper.Mapper.Map<List<HotelAccount>, List<HotelAccountDataObject>>(updatelistHotelAccount);
        }

        /// <summary>
        /// 删除酒店账号
        /// </summary>
        /// <param name="ids">需要删除的酒店账号id值</param>
        public void DeleteHotelAccount(Guid hotelId, List<string> ids)
        {
            hotelRepository.DeleteHotelAccount(hotelId, ids);
        }

      

        /// <summary>
        /// 根据酒店账号id获取酒店账号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HotelAccountDataObject GetHotelAccountByKey(Guid hotelId, Guid id)
        {
            HotelAccount hotelAccount = hotelRepository.GetHotelAccountByKey(hotelId, id);
            return AutoMapper.Mapper.Map<HotelAccount, HotelAccountDataObject>(hotelAccount);
        }


        /// <summary>
        /// 根据酒店id获取酒店账号
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public List<HotelAccountDataObject> GetHotelAccountsByHotelId(Guid hotelId)
        {
            List<HotelAccount> listHotelAccount = hotelRepository.GetHotelAccountsByHotelId(hotelId);
            return AutoMapper.Mapper.Map<List<HotelAccount>, List<HotelAccountDataObject>>(listHotelAccount);
        }

        /// <summary>
        /// 根据酒店名称获取酒店账号
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        public List<HotelAccountDataObject> GetHotelAccountsByHotelName(string hotelName)
        {
            List<HotelAccount> listHotelAccount = hotelRepository.GetHotelAccountsByHotelName(hotelName);
            return AutoMapper.Mapper.Map<List<HotelAccount>, List<HotelAccountDataObject>>(listHotelAccount);
        }

        #endregion

        #region 酒店评论

        /// <summary>
        /// 创建酒店评论
        /// </summary>
        /// <param name="HotelCommentDataObject"></param>
        /// <returns></returns>
        public void  AddHotelComment(Guid hotelId, List<HotelCommentDataObject> HotelCommentDataObject)
        {
            List<HotelComment> listHotelComment = AutoMapper.Mapper.Map<List<HotelCommentDataObject>, List<HotelComment>>(HotelCommentDataObject);
            hotelRepository.AddHotelComment(hotelId, listHotelComment);
        }

        /// <summary>
        /// 更新酒店评论
        /// </summary>
        /// <param name="HotelCommentDataObject"></param>
        /// <returns></returns>
        public List<HotelCommentDataObject> UpdateHotelComment(Guid hotelId, List<HotelCommentDataObject> HotelCommentDataObject)
        {
            List<HotelComment> listHotelComment = AutoMapper.Mapper.Map<List<HotelCommentDataObject>, List<HotelComment>>(HotelCommentDataObject);
            List<HotelComment> updatelistHotelComment= hotelRepository.UpdateHotelComment(hotelId, listHotelComment);
            return AutoMapper.Mapper.Map<List<HotelComment>, List<HotelCommentDataObject>>(updatelistHotelComment);
        }

        /// <summary>
        /// 删除酒店评论
        /// </summary>
        /// <param name="ids">需要删除的酒店评论id值</param>
        public void DeleteHotelComment(Guid hotelId, List<string> ids)
        {
            hotelRepository.DeleteHotelComment(hotelId, ids);
        }

       

        /// <summary>
        /// 根据酒店评论id获取酒店评论
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HotelCommentDataObject GetHotelCommentByKey(Guid hotelId, Guid id)
        {
            HotelComment hotelComment = hotelRepository.GetHotelCommentByKey(hotelId, id);
            return AutoMapper.Mapper.Map<HotelComment, HotelCommentDataObject>(hotelComment);
        }


        /// <summary>
        /// 根据酒店id获取酒店评论
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public List<HotelCommentDataObject> GetHotelCommentsByHotelId(Guid hotelId)
        {
            List<HotelComment> listHotelComment = hotelRepository.GetHotelCommentsByHotelId(hotelId);
            return AutoMapper.Mapper.Map<List<HotelComment>, List<HotelCommentDataObject>>(listHotelComment);
        }

        /// <summary>
        /// 根据酒店名称获取酒店评论
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        public List<HotelCommentDataObject> GetHotelCommentsByHotelName(string hotelName)
        {
            List<HotelComment> listHotelComment = hotelRepository.GetHotelCommentsByHotelName(hotelName);
            return AutoMapper.Mapper.Map<List<HotelComment>, List<HotelCommentDataObject>>(listHotelComment);
        }

        #endregion
    }
}
