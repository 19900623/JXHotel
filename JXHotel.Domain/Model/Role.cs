using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 用户角色
    /// </summary>
  public class Role  :AggregateRoot
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public string Name { get; set; }


        public string Description { get; set; }


        public virtual ICollection<User> Users { get; set; }


    }
}
