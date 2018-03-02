using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;
using JXHotel.Domain.Repository;

namespace JXHotel.Domain.Service
{
    /// <summary>
    /// 酒店与酒店分类聚合服务
    /// </summary>
    public class HotelCategoryService : IHotelCategoryService
    {

        private readonly IRepositoryContext repositoryContext;
        private readonly IHotelRepository hotelRepository;
        private readonly IHotelCategoryRepository hotelCategoryRepository;

        public HotelCategoryService(IRepositoryContext repositoryContext, IHotelRepository hotelRepository
                                                                          ,IHotelCategoryRepository hotelCategoryRepository)
        {
            this.repositoryContext = repositoryContext;
            this.hotelRepository = hotelRepository;
            this.hotelCategoryRepository = hotelCategoryRepository;
        }

        /// <summary>
        /// 将酒店指向分类
        /// </summary>
        /// <param name="hotelID"></param>
        /// <param name="categoryID"></param>
        public  void AssignCategory(Guid hotelID, Guid categoryID)
        {
            Hotel hotel = hotelRepository.GetByKey(hotelID);
            HotelCategory hotelCategory = hotelCategoryRepository.GetByKey(categoryID);
            hotel.HotelCategorys.Add(hotelCategory);
            hotelRepository.Update(hotel);
            repositoryContext.Commit();
        }


        /// <summary>
        /// 将酒店从分类中移除
        /// </summary>
        /// <param name="hotelID"></param>
        /// <param name="categoryID"></param>
       public  void UnassignCategory(Guid hotelID, Guid categoryID)
        {
            Hotel hotel = hotelRepository.GetByKey(hotelID);
            HotelCategory hotelCategory = hotelCategoryRepository.GetByKey(categoryID);
            hotel.HotelCategorys.Remove(hotelCategory);
            hotelRepository.Update(hotel);
            repositoryContext.Commit();
        }
    }
}
