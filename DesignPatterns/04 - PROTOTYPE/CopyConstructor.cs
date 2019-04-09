using System;

namespace DesignPatterns.PROTOTYPE
{

    public class Person
    {
        public string[] Names;
        public Address Address;

        public Person(string[] names, Address address)
        {
            Names = names;
            Address = address;
        }


        public Person(Person other)
        {
            Names = other.Names;
            Address = new Address(other.Address);

        }


        public override string ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ",Names)}, {nameof(Address)}: {Address}";
        }



    }

    public class Address
    {
        public string StreetName;
        public int HouseNumber;

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }

        public Address(Address other)
        {
            StreetName = other.StreetName;
            HouseNumber = other.HouseNumber;
        }

        public override string ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

    }

    public static class CopyConstructor
    {
        public static void Exec()
        {
            var john = new Person(new[] { "John", "Smith" }, new Address("London Road", 123));

            var jane = new Person(john);

            jane.Names = new string[] { "Jane" }; 

            Console.WriteLine(john);
            Console.WriteLine(jane);
        }
    }
}
