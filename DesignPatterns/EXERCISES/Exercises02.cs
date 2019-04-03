using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.EXERCISES
{

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Person(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(Name)}: {Name}";
        }
    }

    public class PersonFactory
    {
        private int amount = 0;

        public Person CreatePerson(string name)
        {
            return new Person(amount++, name);
        }
    }




    public static class Exercises02
    {
        public static void Exec()
        {
            var factory = new PersonFactory();
            var john = factory.CreatePerson("Jhon");
            var mike = factory.CreatePerson("Mike");

            Console.WriteLine(john);
            Console.WriteLine(mike);

        }
    }


    #region Instructor Answer
    namespace Coding.Exercise
    {
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class PersonFactory
        {
            private int id = 0;

            public Person CreatePerson(string name)
            {
                return new Person { Id = id++, Name = name };
            }
        }
    }
    #endregion
}
