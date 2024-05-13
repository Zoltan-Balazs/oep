using System;
using System.Threading;

namespace CarAlarm
{
    class Program
    {
        static void Main()
        {
            System system = new(3);
            Thread.Sleep(500);
            Console.WriteLine("vehicle is parked on: {0}", system);

            system.controller.TurnOn();
            Thread.Sleep(500);
            Console.WriteLine("alarmset is turn on:  {0}", system);
            system.doors[0].Open();
            Thread.Sleep(500);
            Console.WriteLine("door is open:         {0}", system);
            system.controller.TurnOff();
            Thread.Sleep(500);
            Console.WriteLine("alarmset is turn off: {0}", system);
            system.doors[0].Close();
            Thread.Sleep(500);
            Console.WriteLine("door is closed:       {0}", system);
            system.controller.TurnOn();
            Thread.Sleep(500);
            Console.WriteLine("alarmset is turn on:  {0}", system);
            system.DetectedMoving();
            Thread.Sleep(500);
            Console.WriteLine("somebody is moving:   {0}", system);

            system.Stop();
        }
    }
}
