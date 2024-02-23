using Mediator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Mediator.Service
{
    public class XmlService : IService
    {
        //private readonly string _filePath;
        private readonly string _xmlData =
            @"<persons>
                <person id='1'>
                    <name>Olivier</name>
                    <age>46</age>
                </person>
                 <person id='2'>
                    <name>Anne</name>
                    <age>43</age>
                </person>
                <person id='3'>
                    <name>Yohan</name>
                    <age>16</age>
                </person>
                 <person id='4'>
                    <name>Noemie</name>
                    <age>9</age>
                </person>                
            </persons>";


        //public XmlService(string filePath)
        //{
        //    _filePath = filePath;
        //}

        public XmlService()
        {

        }

        IList<Person> IService.GetPersons()
        {
            var result = new List<Person>();
            XDocument xdoc = XDocument.Parse(_xmlData);
            result.AddRange(xdoc.Element("persons").Elements("person").Select(e => new Person
            {
                Id = int.Parse(e.Attribute("id").Value),
                Name = e.Element("name").Value,
                Age = int.Parse(e.Element("age").Value)
            }));

            return result;
        }
    }
}
