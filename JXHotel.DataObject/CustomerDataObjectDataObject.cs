using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace JXHotel.DataObject
{
    /// <summary>
    /// 消费者聚合根
    /// </summary>
    [DataContract]
    public   class CustomerDataObject : UserDataObject
    {
        //public Customer()
        //{
        //    CustomerAccount = new HashSet<CustomerAccount>();
        //    Reservations = new HashSet<Reservation>();
        //}

        /// <summary>
        /// 角色Id
        /// </summary>
        [DataMember]
        public Guid CustomerRoleId { get; set; }

        //public virtual CustomerRole CustomerRole { get; set; }

        [DataMember]
        public  List<CustomerAccountDataObject> CustomerAccount { get; set; }

        //public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
