using Core.DataAccess;
using Entitites.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICityDal:IEntityRepository<City>
    {
    }
}
