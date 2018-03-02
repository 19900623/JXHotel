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
    /// 消费者收付款账号
    /// </summary>
    [DataContract]
    public class CustomerAccountDataObject : BankAccountDataObject
    {
        [DataMember]
        public Guid CustomerId { get; set; }

        //public virtual Customer Customer { get; set; }
    }
}
