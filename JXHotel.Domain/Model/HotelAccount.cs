using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 酒店收付款账号实体
    /// </summary>
  public  class HotelAccount :BankAccount
    {

        public Guid HotelId { get; set; }

        public virtual Hotel Hotel { get; set; }

    }
}
