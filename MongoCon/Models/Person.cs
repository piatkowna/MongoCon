using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MongoCon.Models
{
    public class Person
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        public Person()
        { }

        public Person(PostPerson postPerson)
        {
            this.Name = postPerson.Name;
            this.Age = postPerson.Age;
        }


    }
}