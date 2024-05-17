using Genco.Test.Example;
using System.Xml.Linq;

namespace Genco.Test
{
    public class TestBaselineStuff
    {
        [Test]
        public void TestProps()
        {
            var model1 = new Test1Model { IntVal = 1, StrVal = "name", };

            var prop = Test1ModelMeta.GetProperty(Test1ModelProperty.IntVal);
            Assert.That(prop, Is.EqualTo(Test1ModelMeta.Property_IntVal));

            prop.SetValue(model1, 2);
            Assert.That(model1.IntVal, Is.EqualTo(2));
        }

        [Test]
        public void Test2Dto()
        {
            Test2Model model2 = GetTest2Model();
            var dto = model2.ToDto();
            Assert.That(dto.Id, Is.EqualTo(model2.Id));
            var model2back = dto.ToModel();
            Assert.That(model2back, Is.EqualTo(model2));
        }

        [Test]
        public void Test2Dict()
        {
            Test2Model model2 = GetTest2Model();
            var dict = model2.ToDictionary();
            var model2back = Test2Model.FromDictionary(dict);
            Assert.That(model2back, Is.EqualTo(model2));
        }

        [Test]
        public void Test2Enumerate()
        {
            Test2Model model2 = GetTest2Model();
            var result = model2.Enumerate();
            Assert.That(result.First().Property, Is.EqualTo(Test2ModelProperty.Id));
        }

        private static Test2Model GetTest2Model()
        {
            return new Test2Model
            {
                Id = Random.Shared.NextInt64(),
                Name = $"name-{Random.Shared.NextInt64()}",
                ComplexObj = new() { IntVal = 2, StrVal = "t" },
            };
        }
    }
}
