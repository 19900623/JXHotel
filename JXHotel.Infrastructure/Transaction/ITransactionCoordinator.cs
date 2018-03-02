using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Infrastructure.Transaction
{
    /// <summary>
    /// 事务接口
    /// </summary>
    public interface ITransactionCoordinator : IUnitWork, IDisposable
    {
    }
}
