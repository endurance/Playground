using Practice.Delegates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice.Delegates
{
   public class SimpleDelegates
   {
      // Defined a function that:
      // Accepts 2 integers
      // Returns an integer
      public delegate void BinaryOp(int x, int y);
      // Declaration of a delegate type
      // Private to this class
      private BinaryOp functionHolder;

      public SimpleDelegates()
      {
         functionHolder = new BinaryOp(Operations.Add);
         functionHolder += new BinaryOp(Operations.Subtract);
         functionHolder += new BinaryOp(Operations.Multiply);
         functionHolder += new BinaryOp(Operations.Divide);
      }

      public void ExecuteFunctions(int var1, int var2)
      {
         if (functionHolder != null)
         {
            Console.WriteLine("Executing Functions");
            functionHolder(var1, var2);
         }
      }
   }
   public static class Operations
   {
      public static void Add(int x, int y)
      {
         Console.WriteLine(x + y);
      }
      public static void Subtract(int x, int y)
      {
         Console.WriteLine(x - y);
      }
      public static void Multiply(int x, int y)
      {
         Console.WriteLine(x * y);
      }
      public static void Divide(int x, int y)
      {
         Console.WriteLine(x / y);
      }
   }
   public class TestClass
   {
      static void Main(string[] args)
      {
         int var1 = 7;
         int var2 = 15;
         SimpleDelegates obj = new SimpleDelegates();
         // public api that calls the handler and executes the binary operations
         obj.ExecuteFunctions(var1, var2);
         Console.ReadLine();
      }
   }
}
