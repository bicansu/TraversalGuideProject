using CapstoneProject_BusinessLayer.Abstract;
using CapstoneProject_DataAccessLayer.Abstract;
using CapstoneProject_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_BusinessLayer.Concrete
{
    public class CompanyEventManager : ICompanyEventService
    {
        ICompanyEventDal _companyEventDal;

        public CompanyEventManager(ICompanyEventDal companyEventDal)
        {
            _companyEventDal = companyEventDal;
        }

		 

		public void TAdd(CompanyEvent t)
        {
            _companyEventDal.Insert(t);
        }

        public void TDelete(CompanyEvent t)
        {
            _companyEventDal.Delete(t);
        }

        public CompanyEvent TGetByID(int id)
        {
            return _companyEventDal.GetById(id);
        }
     
        public List<CompanyEvent> TGetList()
        {
            return _companyEventDal.Getlist();
        }

		 

		public void TUpdate(CompanyEvent t)
        {
            _companyEventDal.Update(t);
        }
    }
}
