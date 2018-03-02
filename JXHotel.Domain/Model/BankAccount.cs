using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 收付款账号
    /// </summary>
  public  abstract class BankAccount  :IEntity
    {
        public Guid Id { get; set; }


        public string Name { get; set; }

        /// <summary>
        /// 是否默认账号
        /// </summary>
        public bool IsDefault { get; set; }
    }
}
