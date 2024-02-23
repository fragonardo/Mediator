using Mediator.Model;
using Mediator.Pattern.Interface;
using Mediator.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using 

namespace Mediator.Pattern.Implementation.Handler
{
    public class GetPersonsFromXmlHandler : IQueryHandler<GetPersonsFromXmlQuery, IList<Person>>
    {
        private readonly IService _service;

        public GetPersonsFromXmlHandler(IService service)
        {
            _service = service;
        }



        public IList<Person> Handle(GetPersonsFromXmlQuery query)
        {
            return _service.GetPersons();
        }
    }
}
