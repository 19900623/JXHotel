using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JXHotel.Infrastructure.Transaction
{
    public abstract class TransactionCoordinator : DisposableObject, ITransactionCoordinator
    {
        private readonly List<IUnitWork> managedUnitOfWorks = new List<IUnitWork>();

        public TransactionCoordinator(params IUnitWork[] unitOfWorks)
        {
            if (unitOfWorks != null &&
                unitOfWorks.Length > 0)
            {
                foreach (var uow in unitOfWorks)
                    managedUnitOfWorks.Add(uow);
            }
        }

        protected override void Dispose(bool disposing)
        {
        }

        #region IUnitOfWork Members

        public bool DistributedTransactionSupported
        {
            get { return true; } // 没有意义
        }

        public bool IsCommit
        {
            get { return true; } // 没有意义
        }

        public virtual void Commit()
        {
            if (managedUnitOfWorks.Count > 0)
                foreach (var uow in managedUnitOfWorks)
                    uow.Commit();
        }

        public virtual void RollBack() // 基本上没有意义
        {

        }

        #endregion
    }
}
