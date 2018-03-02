using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using JXHotel.Domain;
using JXHotel.Repository;
using JXHotel.Domain.Specification;

namespace JXHotel.WebApi.Controllers
{
    public class UserController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Domain.Model.User> Get()
        {
            EntityFrameworkContext efcontext = new EntityFrameworkContext();
            
            EntityFrameworkRepository<Domain.Model.User> userrespos = new EntityFrameworkRepository<Domain.Model.User>(efcontext);
           IEnumerable<Domain.Model.User> users=  userrespos.GetAll();
           
            return users;
        }

        // GET api/<controller>/5
        public Domain.Model.User Get(Guid id) 
        {
            EntityFrameworkContext efcontext = new EntityFrameworkContext();
            EntityFrameworkRepository<Domain.Model.User> userrespos = new EntityFrameworkRepository<Domain.Model.User>(efcontext);
            Domain.Model.User user = userrespos.GetByKey(id);
            return user;
        }

        //Get api/user?email=emali
        public Domain.Model.User GetByEmail(string  email)
        {
            EntityFrameworkContext efcontext = new EntityFrameworkContext();
            EntityFrameworkRepository<Domain.Model.User> userrespos = new EntityFrameworkRepository<Domain.Model.User>(efcontext);
            Domain.Model.User user = userrespos.Get(Specification<JXHotel.Domain.Model.User>.Eval(u=>u.Email.Equals(email))); 
            return user;
        }




        // POST api/<controller>
        public void Post([FromBody]string value)
        {

        }

        // PUT api/<controller>/5
        public void Put([FromBody]string value)
        {

        }

        // DELETE api/<controller>/5
        public void Delete(Guid id)
        {
            EntityFrameworkContext efcontext = new EntityFrameworkContext();
            EntityFrameworkRepository<Domain.Model.User> userrespos = new EntityFrameworkRepository<Domain.Model.User>(efcontext);
            Domain.Model.User user = userrespos.GetByKey(id);
            userrespos.Remove(user);
            efcontext.Commit();
        }
    }
}