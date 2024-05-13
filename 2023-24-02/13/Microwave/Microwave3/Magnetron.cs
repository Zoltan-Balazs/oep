using StateMachine;

namespace Microwave
{
    class Magnetron : StateMachine<Signal>
    {
        public Door Door { get; private set; }
        public Lamp Lamp { get; private set; }

        public Magnetron()
            : base(Signal.none, Signal.final) { }

        public void Connect(Lamp lamp, Door door)
        {
            this.Lamp = lamp;
            this.Door = door;
        }

        public override string ToString()
        {
            return "magnetron "
                + ((currentState == WorkOn.Instance(this)) ? "is working" : "is not working");
        }
    }

    abstract class MagnetronState : State<Signal>
    {
        protected Magnetron magnetron;

        protected MagnetronState(Magnetron m)
        {
            magnetron = m;
        }
    }

    class WorkOn : MagnetronState
    {
        private static WorkOn instance = null;

        private WorkOn(Magnetron m)
            : base(m) { }

        public static WorkOn Instance(Magnetron m)
        {
            instance ??= new WorkOn(m);
            return instance;
        }

        public override MagnetronState Transition(Signal signal)
        {
            switch (signal)
            {
                case Signal.pressed:
                    magnetron.Lamp.Send(Signal.stopped);
                    return WorkOff.Instance(magnetron);
                case Signal.opened:
                    magnetron.Lamp.Send(Signal.opened);
                    return WorkOff.Instance(magnetron);
                default:
                    return this;
            }
        }
    }

    class WorkOff : MagnetronState
    {
        private static WorkOff instance = null;

        private WorkOff(Magnetron m)
            : base(m) { }

        public static WorkOff Instance(Magnetron m)
        {
            instance ??= new WorkOff(m);
            return instance;
        }

        public override MagnetronState Transition(Signal signal)
        {
            switch (signal)
            {
                case Signal.pressed:
                    if (magnetron.Door.Closed)
                    {
                        magnetron.Lamp.Send(Signal.started);
                        return WorkOn.Instance(magnetron);
                    }
                    return this;
                case Signal.opened:
                    magnetron.Lamp.Send(Signal.opened);
                    return this;
                default:
                    return this;
            }
        }
    }
}
