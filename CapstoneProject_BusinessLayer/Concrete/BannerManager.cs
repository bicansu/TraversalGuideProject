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
    public class BannerManager : IBannerService
    {
        IBannerDal _bannerDal;

        public BannerManager(IBannerDal bannerDal)
        {
            _bannerDal = bannerDal;
        }

        public void TAdd(Banner t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Banner t)
        {
            throw new NotImplementedException();
        }

        public Banner TGetByID(int id)
        {
            throw new NotImplementedException();
        }
     
        public List<Banner> TGetList()
        {
            return _bannerDal.Getlist();
        }

        public void TUpdate(Banner t)
        {
            throw new NotImplementedException();
        }
    }
}
