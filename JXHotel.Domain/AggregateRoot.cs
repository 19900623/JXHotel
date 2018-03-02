using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain
{
    /// <summary>
    /// 聚合根基类型
    /// </summary>
    public class AggregateRoot : IAggregateRoot
    {
        public Guid Id { get ; set; }
    }
}
