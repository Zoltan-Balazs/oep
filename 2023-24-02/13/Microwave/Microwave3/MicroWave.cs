namespace Microwave
{
    enum Signal
    {
        none,
        final,
        started,
        stopped,
        pressed,
        opened,
        closed
    };

    class MicroWave
    {
        public readonly Button button = new();
        public readonly Door door = new();
        private readonly Magnetron magnetron = new();
        private readonly Lamp lamp = new();

        public MicroWave()
        {
            button.Connect(magnetron);
            door.Connect(magnetron, lamp);
            magnetron.Connect(lamp, door);
        }

        public void Stop()
        {
            lamp.Send(Signal.final);
            magnetron.Send(Signal.final);
        }

        public override string ToString()
        {
            return string.Format($"{magnetron, -24}, {lamp, -20}, {door, -25}");
        }
    }
}
