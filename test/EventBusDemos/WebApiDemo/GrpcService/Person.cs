using MessagePack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.GrpcService
{
    [MessagePackObject(true)]
    public class Person
    {
        public int Id { get; set; }
        public virtual string PersonName { get; set; }

        public Person()
        {

        }

        public Person(string personName)
        {
            PersonName = personName;
        }
    }
}
