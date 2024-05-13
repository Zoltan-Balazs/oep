using System;

namespace CarAlarm
{
    public enum Signal
    {
        none,
        final,
        on,
        off,
        activate,
        deactivate,
        motion,
        opened
    }

    public class UnknownSignalException : Exception { }

    class System
    {
        public readonly Controller controller = new();
        public Door[] doors;
        private readonly AlarmSet alarmset = new();
        private readonly Sensor sensor = new();

        public System(int n)
        {
            doors = new Door[n];
            for (int i = 0; i < n; ++i)
            {
                doors[i] = new Door();
                doors[i].Connect(alarmset);
            }
            controller.Connect(alarmset);
            sensor.Connect(alarmset);
            alarmset.Connect(sensor, doors);
        }

        public void DetectedMoving()
        {
            sensor.DetectedMoving();
        }

        public void Stop()
        {
            alarmset.Send(Signal.final);
            sensor.Send(Signal.final);
        }

        public override string ToString()
        {
            string doorstate = alarmset.AllDoorsClosed()
                ? "doors are closed,"
                : "at least one door is open,";
            return string.Format($"{doorstate, -27} {alarmset, -21} {sensor, -20}");
        }
    }
}
