using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;
using JXHotel.Domain.Specification;

namespace JXHotel.Repository.Specification
{
   public class UserEmailEqualsSpecification<TUser> :UserStringEqualsSpecification<TUser>  where TUser:User
    {
        public UserEmailEqualsSpecification(string email)
           : base(email)
        { }

        public override System.Linq.Expressions.Expression<Func<TUser, bool>> GetExpression()
        {
            return c => c.Email == value;
        }
    }
}
