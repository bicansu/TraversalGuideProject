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
    public class EventTypeManager : IEventTypeService
    {
        IEventTypeDal _eventTypeDal;

        public EventTypeManager(IEventTypeDal eventTypeDal)
        {
            _eventTypeDal = eventTypeDal;
        }

		 

		public void TAdd(EventType t)
        {
            _eventTypeDal.Insert(t);
        }

        public void TDelete(EventType t)
        {
            _eventTypeDal.Delete(t);
        }

        public EventType TGetByID(int id)
        {
            return _eventTypeDal.GetById(id);
        }
     
        public List<EventType> TGetList()
        {
            return _eventTypeDal.Getlist();
        }

		 

		public void TUpdate(EventType t)
        {
            _eventTypeDal.Update(t);
        }
    }
}
