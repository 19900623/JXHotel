using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 消费者聚合根
    /// </summary>
 public   class Customer :User
    {
        public Customer()
        {
            CustomerAccount = new List<CustomerAccount>();
            Reservations = new List<Reservation>();
        }

        /// <summary>
        /// 角色Id
        /// </summary>
        public Guid CustomerRoleId { get; set; }

        public virtual CustomerRole CustomerRole { get; set; }

        public virtual List<CustomerAccount> CustomerAccount { get; set; }

        public virtual List<Reservation> Reservations { get; set; }
    }
}
