using CapstoneProject_DataAccessLayer.Concrete;
using CapstoneProject_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_DataAccessLayer.Abstract
{
    public interface IAboutDal : IGenericDal<About>
    {
        public List<About> GetStatTrue()
        {
            using var c = new Context();
          
            return c.Set<About>().Where(x => x.Status == true).ToList();
        }
    }
}
