namespace Microwave
{
    enum Signal
    {
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

        public override string ToString()
        {
            return string.Format($"{magnetron, -24}, {lamp, -20}, {door, -25}");
        }
    }
}
