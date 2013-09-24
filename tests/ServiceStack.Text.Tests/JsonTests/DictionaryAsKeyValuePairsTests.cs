using System.Collections.Generic;
using NUnit.Framework;

namespace ServiceStack.Text.Tests.JsonTests
{
    [TestFixture]
    public class DictionaryAsKeyValuePairsTests : TestBase
    {
        [SetUp]
        public void SetUp()
        {
            JsConfig.Reset();
            JsConfig.DictionaryAsKeyValuePairs = true;
        }

        [TearDown]
        public void TearDown()
        {
            JsConfig.Reset();
        }

        [Test]
        public void Can_serialize()
        {
            var dict = new Dictionary<string, string>();
            dict.Add("k 1", "v 1");
            dict.Add("k 2", "v 2");

            var json = dict.ToJson();
            Assert.That(json, Is.EqualTo("[{\"Key\":\"k 1\",\"Value\":\"v 1\"},{\"Key\":\"k 2\",\"Value\":\"v 2\"}]"));
            JsonSerializeAndCompare(dict);
        }

        [Test]
        public void Can_deserialize()
        {
            var json = "[{\"Key\":\"k 1\",\"Value\":\"v 1\"},{\"Key\":\"k 2\",\"Value\":\"v 2\"}]";
            var res = json.FromJson<Dictionary<string, string>>();

            var dict = new Dictionary<string, string>();
            dict.Add("k 1", "v 1");
            dict.Add("k 2", "v 2");

            Assert.That(dict, Is.EqualTo(res));
        }
    }
}
