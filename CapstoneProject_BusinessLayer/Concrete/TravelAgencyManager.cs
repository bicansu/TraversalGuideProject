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
    public class TravelAgencyManager : ITravelAgencyService
    {
        ITravelAgencyDal _travelsalDal;

        public TravelAgencyManager(ITravelAgencyDal travelsalDal)
        {
            _travelsalDal = travelsalDal;
        }

        public void TAdd(TravelAgency t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(TravelAgency t)
        {
            throw new NotImplementedException();
        }

        public TravelAgency TGetByID(int id)
        {
            return _travelsalDal.GetById(id);
        }

        public List<TravelAgency> TGetList()
        {
            return _travelsalDal.Getlist();
        }

        public void TUpdate(TravelAgency t)
        {
            throw new NotImplementedException();
        }
    }
}
