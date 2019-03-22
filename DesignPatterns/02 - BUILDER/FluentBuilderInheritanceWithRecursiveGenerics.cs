using System;

namespace DesignPatterns.BUILDER
{

    public class Person
    {
        public string Name { get; set; }

        public string Position { get; set; }

        public class Builder : PersonJobBuilder<Builder>
        {

        }

        public static Builder New => new Builder();


        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}  {nameof(Position)}: {Position}";
        }
    }

    public abstract class PersonBuilder<SELF> where SELF : PersonBuilder<SELF>
    {
        protected Person person = new Person();

        public Person Build()
        {
            return person;
        }
    }

    public class PersonInfoBuilder<SELF> : PersonBuilder<PersonInfoBuilder<SELF>> where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }


    public class PersonJobBuilder<SELF> : PersonInfoBuilder<PersonJobBuilder<SELF>> where SELF : PersonJobBuilder<SELF>
    {
        public SELF WorksAs(string position)
        {
            person.Position = position;
            return (SELF)this;
        }
    }


    public class FluentBuilderInheritanceWithRecursiveGenerics
    {
        public static void Exec()
        {
            var person = Person.New
            .Called("Lino")
            .WorksAs("Developer")
            .Build();

            Console.WriteLine(person);
        }


    }
}
