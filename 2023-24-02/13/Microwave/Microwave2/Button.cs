namespace Microwave
{
    class Button
    {
        private Magnetron magn;

        public void Connect(Magnetron magn)
        {
            this.magn = magn;
        }

        public void Press()
        {
            magn.Send(Signal.pressed);
        }
    }
}
