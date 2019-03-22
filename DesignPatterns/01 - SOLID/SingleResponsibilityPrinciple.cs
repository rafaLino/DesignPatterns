using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DesignPatterns.SOLID
{


    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count;
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        #region VIOLATION

        public void Save(string fileName)
        {
            File.WriteAllText(fileName, ToString());
        }

        public static Journal Load(string fileName)
        {
            Journal j = new Journal();
            j.AddEntry(File.ReadAllText(fileName));

            return j;
        }
        #endregion


    }


    public class Persistence
    {
        public void SaveToFile(Journal j, string fileName,bool overwrite = false)
        {
            if(overwrite || !File.Exists(fileName))
            {
                File.WriteAllText(fileName, j.ToString());
            }
        }
    }



    public class SingleResponsibilityPrinciple
    {

        public static void Exec()
        {
            var j = new Journal();
            j.AddEntry("I Cried Today");
            j.AddEntry("I Ate a bug");

            Console.WriteLine(j);


            var p = new Persistence();
            var fileName = @"D:\workspace\DesignPatterns\journal.txt";

            p.SaveToFile(j, fileName, true);

            Process.Start(fileName);
        }
    }
}
