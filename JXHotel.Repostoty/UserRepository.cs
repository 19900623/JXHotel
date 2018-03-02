using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;
using JXHotel.Domain.Repository;
using JXHotel.Domain.Specification;
using JXHotel.Repository.Specification;

namespace JXHotel.Repository
{
    public class UserRepository<TUser> : EntityFrameworkRepository<TUser> , IUserRepository<TUser>  where TUser:User
    {
        public UserRepository(IRepositoryContext context) : base(context)
        {

        }


        public bool CheckPassword(string userName, string password)
        {
            //this.GetBySpec(Specification<T>.Eval(a => a.Name.Equals(userName)));
            AndSpecification<TUser> and = new AndSpecification<TUser>(new UserNameEqualsSpecification<TUser>(userName), new UserPasswordEqualsSpecification<TUser>(password));
           return  this.Exists(and);
                     
        }

        public bool EmailExists(string email)
        {
           return  this.Exists(new UserEmailEqualsSpecification<TUser>(email));
        }

        public TUser GetUserByEmail(string email)
        {
            //return   this.Find(Specification<TUser>.Eval(user => user.Email.Equals(email)));
            return this.Find(new UserEmailEqualsSpecification<TUser>(email));
        }  

        public TUser GetUserByName(string userName)
        {
            //return this.Find(Specification<TUser>.Eval(user => user.Name.Equals(userName )));
            return this.Find(new UserNameEqualsSpecification<TUser>(userName));
        }

        public bool UserNameExists(string userName)
        {
            //return this.Exists(Specification<TUser>.Eval(u => u.Name.Equals(userName)));
            return this.Exists(new UserNameEqualsSpecification<TUser>(userName));
        }
    }
}
