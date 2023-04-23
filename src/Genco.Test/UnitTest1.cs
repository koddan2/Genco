using Genco.Test.Example;

namespace Genco.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void Test1()
        {
            var dict = new Dictionary<string, object?>
            {
                ["Id"] = 1,
                ["CreatedAt"] = DateTime.Now,
                ["Status"] = Status.Problematic,
            };
            var instance = MySimpleModel.FromDictionary(dict);
            Assert.That(instance, Is.Not.Null);
            Assert.Pass();
        }
    }
}
