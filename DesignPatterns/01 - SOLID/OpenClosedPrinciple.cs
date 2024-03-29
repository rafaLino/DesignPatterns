﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.SOLID
{
   public class OpenClosedPrinciple
    {

        public enum Color
        {
            Red, Green, Blue
        }

        public enum Size
        {
            Small, Medium, Large, Yuge
        }

        public class Product
        {
            public Product(string name, Color color, Size size)
            {
                Name = name;
                Color = color;
                Size = size;
            }

            public string Name { get; set; }

            public Color Color { get; set; }

            public Size Size { get; set; }

            
        }


        public class ProductFilter
        {
            #region VIOLATION
            public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
            {
                foreach (var p in products)
                {
                    if (p.Size == size)
                        yield return p;

                }
            }
            public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
            {
                foreach (var p in products)
                {
                    if (p.Color == color)
                        yield return p;

                }
            }

            public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products,Size size, Color color)
            {
                foreach (var p in products)
                {
                    if (p.Color == color && p.Size == size)
                        yield return p;

                }
            }
            #endregion



        }

        public interface ISpecification<T>
        {
            bool isSatisfied(T t);
        }

        public interface IFilter<T>
        {
            IEnumerable<T> Filter(IEnumerable<T> itens, ISpecification<T> spec);
        }

        public class ColorSpecification : ISpecification<Product>
        {
            private Color color;

            public ColorSpecification(Color color)
            {
                this.color = color;
            }

            public bool isSatisfied(Product t)
            {
                return t.Color == color;
            }
        }

        public class SizeSpecification : ISpecification<Product>
        {
            private Size size;

            public SizeSpecification(Size size)
            {
                this.size = size;
            }

            public bool isSatisfied(Product t)
            {
                return t.Size == size;
            }
        }

        public class AndSpecification<T> : ISpecification<T>
        {
            private ISpecification<T> first, second;

            public AndSpecification(ISpecification<T> first, ISpecification<T> second)
            {
                this.first = first;
                this.second = second;
            }

            public bool isSatisfied(T t)
            {
                return first.isSatisfied(t) && second.isSatisfied(t);
            }
        }

        public class BetterFilter : IFilter<Product>
        {
            public IEnumerable<Product> Filter(IEnumerable<Product> itens, ISpecification<Product> spec)
            {
                foreach (var i in itens)
                {
                    if (spec.isSatisfied(i))
                        yield return i;
                }
            }
        }


        public static void Exec()
        {
            var apple = new Product("Apple", Color.Green, Size.Small);
            var tree = new Product("Tree", Color.Green, Size.Large);
            var house = new Product("House", Color.Blue, Size.Large);


            Product[] products = { apple, tree, house };

            var pf = new ProductFilter();
            Console.WriteLine("Green products (old):");

            foreach (var p in pf.FilterByColor(products,Color.Green))
            {
                Console.WriteLine($" - {p.Name} is green");
            }

            var bf = new BetterFilter();

            Console.WriteLine("Green products (new):");
            foreach (var p in bf.Filter(products, new ColorSpecification(Color.Green)))
            {
                Console.WriteLine($" - {p.Name} is green");
            }


            Console.WriteLine("Large blue Itens:");
            foreach (var p in bf.Filter(products,new AndSpecification<Product>(new ColorSpecification(Color.Blue),new SizeSpecification(Size.Large))))
            {
                Console.WriteLine($" - {p.Name} is blue and Large");
        }
        }
    }
}
