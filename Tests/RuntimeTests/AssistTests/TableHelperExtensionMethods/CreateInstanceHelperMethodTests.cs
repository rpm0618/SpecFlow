﻿using NUnit.Framework;
using Should;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.RuntimeTests.AssistTests.ExampleEntities;

namespace TechTalk.SpecFlow.RuntimeTests.AssistTests.TableHelperExtensionMethods
{
    [TestFixture]
    public class CreateInstanceHelperMethodTests : CreateInstanceHelperMethodTestBase
    {
        public CreateInstanceHelperMethodTests()
            : base(t => t.CreateInstance<Person>())
        {
        }

        [Test]
        public virtual void Create_instance_will_return_an_instance_of_T()
        {
            var table = new Table("Field", "Value");
            var person = GetThePerson(table);
            person.ShouldNotBeNull();
        }

        [Test]
        public void CreateInstance_returns_the_object_returned_from_the_func()
        {
            var table = new Table("Field", "Value");
            var expectedPerson = new Person();
            var person = table.CreateInstance(() => expectedPerson);
            person.ShouldBeSameAs(expectedPerson);
        }

        [Test]
        public void Create_instance_will_fill_the_instance_()
        {
            var table = new Table("Field", "Value");
            table.AddRow("FirstName", "John");
            table.AddRow("LastName", "Galt");

            var expectedPerson = new Person {FirstName = "Ellsworth", LastName = "Toohey"};
            var person = table.CreateInstance(() => expectedPerson);

            person.FirstName.ShouldEqual("John");
            person.LastName.ShouldEqual("Galt");
        }
    }
}