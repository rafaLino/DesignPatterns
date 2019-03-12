using DesignPatterns.BUILDER;
using DesignPatterns.SOLID;

namespace DesignPatterns
{
    class Program
    {

        static void Main(string[] args)
        {
            //Solid();
            Builder();
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
            FluentBuilderInheritanceWithRecursiveGenerics.Exec();
        }
    }
}
