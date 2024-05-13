namespace Microwave
{
    class Door
    {
        public bool Closed { get; private set; }
        private Magnetron magn;
        private Lamp lamp;

        public Door()
        {
            Closed = true;
        }

        public void Connect(Magnetron magn, Lamp lamp)
        {
            this.magn = magn;
            this.lamp = lamp;
        }

        public void Open()
        {
            lamp.Send(Signal.opened);
            magn.Send(Signal.opened);
            Closed = false;
        }

        public void Close()
        {
            lamp.Send(Signal.closed);
            Closed = true;
        }

        public override string ToString()
        {
            return "door " + (Closed ? "is closed" : "is open");
        }
    }
}
