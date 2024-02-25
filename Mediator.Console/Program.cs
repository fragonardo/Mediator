using System;
using Mediator.Pattern.Interface;
using Mediator.Pattern.Implementation;
using Mediator.Service;
using Mediator.UI;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using Mediator.Model;
using Mediator.Pattern.Implementation.Handler;

namespace Mediator.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.Console.WriteLine("Hello World!");
            var provider = CreateService();

            var ui = provider.GetService<IUI>();
            ui.ShowPersons();
        }

        private static IServiceProvider CreateService()
        {
            return new ServiceCollection()
                .AddSingleton<IService, XmlService>()
                .AddSingleton<IUI, UI.UI>()
                .AddSingleton<IHandler<GetPersonsFromXmlQuery, IList<Person>>, GetPersonsFromXmlHandler>()
                .AddSingleton<IMediator, Pattern.Implementation.Mediator>(provider =>
                {
                    //var mediator = new Pattern.Implementation.Mediator();
                    //mediator.Register(provider.GetService<IQueryHandler<GetPersonsFromXmlQuery, IList<Person>>>());
                    //return mediator;
                    return (Pattern.Implementation.Mediator)RegisterHandlers(provider);
                }).BuildServiceProvider();
        }

        private static IMediator RegisterHandlers(IServiceProvider provider)
        {
            IMediator mediator = new Pattern.Implementation.Mediator();
            mediator.Register(provider.GetService<IHandler<GetPersonsFromXmlQuery, IList<Person>>>());
            return mediator;
        }
    }
}
