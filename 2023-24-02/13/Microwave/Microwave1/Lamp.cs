namespace Microwave
{
    class Lamp
    {
        private bool light_is_on;

        public Lamp()
        {
            light_is_on = false;
        }

        public void Send(Signal signal)
        {
            switch (signal)
            {
                case Signal.opened:
                case Signal.started:
                    light_is_on = true;
                    ;
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
