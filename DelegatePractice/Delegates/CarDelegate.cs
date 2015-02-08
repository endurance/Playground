using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// Sending Object State Notifications using Delegates
/// Clearly, the previous SimpleDelegate example was intended to be purely illustrative in nature, given that
/// there would be no compelling reason to define a delegate simply to add two numbers! To provide a more
/// realistic use of delegate types, let’s use delegates to define a Car class that has the ability to inform
/// external entities about its current engine state. To do so, we will take the following steps: 
/// • Define a new delegate type that will send notifications to the caller.
/// • Declare a member variable of this delegate in the Car class.
/// • Create a helper function on the Car that allows the caller to specify the method to
/// call back to.
/// • Implement the Accelerate() method to invoke the delegate’s invocation list
/// under the correct circumstances

namespace Practice.Delegates
{
   public class Car
   {
      public delegate void CarEngineHandler(string msgForCaller);
      private CarEngineHandler handlers;
      public int CurrentSpeed { get; set; }
      public int MaxSpeed { get; set; }
      public string PetName { get; set; }

      private bool carIsDead;

      public Car()
      {
         MaxSpeed = 100;
      }
      public Car(string name, int maxSp, int currSp)
      {
         CurrentSpeed = currSp;
         MaxSpeed = maxSp;
         PetName = name;
      }

      public void RegisterWithCarEngine(CarEngineHandler method)
      {
         handlers = method;
      }

      public void Accelerate(int delta)
      {
         if (carIsDead)
         {
            if (handlers != null)
               handlers("Car has exploded.");
         }
         else
         {
            CurrentSpeed += delta;
            if (10 == (MaxSpeed - CurrentSpeed)
               && handlers != null)
            {
               handlers("Gonna Blow!");
            }
         }

         if (CurrentSpeed >= MaxSpeed)
            carIsDead = true;
         else
            Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
      }
   }

   public class CarTester
   {
      static void Main(string[] args)
      {
         // make car
         Car car = new Car("Car1", 100, 10);
         //Hook up method to be called when Car wants to send messages
         car.RegisterWithCarEngine(new Car.CarEngineHandler(OnCarEngineEvent));

         Console.WriteLine(" Speeding Up!! ");
         for (int i = 0; i < 6; i++)
         {
            car.Accelerate(20);
         }
         Console.ReadLine();
      }
      public static void OnCarEngineEvent(string msg)
      {
         Console.WriteLine("Incoming Message from Car");
         Console.WriteLine("=> {0}", msg);
         Console.WriteLine("***************************\n");
      }   
   }

}
