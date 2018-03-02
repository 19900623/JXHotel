using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using JXHotel.Application.Contract;
using JXHotel.DataObject;
using JXHotel.Domain.Repository;
using JXHotel.Domain.Service;
using JXHotel.Domain.Specification;
using JXHotel.Domain.Model;

namespace JXHotel.Application.Imp
{
    /// <summary>
    /// 酒店优惠活动应用层
    /// </summary>
    public class HotelPromotionService<THotelPromotionDataObject, TAgregate> : ApplicationService,IHotelPromotionService<THotelPromotionDataObject> 
                                                                 where THotelPromotionDataObject : HotelPromotionDataObject
                                                                 where TAgregate : HotelPromotion
    {

        private readonly IHotelPromotionRepository<TAgregate> hotelPromotionRepository;
        private readonly IHotelRepository hotelRepository;
        private readonly ICustomerRoleRepository customerRoleRepository;
        private readonly IHotelPromotionCustomerRoleService hotelPromotionCustomerRoleService;
        private readonly IHotelPromotionRoomCategoryService hotelPromotionRoomCategoryService;
        private readonly IHotelRoomCategoryRepository hotelRoomCategoryRepository;

        public HotelPromotionService(IRepositoryContext context,IHotelPromotionRepository<TAgregate> hotelPromotionRepository
                                    ,IHotelRepository hotelRepository
                                    ,ICustomerRoleRepository customerRoleRepository
                                    ,IHotelRoomCategoryRepository hotelRoomCategoryRepository
                                    , IHotelPromotionCustomerRoleService hotelPromotionCustomerRoleService
                                    ,IHotelPromotionRoomCategoryService hotelPromotionRoomCategoryService) : base(context)
        {
            this.hotelPromotionRepository = hotelPromotionRepository;
            this.hotelRepository = hotelRepository;
            this.customerRoleRepository = customerRoleRepository;
            this.hotelRoomCategoryRepository = hotelRoomCategoryRepository;
            this.hotelPromotionCustomerRoleService = hotelPromotionCustomerRoleService;
            this.hotelPromotionRoomCategoryService = hotelPromotionRoomCategoryService;
        }


        #region 酒店优惠活动
        /// <summary>
        /// 创建酒店优惠活动
        /// </summary>
        /// <param name="HotelPromotionDataObject"></param>
        /// <returns></returns>
        public List<THotelPromotionDataObject> CreateHotelPromotion(List<THotelPromotionDataObject> HotelPromotionDataObject)
        {
           return  this.PerformCreateObjects<List<THotelPromotionDataObject>, THotelPromotionDataObject, TAgregate>(HotelPromotionDataObject, hotelPromotionRepository);
        }

        /// <summary>
        /// 获取所有酒店优惠活动
        /// </summary>
        /// <param name="spec">查询方式</param>
        /// <returns></returns>
        public List<THotelPromotionDataObject> GetHotelPromotions(QuerySpec spec)
        {
            IEnumerable<TAgregate> hotelPromotions;
            if(!spec.Verbose)
            {
                hotelPromotions = hotelPromotionRepository.FindAll();
            }
            else
            {
                hotelPromotions = hotelPromotionRepository.FindAll(new AnySpecification<TAgregate>(), t => t.CustomerRoles,t=>t.HotelRoomCategorys,t=>t.PromotionImages);
            }
            List<THotelPromotionDataObject> hotelPromotionDataObjects = AutoMapper.Mapper.Map<List<TAgregate>, List<THotelPromotionDataObject>>(hotelPromotions.ToList());
            return hotelPromotionDataObjects;
        }


        /// <summary>
        /// 根据Id值获取酒店优惠活动
        /// </summary>
        /// <param name="Id">id值</param>
        /// <param name="spec">查询方式</param>
        /// <returns></returns>
        public THotelPromotionDataObject GetHotelPromotionByKey(Guid Id, QuerySpec spec)
        {
            TAgregate hotelPromotion;
            if (!spec.Verbose)
            {
                hotelPromotion = hotelPromotionRepository.GetByKey(Id);
             }
            else
            {
                hotelPromotion = hotelPromotionRepository.Find(Specification<TAgregate>.Eval(t => t.Id.Equals(Id)),t=>t.CustomerRoles,t=>t.HotelRoomCategorys,t=>t.PromotionImages);
            }
            return AutoMapper.Mapper.Map<TAgregate, THotelPromotionDataObject>(hotelPromotion);
        }

        /// <summary>
        /// 根据酒店优惠活动名称获取酒店优惠活动
        /// </summary>
        /// <param name="name">酒店优惠活动名称</param>
        /// <param name="spec">查询方式</param>
        /// <returns></returns>
        public THotelPromotionDataObject GetHotelPromotionByName(string name, QuerySpec spec)
        {
            TAgregate hotelPromotion;
            if (!spec.Verbose)
            {
                hotelPromotion = hotelPromotionRepository.Find(Specification<TAgregate>.Eval(t => t.Name.Equals(name)));
            }
            else
            {
                hotelPromotion = hotelPromotionRepository.Find(Specification<TAgregate>.Eval(t => t.Name.Equals(name)), t => t.CustomerRoles, t => t.HotelRoomCategorys, t => t.PromotionImages);
            }
            return AutoMapper.Mapper.Map<TAgregate, THotelPromotionDataObject>(hotelPromotion);

        }

        /// <summary>
        /// 删除酒店优惠活动
        /// </summary>
        /// <param name="ids">需要删除的酒店优惠活动</param>
        public void DeleteHotelPromotion(List<string> ids)
        {
            this.PerformDeleteObjects<TAgregate>(ids, hotelPromotionRepository);
        }

        /// <summary>
        /// 更新酒店优惠活动信息
        /// </summary>
        /// <param name="HotelPromotionDataObject">需要更新的酒店优惠活动</param>
        /// <returns></returns>
        public List<THotelPromotionDataObject> UpdateHotelPromotion(List<THotelPromotionDataObject> HotelPromotionDataObject)
        {
           return    this.PerformUpdateObjects<List<THotelPromotionDataObject>, THotelPromotionDataObject, TAgregate>(HotelPromotionDataObject, hotelPromotionRepository
                                                                                                              , t => t.Id.ToString()
                                                                                                              , null);
        }

        /// <summary>
        /// 根据酒店id获取酒店活动
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public List<THotelPromotionDataObject> GetHotelPromotionsByHotelId(Guid hotelId)
        {
            var  hotelPromotion = hotelPromotionRepository.FindAll(Specification<TAgregate>.Eval(t => t.HotelId.Equals(hotelId)));
            return AutoMapper.Mapper.Map<List<TAgregate>, List<THotelPromotionDataObject>>(hotelPromotion.ToList());

        }

        /// <summary>
        /// 根据消费者角色id获取酒店活动
        /// </summary>
        /// <param name="customerRoleId"></param>
        /// <returns></returns>
        public List<THotelPromotionDataObject> GetHotelPromotionsByCustomerRoleId(Guid customerRoleId)
        {
            List<TAgregate> listTAgregate = hotelPromotionRepository.GetHotelPromotionsByCustomerRoleId(customerRoleId);
            return AutoMapper.Mapper.Map<List<TAgregate>, List<THotelPromotionDataObject>>(listTAgregate);
        }

        /// <summary>
        /// 根据酒店房间分类id获取酒店活动
        /// </summary>
        /// <param name="hotelRoomCategoryId"></param>
        /// <returns></returns>
        public List<THotelPromotionDataObject> GetHotelPromotionsByHotelRoomCategoryId(Guid hotelRoomCategoryId)
        {
            List<TAgregate> listTAgregate = hotelPromotionRepository.GetHotelPromotionsByHotelRoomCategoryId(hotelRoomCategoryId);
            return AutoMapper.Mapper.Map<List<TAgregate>, List<THotelPromotionDataObject>>(listTAgregate);
        }

        /// <summary>
        /// 根据消费者id获取酒店活动
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public List<THotelPromotionDataObject> GetHotelPromotionsByCustomerId(Guid customerId)
        {
            List<TAgregate> listTAgregate = hotelPromotionRepository.GetHotelPromotionsByCustomerId(customerId);
            return AutoMapper.Mapper.Map<List<TAgregate>, List<THotelPromotionDataObject>>(listTAgregate);
        }

        /// <summary>
        /// 根据房间id获取酒店活动
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        public List<THotelPromotionDataObject> GetHotelPromotionsByRoomId(Guid roomId)
        {
            List<TAgregate> listTAgregate = hotelPromotionRepository.GetHotelPromotionsByRoomId(roomId);
            return AutoMapper.Mapper.Map<List<TAgregate>, List<THotelPromotionDataObject>>(listTAgregate);
        }

        #endregion

        #region 活动图片
        /// <summary>
        /// 创建活动图片
        /// </summary>
        /// <param name="PromotionImageDataObject"></param>
        /// <returns></returns>
        public void AddPromotionImage(Guid PromotionId, List<PromotionImageDataObject> PromotionImageDataObject)
        {
            List<PromotionImage> listPromotionImage = AutoMapper.Mapper.Map<List<PromotionImageDataObject>, List<PromotionImage>>(PromotionImageDataObject);
             hotelPromotionRepository.AddPromotionImage(PromotionId, listPromotionImage);
        }

        /// <summary>
        /// 更新活动图片
        /// </summary>
        /// <param name="PromotionImageDataObject"></param>
        /// <returns></returns>
        public List<PromotionImageDataObject> UpdatePromotionImage(Guid PromotionId, List<PromotionImageDataObject> PromotionImageDataObject)
        {
            List<PromotionImage> listPromotionImage = AutoMapper.Mapper.Map<List<PromotionImageDataObject>, List<PromotionImage>>(PromotionImageDataObject);
           List< PromotionImage> updatePromotionImages=  hotelPromotionRepository.UpdatePromotionImage(PromotionId, listPromotionImage);
            return AutoMapper.Mapper.Map<List<PromotionImage>, List<PromotionImageDataObject>>(updatePromotionImages);
        }

        /// <summary>
        /// 删除活动图片
        /// </summary>
        /// <param name="ids">需要删除的活动图片id值</param>
        public void DeletePromotionImage(Guid PromotionId, List<string> ids)
        {
            hotelPromotionRepository.DeletePromotionImage(PromotionId, ids);
        }

        /// <summary>
        /// 获取所有活动图片
        /// </summary>
        /// <returns></returns>
        public List<PromotionImageDataObject> GetPromotionImages(Guid PromotionId)
        {
           List<PromotionImage> listPromotionImage=  hotelPromotionRepository.GetPromotionImages(PromotionId);
            return AutoMapper.Mapper.Map<List<PromotionImage>, List<PromotionImageDataObject>>(listPromotionImage);
        }

        /// <summary>
        /// 根据活动图片id获取活动图片
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PromotionImageDataObject GetPromotionImageByKey(Guid PromotionId, Guid id)
        {
            PromotionImage promotionImage = hotelPromotionRepository.GetPromotionImageByKey(PromotionId, id);
            return AutoMapper.Mapper.Map<PromotionImage, PromotionImageDataObject>(promotionImage);
        }


        /// <summary>
        /// 根据酒店id获取活动图片
        /// </summary>
        /// <param name="hotelId"></param>
        /// <returns></returns>
        public List<PromotionImageDataObject> GetPromotionImagesByHotelId(Guid hotelId)
        {
            List<PromotionImage> listPromotionImage = hotelPromotionRepository.GetPromotionImagesByHotelId(hotelId);
            return AutoMapper.Mapper.Map<List<PromotionImage>, List<PromotionImageDataObject>>(listPromotionImage);
        }

        /// <summary>
        /// 根据酒店名称获取活动图片
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        public List<PromotionImageDataObject> GetPromotionImagesByHotelName(string hotelName)
        {
            List<PromotionImage> listPromotionImage = hotelPromotionRepository.GetPromotionImagesByHotelName(hotelName);
            return AutoMapper.Mapper.Map<List<PromotionImage>, List<PromotionImageDataObject>>(listPromotionImage);
        }

        #endregion

        #region 消费者角色
        /// <summary>
        /// 根据活动id获取消费者角色
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <returns></returns>
        public List<CustomerRoleDataObject> GetCustomerRoleByHotelPromotionId(Guid hotelPromotionId)
        {
           List<CustomerRole> listCustomerRole= customerRoleRepository.GetCustomerRoleByHotelPromotionId(hotelPromotionId);
            return AutoMapper.Mapper.Map<List<CustomerRole>, List<CustomerRoleDataObject>>(listCustomerRole);
        }

        /// <summary>
        /// 根据活动名称获取消费者角色
        /// </summary>
        /// <param name="hotelPromotionName"></param>
        /// <returns></returns>
        public List<CustomerRoleDataObject> GetCustomerRoleByHotelPromotionName(string  hotelPromotionName)
        {
            List<CustomerRole> listCustomerRole = customerRoleRepository.GetCustomerRoleByHotelPromotionName(hotelPromotionName);
            return AutoMapper.Mapper.Map<List<CustomerRole>, List<CustomerRoleDataObject>>(listCustomerRole);
        }

        /// <summary>
        /// 将活动指向消费者角色
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <param name="CustomerRoleID"></param>
        public void AssignCustomerRole(Guid hotelPromotionId, Guid CustomerRoleID)
        {
            hotelPromotionCustomerRoleService.AssignCustomerRole(hotelPromotionId, CustomerRoleID);
        }

        /// <summary>
        /// 将活动从消费者角色中移除
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <param name="CustomerRoleID"></param>
        public void UnassignCustomerRole(Guid hotelPromotionId, Guid CustomerRoleID)
        {
            hotelPromotionCustomerRoleService.UnassignCustomerRole(hotelPromotionId, CustomerRoleID);
        }
        #endregion

        #region 房间分类
        /// <summary>
        /// 根据活动id获取房间分类
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <returns></returns>
        public List<HotelRoomCategoryDataObject> GetHotelRoomCategoryByHotelPromotionId(Guid hotelPromotionId)
        {
           List<HotelRoomCategory> listHotelRoomCategory=  hotelRoomCategoryRepository.GetHotelRoomCategoryByHotelPromotionId(hotelPromotionId);
           return AutoMapper.Mapper.Map<List<HotelRoomCategory>, List<HotelRoomCategoryDataObject>>(listHotelRoomCategory);
        }

        /// <summary>
        /// 根据活动名称获取房间分类
        /// </summary>
        /// <param name="hotelPromotionName"></param>
        /// <returns></returns>
        public List<HotelRoomCategoryDataObject> GetHotelRoomCategoryByHotelPromotionName(string hotelPromotionName)
        {
            List<HotelRoomCategory> listHotelRoomCategory = hotelRoomCategoryRepository.GetHotelRoomCategoryByHotelPromotionName(hotelPromotionName);
            return AutoMapper.Mapper.Map<List<HotelRoomCategory>, List<HotelRoomCategoryDataObject>>(listHotelRoomCategory);
        }

        /// <summary>
        /// 将活动指向房间分类
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <param name="HotelRoomCategoryID"></param>
        public void AssignHotelRoomCategory(Guid hotelPromotionId, Guid HotelRoomCategoryID)
        {
            hotelPromotionRoomCategoryService.AssignHotelRoomCategory(hotelPromotionId, HotelRoomCategoryID);
        }

        /// <summary>
        /// 将活动从房间分类中移除
        /// </summary>
        /// <param name="hotelPromotionId"></param>
        /// <param name="HotelRoomCategoryID"></param>
        public void UnassignHotelRoomCategory(Guid hotelPromotionId, Guid HotelRoomCategoryID)
        {
            hotelPromotionRoomCategoryService.UnassignHotelRoomCategory(hotelPromotionId, HotelRoomCategoryID);
        }
        #endregion

    }
}
