using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JXHotel.Domain.Repository;
using JXHotel.Domain;

namespace JXHotel.Repository
{
    public class EntityFrameworkContext : IEntityFrameworkContext
    {
        private readonly ThreadLocal<JXHotelDbContext> localCtx = new ThreadLocal<JXHotelDbContext>(() => new JXHotelDbContext());

        public DbContext dbContext
        {
            get { return localCtx.Value; }
        }

        public bool DistributedTransactionSupported
        {
            get { return true; }
        }


        private bool _IsCommit = false;
        public bool IsCommit
        {
            get { return _IsCommit; }
            set { _IsCommit = value; }
        }

        

        public void Commit()
        {
            if (!IsCommit)
            {
                this.dbContext.SaveChanges();
                this.IsCommit = true;
            }
        }

        public void Dispose()
        {
            localCtx.Value.Dispose();
            localCtx.Dispose();
        }

        public void RollBack()
        {
            this.IsCommit = false;
        }

        public  void RegisterNew<TAggregateRoot>(TAggregateRoot obj) where TAggregateRoot : class, IAggregateRoot
        {
            this.dbContext.Set<TAggregateRoot>().Add(obj);
        }

        public void RegisterModify<TAggregateRoot>(TAggregateRoot obj) where TAggregateRoot : class, IAggregateRoot
        {
            this.dbContext.Entry<TAggregateRoot>(obj).State = System.Data.Entity.EntityState.Modified;
        }

       public void RegisterDeleted<TAggregateRoot>(TAggregateRoot obj) where TAggregateRoot : class, IAggregateRoot
        {
            this.dbContext.Entry<TAggregateRoot>(obj).State = System.Data.Entity.EntityState.Deleted;
        }
    }
}
