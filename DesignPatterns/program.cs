using DesignPatterns.FACTORY;
using DesignPatterns.BUILDER;
using DesignPatterns.EXERCISES;
using DesignPatterns.SOLID;
using DesignPatterns.PROTOTYPE;

namespace DesignPatterns
{
    class Program
    {

        static void Main(string[] args)
        {
            //Solid();

            //Builder();

            //Factory();

            Prototype();

            //Exercises();
        }


        public static void Solid()
        {
            SingleResponsibilityPrinciple.Exec();

            OpenClosedPrinciple.Exec();

            LiskovSubstituitionPrinciple.Exec();

            InterfaceSegregationPrinciple.Exec();

            DependencyInversionPrinciple.Exec();

        }

        public static void Builder()
        {
            HTMLBuilderDemo.Exec();
            FluentBuilderInheritanceWithRecursiveGenerics.Exec();
            FacetedBuilder.exec();
        }

        public static void Factory()
        {
            FactoryMethod.Exec();
            AbstractFactory.Exec();
        }

        public static void Prototype()
        {
            CopyConstructor.Exec();
        }

        public static void Exercises()
        {
            Exercises01.Exec();
            Exercises02.Exec();
        }
    }
}
