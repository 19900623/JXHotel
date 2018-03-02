using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using JXHotel.Domain.Model;

namespace JXHotel.Repository.Specification
{
  public  class HotelNameEqualSpecification : HotelStringEqualSpecification
    {
        public HotelNameEqualSpecification(string value) : base(value)
        {
        }

        public override Expression<Func<Hotel, bool>> GetExpression()
        {
            return c => c.Name == value;
        }
    }
}