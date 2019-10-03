using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Serialization
{

    /*
     * POCO - plain old clr object
     * a class with jusr public get set properties and default constructor
     */
    class Person
    {
        [XmlAttribute]
        public int ID { get; set; }

        //[XmlAttribute(ElementName = "FirstName")] //if the xml doc refers to them differently
        public string Name { get; set; }

        public Address Address { get; set; }
    }
}
