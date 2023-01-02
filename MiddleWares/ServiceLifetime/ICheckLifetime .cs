using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLifetime
{
    public interface ICheckLifetime
    {
       public List<string> CheckLifetime();
    }
}
