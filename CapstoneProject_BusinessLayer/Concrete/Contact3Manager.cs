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
    public class Contact3Manager : IContact3Service
    {
        IContact3Dal _contact3Dal;

        public Contact3Manager(IContact3Dal contact3Dal)
        {
            _contact3Dal = contact3Dal;
        }

        public void TAdd(Contact3 t)
        {
            _contact3Dal.Insert(t);
        }

        public void TDelete(Contact3 t)
        {
            _contact3Dal.Delete(t);
        }

        public Contact3 TGetByID(int id)
        {
            return _contact3Dal.GetById(id);
        }

        public List<Contact3> TGetList()
        {
           return _contact3Dal.Getlist();
        }

        public void TUpdate(Contact3 t)
        {
            _contact3Dal.Update(t);
        }
    }
}
