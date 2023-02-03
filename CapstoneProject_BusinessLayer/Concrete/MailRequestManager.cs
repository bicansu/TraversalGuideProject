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
    public class MailRequestManager : IMailRequestService
    {
        IMailRequestDal _mailRequestDal;

        public MailRequestManager(IMailRequestDal mailRequestDal)
        {
            _mailRequestDal = mailRequestDal;
        }

        public void TAdd(MailRequest t)
        {
            _mailRequestDal.Insert(t);
        }

        public void TDelete(MailRequest t)
        {
            throw new NotImplementedException();
        }

        public MailRequest TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<MailRequest> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(MailRequest t)
        {
            throw new NotImplementedException();
        }
    }
}
