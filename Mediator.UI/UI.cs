//using Mediator.Service;
using Mediator.Model;
using Mediator.Pattern.Implementation;
using Mediator.Pattern.Interface;
using System;
using System.Collections.Generic;

namespace Mediator.UI
{
    public class UI : IUI
    {
        //private readonly IService _service;
        private readonly IMediator _mediator;
             
        public UI(IMediator mediator)
        {
            _mediator = mediator;
        }
        public void ShowPersons()
        {
            var persons = _mediator.Dispatch<GetPersonsFromXmlQuery, IList<Person>>(new GetPersonsFromXmlQuery());

            foreach(var p in persons)
            {
                Console.WriteLine($"{p.Id} - {p.Name} - {p.Age}");
            }

            Console.ReadKey();
        }
    }
}
