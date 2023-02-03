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
    public class SubscriberManager : ISubscriberService
    {
        ISubscriberDal _subscriberDal;

        public SubscriberManager(ISubscriberDal subscriberdal)
        {
            _subscriberDal = subscriberdal;
        }

        public void TAdd(Subscriber t)
        {
            _subscriberDal.Insert(t);
        }

        public void TDelete(Subscriber t)
        {
            _subscriberDal.Delete(t);
        }

        public Subscriber TGetByID(int id)
        {
            return _subscriberDal.GetById(id);
        }

        public List<Subscriber> TGetList()
        {
           return _subscriberDal.Getlist();
        }

        public void TUpdate(Subscriber t)
        {
            _subscriberDal.Update(t);
        }
    }
}
