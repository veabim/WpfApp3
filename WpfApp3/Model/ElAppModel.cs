using System;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using WpfApp3.ViewModel;

namespace WpfApp3.Model
{
    class ElAppModel
    {
        ElCircuet elCircuet = new ElCircuet();
        public void fddf()
        {
            JsonSerializer serializer = new JsonSerializer();
            Person tom = new Person { Name = "Tom", Age = 35 };
            //string json = serializer.Serialize<Person>(tom);
        }

    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
