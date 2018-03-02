using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Domain.Model
{
    /// <summary>
    /// 房间预定状态
    /// </summary>
  public  enum ReservationStatus
    {
        /// <summary>
        /// 预定被创建
        /// </summary>
        Created = 0,

        /// <summary>
        /// 效费者已付款
        /// </summary>
        Paid,

        /// <summary>
        /// 预定取消
        /// </summary>
        Cancel,

        /// <summary>
        /// 预定结束
        /// </summary>
        Complete
        
    }
}
