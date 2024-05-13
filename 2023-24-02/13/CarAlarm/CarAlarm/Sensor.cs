using StateMachine;

namespace CarAlarm
{
    class Sensor : StateMachine<Signal>
    {
        public AlarmSet Alarmset { get; private set; }

        public Sensor()
            : base(Signal.none, Signal.final)
        {
            currentState = Asleep.Instance(this);
            Start();
        }

        public void Connect(AlarmSet alarmset)
        {
            Alarmset = alarmset;
        }

        public void DetectedMoving()
        {
            Send(Signal.motion);
        }

        public override string ToString()
        {
            string msg = "sensor is ";
            if (currentState == Awake.Instance(this))
                msg += "awake";
            else if (currentState == Asleep.Instance(this))
                msg += "asleep";
            return msg;
        }
    }

    abstract class SensorState : State<Signal>
    {
        protected Sensor sensor;

        protected SensorState(Sensor s)
        {
            sensor = s;
        }
    }

    class Asleep : SensorState
    {
        private static Asleep instance = null;

        private Asleep(Sensor s)
            : base(s) { }

        public static Asleep Instance(Sensor s)
        {
            instance ??= new Asleep(s);
            return instance;
        }

        public override SensorState Transition(Signal signal)
        {
            switch (signal)
            {
                case Signal.activate:
                    return Awake.Instance(sensor);
                default:
                    return this;
            }
        }
    }

    class Awake : SensorState
    {
        private static Awake instance = null;

        private Awake(Sensor s)
            : base(s) { }

        public static Awake Instance(Sensor s)
        {
            instance ??= new Awake(s);
            return instance;
        }

        public override SensorState Transition(Signal signal)
        {
            switch (signal)
            {
                case Signal.deactivate:
                    return Asleep.Instance(sensor);
                case Signal.motion:
                    sensor.Alarmset.Send(Signal.motion);
                    return this;
                default:
                    return this;
            }
        }
    }
}
