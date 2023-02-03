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
    public class OurInfoManager : IOurInfoService
    {
        IOurInfoDal _OurInfoDal;

        public OurInfoManager(IOurInfoDal OurInfoDal)
        {
            _OurInfoDal = OurInfoDal;
        }

        public void TAdd(OurInfo t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(OurInfo t)
        {
            throw new NotImplementedException();
        }

        public OurInfo TGetByID(int id)
        {
            return _OurInfoDal.GetById(id);
        }
     
        public List<OurInfo> TGetList()
        {
            return _OurInfoDal.Getlist();
        }

        public void TUpdate(OurInfo t)
        {
            throw new NotImplementedException();
        }
    }
}
