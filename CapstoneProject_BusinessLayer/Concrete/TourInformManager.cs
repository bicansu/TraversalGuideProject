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
    public class TourInformManager : ITourInformaService
    {
        ITourInformDal _tourInformDal;

        public TourInformManager(ITourInformDal tourInformDal)
        {
            _tourInformDal = tourInformDal;
        }

        public void TAdd(TourInform t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(TourInform t)
        {
            throw new NotImplementedException();
        }

        public TourInform TGetByID(int id)
        {
           return _tourInformDal.GetById(id);
        }

        public List<TourInform> TGetList()
        {
            return _tourInformDal.Getlist();
        }

        public void TUpdate(TourInform t)
        {
            throw new NotImplementedException();
        }
    }
}
