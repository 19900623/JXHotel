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
    public class HotelCategoryRepository : EntityFrameworkRepository<HotelCategory>, IHotelCategoryRepository
    {
        public HotelCategoryRepository(IRepositoryContext context) : base(context)
        {

        }

        /// <summary>
        /// 根据酒店名称获取酒店分类
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
       public List<HotelCategory> GetHotelCategoryByHotelName(string hotelName)
        {
            var context = EFContext.dbContext as JXHotelDbContext;
            Hotel hotel =  context.Hotels.Where(new HotelNameEqualSpecification(hotelName).GetExpression()).FirstOrDefault();
            return hotel.HotelCategorys;


        }
    }
}
