using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLifetime
{
    public class Dependency : ICheckLifetime
    {
        public List<string> Strings { get; set; }

        IOperationTransient transient;

        IOperationScoped scoped;

        IOperationSingleton singleton;
        public Dependency(IOperationTransient transient, IOperationScoped scoped, IOperationSingleton singleton)
        {
            Strings = new List<string>();
            this.transient = transient;
            this.scoped = scoped;
            this.singleton = singleton;
        }
        public List<string> CheckLifetime()
        {
            Strings.Add($"In service transient {this.transient.OperationId}");
            Strings.Add($"In service scoped {this.scoped.OperationId}");
            Strings.Add($"In service singleton {this.singleton.OperationId}");
            return Strings;
        }
    }
}
