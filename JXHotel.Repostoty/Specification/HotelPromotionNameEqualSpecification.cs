using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;

namespace JXHotel.Repository.Specification
{
    public class HotelPromotionNameEqualSpecification : HotelPromotionStringEqualSpecification
    {
        public HotelPromotionNameEqualSpecification(string value) : base(value)
        {
        }

        public override Expression<Func<HotelPromotion, bool>> GetExpression()
        {
            return c => c.Name == value;
        }
    }
}
