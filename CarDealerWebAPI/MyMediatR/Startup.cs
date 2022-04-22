using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace MyMediatR
{
    public class Startup
    {
       public Mediator _mediator { get; set; }
       public Startup(IUnityContainer container)
       {

            _mediator = new Mediator(services);

       }
    }
}
