using CapstoneProject_DataAccessLayer.Abstract;
using CapstoneProject_DataAccessLayer.Concrete;
using CapstoneProject_DataAccessLayer.Repository;
using CapstoneProject_EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneProject_DataAccessLayer.EntityFramework
{
    public class EfAccountDal:GenericUowRepository<Account>, IAccountDal
    {
        public EfAccountDal(Context context):base(context)
        {
        
        }
    }
}
