using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.SOLID
{

    public class Rectangle
    {
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Rectangle()
        {

        }

        public virtual int Width { get; set; }
        public virtual int Height { get; set; }


        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}: {Height}";
        }
    }

    public class Square : Rectangle
    {
        #region VIOLATION
        /*  
         *  public new int Width
          {
              set { base.Width = base.Height = value; }
          }

          public new int Height
          {
              set { base.Width = base.Height = value; }
          }
          */
        #endregion

        public override int Width
        {
            set { base.Width = base.Height = value; }
        }

        public override int Height
        {
            set { base.Width = base.Height = value; }
        }

    }
    public class LiskovSubstituitionPrinciple
    {

        private static int Area(Rectangle r) => r.Width * r.Height;
        public static void Exec()
        {
            
            Rectangle rc = new Rectangle(2,3);
            Console.WriteLine($"{rc} has Area { Area(rc)}");

            Rectangle sq = new Square();

            sq.Width = 4;

            Console.WriteLine($"{sq} has Area { Area(sq)}");
        }
    }
}
