using Mediator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.Service
{
    public interface IService
    {
        IList<Person> GetPersons();
    }
}
