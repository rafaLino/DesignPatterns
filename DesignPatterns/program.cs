using DesignPatterns.BUILDER;
using DesignPatterns.EXERCISES;
using DesignPatterns.SOLID;

namespace DesignPatterns
{
    class Program
    {

        static void Main(string[] args)
        {
            //Solid();

            Builder();

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
            //HTMLBuilderDemo.Exec();
            //FluentBuilderInheritanceWithRecursiveGenerics.Exec();
            FacetedBuilder.exec();
        }

        public static void Exercises()
        {
            Exercises01.Exec();
        }
    }
}
