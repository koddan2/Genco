using Genco.Test.Example;
using Microsoft.Data.Sqlite;

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
                ["Id"] = 1L,
                ["CreatedAt"] = DateTime.Now,
                ["Status"] = Status.Problematic,
            };
            var instance = MySimpleModel.FromDictionary(dict);
            Assert.That(instance, Is.Not.Null);
        }

        [Test]
        public void DbTest1()
        {
            using var conn = new SqliteConnection("Data Source=:memory:");
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText =
                @"create table testing(
                id integer primary key,
                name text,
                createdat text,
                externalreference text,
                status integer
            );";
            cmd.ExecuteNonQuery();
            ////cmd.CommandText =
            ////    @"insert into testing(name, createdat, externalreference, status)
            ////values (@Name, @CreatedAt, @ExternalReference, @Status);";
            cmd.CommandText = MySimpleModel.Sql.GetInsertCommandText("testing", MySimpleModel.Sql.IdentifierCasing.Lower, nameof(MySimpleModel.Id), nameof(MySimpleModel.Description));
            var model0 = new MySimpleModel
            {
                Name = "TestingName",
                CreatedAt = DateTime.Parse("2019-12-19"),
                ExternalReference = Guid.NewGuid(),
                Status = Status.Problematic,
            };
            model0.AddAllParameters(cmd, nameof(MySimpleModel.Id));
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select * from testing;";
            using var reader = cmd.ExecuteReader();
            var counter = 0;
            while (reader.Read())
            {
                counter++;
                var output = MySimpleModel.LoadRecord(reader);
                Assert.Multiple(() =>
                {
                    model0.Id = output.Id;
                    Assert.That(output, Is.Not.Null);
                    Assert.That(output, Is.EqualTo(model0));
                    Assert.That(output.Id, Is.EqualTo(1));
                    Assert.That(output.Name, Is.EqualTo(model0.Name));
                });
            }
            Assert.That(counter, Is.EqualTo(1));
        }
    }
}
