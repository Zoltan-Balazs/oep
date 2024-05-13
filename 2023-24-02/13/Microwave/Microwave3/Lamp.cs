using StateMachine;

namespace Microwave
{
    class Lamp : StateMachine<Signal>
    {
        public Lamp()
            : base(Signal.none, Signal.final)
        {
            currentState = LightOff.Instance(this);
            Start();
        }

        public override string ToString()
        {
            return "lamp " + (currentState is LightOn ? "is lighting" : "is not lighting");
        }
    }

    abstract class LampState : State<Signal>
    {
        protected Lamp lamp;

        public LampState(Lamp e)
        {
            lamp = e;
        }
    }

    class LightOn : LampState
    {
        private static LightOn instance = null;

        private LightOn(Lamp l)
            : base(l) { }

        public static LightOn Instance(Lamp l)
        {
            instance ??= new LightOn(l);
            return instance;
        }

        public override LampState Transition(Signal signal)
        {
            return signal switch
            {
                Signal.opened => LightOn.Instance(lamp),
                Signal.closed => LightOff.Instance(lamp),
                Signal.stopped => LightOff.Instance(lamp),
                _ => this,
            };
        }
    }

    class LightOff : LampState
    {
        private static LightOff instance = null;

        private LightOff(Lamp l)
            : base(l) { }

        public static LightOff Instance(Lamp l)
        {
            instance ??= new LightOff(l);
            return instance;
        }

        public override LampState Transition(Signal signal)
        {
            return signal switch
            {
                Signal.opened => LightOn.Instance(lamp),
                Signal.started => LightOn.Instance(lamp),
                Signal.closed => LightOff.Instance(lamp),
                Signal.stopped => LightOff.Instance(lamp),
                _ => this,
            };
        }
    }
}
