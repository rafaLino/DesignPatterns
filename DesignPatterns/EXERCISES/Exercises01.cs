using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.EXERCISES
{

    public class CodeBuilder
    {
        private readonly StringBuilder sb;

        public CodeBuilder(string className)
        {
            sb = new StringBuilder();
            sb.AppendLine($"public class {className}").AppendLine("{");
        }

        public CodeBuilder AddField(string field, string type)
        {
            sb.AppendLine($"  public {type} {field};");
            

            return this;
        }


        public override string ToString()
        {
            sb.Append("}");
            return sb.ToString();
        }
    }


   public static class Exercises01
    {
       public static void Exec()
        {
            var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");
            Console.WriteLine(cb);
        }
        
    }
}
