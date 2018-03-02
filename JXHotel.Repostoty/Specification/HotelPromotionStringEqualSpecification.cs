using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Specification;
using JXHotel.Domain.Model;
using System.Linq.Expressions;

namespace JXHotel.Repository.Specification
{
    public abstract class HotelPromotionStringEqualSpecification : Specification<HotelPromotion>
    {
        public readonly string value;

        public HotelPromotionStringEqualSpecification(string value)
        {
            this.value = value;
        }
    }
}
