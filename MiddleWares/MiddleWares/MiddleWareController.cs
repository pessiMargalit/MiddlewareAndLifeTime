
using Microsoft.AspNetCore.Mvc;
using ServiceLifetime;

namespace MiddleWares
{
    [ApiController]
    [Route("api/MiddleWareController")]
    public class MiddleWareController : ControllerBase
    {
        public List<string> Strings { get; set; } = new List<string>();

        IOperationTransient transient;

        IOperationScoped scoped;

        IOperationSingleton singleton;

        ICheckLifetime checkLifetime;
        public MiddleWareController(IOperationTransient transient, IOperationScoped scoped, IOperationSingleton singleton, ICheckLifetime checkLifetime)
        {
            this.transient = transient;
            this.scoped = scoped;
            this.singleton = singleton;
            this.checkLifetime = checkLifetime;
        }
        //[HttpGet]
        //public string[] GetAll()
        //{
        //    return Fruits.allFruits;
        //}

        [HttpGet]

        public List<string> GetList()
        {

            Strings.Add($"In controller transient {this.transient.OperationId}");
            Strings.Add($"In controller scoped {this.scoped.OperationId}");
            Strings.Add($"In controller singleton {this.singleton.OperationId}");
            foreach (var item in checkLifetime.CheckLifetime())
            {
                Strings.Add(item);
            }

            return Strings;
        }
    }
}
