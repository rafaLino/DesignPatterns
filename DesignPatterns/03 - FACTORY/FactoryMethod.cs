using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.FACTORY
{
    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }

    #region Problem - Public ctor
    //public static class PointFactory //the problem with this is the constructor of Point class is Public!
    //{
    //    public static Point NewCartesianPoint(double x, double y)
    //    {
    //        return new Point(x, y);
    //    }

    //    public static Point NewPolarPoint(double rho, double theta)
    //    {
    //        return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
    //    }

    //}
    #endregion
    public class Point
    {
        private double x, y;

        
        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

        public static Point Origin = new Point(0, 0);
        public static PointFactory Factory => new PointFactory();

        public  class PointFactory 
        {
            public  Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public  Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }

        }


        #region
        //public Point(double a, double b,CoordinateSystem system = CoordinateSystem.Cartesian)
        //{
        //    switch (system)
        //    {
        //        case CoordinateSystem.Cartesian:
        //            x = a;
        //            y = b;
        //            break;
        //        case CoordinateSystem.Polar:
        //            x = a * Math.Cos(b);
        //            y = a * Math.Sin(b);
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException(nameof(system), system, null);
        //    }
        //}
        #endregion
    }
    public static class FactoryMethod
    {
        public static void Exec()
        {
            var cartesianPoint = Point.Factory.NewCartesianPoint(2, 4);

            var polarPoint = Point.Factory.NewPolarPoint(2, Math.PI/2);
            
            Console.WriteLine(cartesianPoint);
            Console.WriteLine(polarPoint);
        }

    }
}
