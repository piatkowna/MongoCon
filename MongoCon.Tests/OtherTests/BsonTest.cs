using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace MongoCon.Tests.OtherTests
{
    public class BsonTest
    {
        ITestOutputHelper _outputHelper;

        public BsonTest(ITestOutputHelper helper)
        {
            _outputHelper = helper;
        }

        [Fact]
        public void AddingArrays()
        {
            var person = new BsonDocument();
            person.Add("adress",
                new BsonArray(new[] { "traalala", "hohoho" }));

            _outputHelper.WriteLine(person.ToJson());
        }
    }
}
