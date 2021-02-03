using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DaraAccess.Abstract
{
    public interface ICustomerDal : IEntityRepository<Customer>
    {
    }
}
