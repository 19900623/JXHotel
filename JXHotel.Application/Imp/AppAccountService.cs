using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JXHotel.Domain.Model;
using JXHotel.Domain.Repository;
using JXHotel.DataObject;
using JXHotel.Application.Contract;
using JXHotel.Domain.Specification;
using JXHotel.Infrastructure;

namespace JXHotel.Application.Imp
{  
    /// <summary>
    /// app银行卡账号应用层
    /// </summary>
    public class AppAccountService : ApplicationService, IAppAccountService
    {
        private readonly IAppAccountRepository appAccountRepository;

        public AppAccountService(IRepositoryContext context,IAppAccountRepository appAccountRepository) : base(context)
        {
            this.appAccountRepository = appAccountRepository;
        }

        public List<AppAccountDataObject> CreateAppAccount(List<AppAccountDataObject> appAccountDataObject)
        {
            return  this.PerformCreateObjects<List<AppAccountDataObject>, AppAccountDataObject, AppAccount>(appAccountDataObject, appAccountRepository);
        }

        public void DeleteAppAccount(List<string> ids)
        {
            this.PerformDeleteObjects<AppAccount>(ids, appAccountRepository);
        }

        public List<AppAccountDataObject> GetAppAccount()
        {
          List<AppAccount> listAppAccount = appAccountRepository.FindAll().ToList();
            return AutoMapper.Mapper.Map<List<AppAccount>, List<AppAccountDataObject>>(listAppAccount);
        }

        public AppAccountDataObject GetAppAccountByKey(Guid id)
        {
            AppAccount appAccount = appAccountRepository.GetByKey(id);
            return AutoMapper.Mapper.Map<AppAccount, AppAccountDataObject>(appAccount);
        }

        public AppAccountDataObject GetAppAccountByName(string name)
        {
            AppAccount appAccount = appAccountRepository.Find(Specification<AppAccount>.Eval(app => app.Name.Equals(name)));
            return AutoMapper.Mapper.Map<AppAccount, AppAccountDataObject>(appAccount);
        }

        public List<AppAccountDataObject> UpdateAppAccount(List<AppAccountDataObject> appAccountDataObject)
        {
          return   this.PerformUpdateObjects<List<AppAccountDataObject>, AppAccountDataObject, AppAccount>(appAccountDataObject, appAccountRepository
                                                                                                         , app => app.Id.ToString()
                                                                                                         , null);
        }
    }
}
