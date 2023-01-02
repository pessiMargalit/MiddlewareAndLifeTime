using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLifetime
{
    public class Operation : IOperationTransient,
        IOperationScoped,
        IOperationSingleton
    {
        public Guid OperationId { get; private set; }
        public Operation() : this(Guid.NewGuid())
        {
        }

        public Operation(Guid id)
        {
            OperationId = id;
        }

        
    }

}
