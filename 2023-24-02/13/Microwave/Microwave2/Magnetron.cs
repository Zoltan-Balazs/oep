namespace Microwave
{
    class Magnetron : StateMachine.StateMachine<Signal>
    {
        private Door door;
        private Lamp lamp;
        private bool working;

        public Magnetron()
            : base(Signal.none, Signal.final)
        {
            working = false;
        }

        public void Connect(Lamp lamp, Door door)
        {
            this.lamp = lamp;
            this.door = door;
        }

        protected override void Transition(Signal signal)
        {
            switch (signal)
            {
                case Signal.pressed:
                    if (!working && door.Closed)
                    {
                        lamp.Send(Signal.started);
                        working = true;
                    }
                    else if (working)
                    {
                        lamp.Send(Signal.stopped);
                        working = false;
                    }
                    break;
                case Signal.opened:
                    if (working)
                    {
                        working = false;
                    }
                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            return "magnetron " + (working ? "is working" : "is not working");
        }
    }
}
