using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Infrastructure
{
  public  interface IUnitWork
    {
        bool DistributedTransactionSupported { get; }

        bool IsCommit { get; }


        void Commit();

        void RollBack();
    }
}
