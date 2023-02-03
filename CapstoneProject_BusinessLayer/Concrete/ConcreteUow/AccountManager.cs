using CapstoneProject_BusinessLayer.Abstract.AbstractUow;
using CapstoneProject_DataAccessLayer.Abstract;
using CapstoneProject_DataAccessLayer.Concrete;
using CapstoneProject_DataAccessLayer.UnitOfWork;
using CapstoneProject_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.Concrete.ConcreteUow
{
    public class AccountManager : IAccountService
    {
        private readonly IAccountDal _accountDal;
        private readonly IUowDal _uowDal;

        public AccountManager(IAccountDal accountDal, IUowDal uowDal)
        {
            _accountDal = accountDal;
            _uowDal = uowDal;
        }

        public Account TGetByID(int id)
        {
            return _accountDal.GetByID(id);
        }

        public List<Account> TGetByWithOutID(int id)
        {
            Context context = new Context();
            var values = context.Accounts.Where(x => x.AccountID != id).ToList();
            return values;
        }

        public List<Account> TGetList()
        {
            return _accountDal.GetList();
        }

        public void TInsert(Account t)
        {
           _accountDal.Insert(t);
            _uowDal.Save();
        }

        public void TMultiUpdate(List<Account> t)
        {
            _accountDal.MultiUpdate(t);
            _uowDal.Save();
        }

        public void TUpdate(Account t)
        {
            _accountDal.Update(t); 
            _uowDal.Save();
        }
    }
}
