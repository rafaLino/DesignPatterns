using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.SOLID
{

    public class Document
    {

    }

    #region VIOLATION
    public interface IMachine
    {
        void Print(Document document);
        void Scan(Document document);

        void Fax(Document document);

    }

    public class MultiFunctionPrinter : IMachine
    {
        public void Fax(Document document)
        {
            Console.WriteLine("It Can Fax");
        }

        public void Print(Document document)
        {
            Console.WriteLine("It Can Print");
        }

        public void Scan(Document document)
        {
            Console.WriteLine("It Can Scan");
        }
    }

    public class OldFasshionedPrinter : IMachine
    {
        public void Fax(Document document)
        {
            throw new NotImplementedException();
        }

        public void Print(Document document)
        {
            Console.WriteLine("It Can Print");
        }

        public void Scan(Document document)
        {
            throw new NotImplementedException();
        }
    }

    #endregion


    public interface IPrinter
    {
        void Print(Document document);
    }

    public interface IScanner
    {
        void Scan(Document document);
    }

    public class Photocopier : IPrinter, IScanner
    {
        public void Print(Document document)
        {
            Console.WriteLine("It Can Print");
        }

        public void Scan(Document document)
        {
            Console.WriteLine("It Can Scan");
        }
    }

    public interface IMultiFunctionDevice : IPrinter, IScanner
    {

    }

    public class MultiFunctionMachine : IMultiFunctionDevice
    {
        private IPrinter printer;
        private IScanner scanner;

        public MultiFunctionMachine(IPrinter printer, IScanner scanner)
        {
            this.printer = printer;
            this.scanner = scanner;
        }

        public void Print(Document document)
        {
            printer.Print(document);
        }

        public void Scan(Document document)
        {
            scanner.Scan(document);
        }//decorator
    }

    public class InterfaceSegregationPrinciple
    {
        public static void Exec()
        {
            Console.WriteLine("Nothing for execute. Check the class");
        }
    }
}
