namespace Microwave
{
    class Lamp : StateMachine.StateMachine<Signal>
    {
        private bool light_is_on;

        public Lamp()
            : base(Signal.none, Signal.final)
        {
            light_is_on = false;
        }

        protected override void Transition(Signal signal)
        {
            switch (signal)
            {
                case Signal.opened:
                case Signal.started:
                    light_is_on = true;
                    break;
                case Signal.closed:
                case Signal.stopped:
                    light_is_on = false;
                    break;
            }
        }

        public override string ToString()
        {
            return "lamp " + (light_is_on ? "is lighting" : "is not lighting");
        }
    }
}
