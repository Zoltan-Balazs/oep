using StateMachine;

namespace CarAlarm
{
    class AlarmSet : StateMachine.StateMachine<Signal>
    {
        public Door[] Doors { get; private set; }
        public Sensor Sensor { get; private set; }
        public AlarmSet() : base(Signal.none, Signal.final) 
        {
            currentState = Passive.Instance(this);
            Start();
        }

        public void Connect(Sensor sensor, Door[] doors) 
        {
            Doors = doors;
            Sensor = sensor;
        }
        
        public bool AllDoorsClosed()
        {
         
   {
                if (d.CurrentState == Door.DoorState.opened) return false;
            }
            return true;
        }

        public override string ToString()
        {
            string msg = "alarmset is ";
            if (currentState == Passive.Instance(this)) msg += "passive,";
            else if (currentState == Active.Instance(this)) msg += "active,";
            else if (currentState == Alert.Instance(this)) msg += "alert,";
            return msg;
        }
    }

    abstract class AlarmState : State<Signal>
    {
        protected AlarmSet alarmset;
        protected AlarmState(AlarmSet e) { alarmset = e; }
    }

    class Passive : AlarmState
    {
        private static Passive instance = null;
        private Passive(AlarmSet s) : base(s) { }

        public static Passive Instance(AlarmSet s)
        {
            instance ??= new Passive(s);
            return instance;
        }

        public override AlarmState Transition(Signal signal)
        {
            switch (signal)
            {
                case Signal.on:
                    if (alarmset.AllDoorsClosed())
                    {
                        alarmset.Sensor.Send(Signal.activate);
                        return Active.Instance(alarmset);
                    }
                    return this;
                default: return this;
            }
        }
    }

    class Active : AlarmState
    {
        private static Active instance = null;
        private Active(AlarmSet s) : base(s) { }

        public static Active Instance(AlarmSet s)
        {
            instance ??= new Active(s);
            return instance;
        }

        public override AlarmState Transition(Signal signal)
        {
            switch (signal)
            {
                case Signal.off:
                    alarmset.Sensor.Send(Signal.deactivate); 
                    return Passive.Instance(alarmset);
                case Signal.opened:
                case Signal.motion:
                    return Alert.Instance(alarmset);
                default: return this;
            }
        }
    }

    class Alert : AlarmState
    {
        private static Alert instance = null;
        private Alert(AlarmSet s) : base(s) { }

        public static Alert Instance(AlarmSet s)
        {
            instance ??= new Alert(s);
            return instance;
        }

        public override AlarmState Transition(Signal signal)
        {
            switch (signal)
            {
                case Signal.off:
                    alarmset.Sensor.Send(Signal.deactivate);
                    return Passive.Instance(alarmset);
                default:
                    // Console.WriteLine("beep-beep"); // hangjelzés
                    return this; 
            }   
        }
    }
}
            }
