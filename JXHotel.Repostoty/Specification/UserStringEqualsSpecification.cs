using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Specification;
using JXHotel.Domain.Model;

namespace JXHotel.Repository.Specification
{
   public abstract class UserStringEqualsSpecification<TUser> :Specification<TUser>  where TUser:User
    {
        public readonly string value;

        public UserStringEqualsSpecification(string value)
        {
            this.value = value;
        }
    }
}
