using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain
{
    /// <summary>
    /// 领域实体
    /// </summary>
 public  interface IEntity
    {
        Guid Id { get; set; }
    }
}
