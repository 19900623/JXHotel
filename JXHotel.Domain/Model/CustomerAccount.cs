using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 消费者收付款账号实体
    /// </summary>
   public class CustomerAccount  :BankAccount
    {
        public Guid CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
