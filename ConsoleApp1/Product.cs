using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApp1
{
    public class Product
    {
        public string Name { get; set; }
        public int Stock { get; set; }
    }


    public class TestExpression
    {
        public void CreateExpression(Product product)
        {
            //p => p.Stock < 10
            ParameterExpression productParam = Expression.Parameter(typeof(Product), "p");
            MemberExpression stockProperty = Expression.Property(productParam, "Stock");
            ConstantExpression threshold = Expression.Constant(10);
            BinaryExpression comparison = Expression.GreaterThan(stockProperty, threshold);

        }
    }

}
