namespace CarAlarm
{
    class Door
    {
        public enum DoorState
        {
            closed,
            opened
        };

        public DoorState CurrentState { get; private set; }
        private AlarmSet alarmset;

        public Door()
        {
            CurrentState = DoorState.closed;
        }

        public void Connect(AlarmSet alarmset)
        {
            this.alarmset = alarmset;
        }

        public void Open()
        {
            if (CurrentState == DoorState.closed)
            {
                alarmset.Send(Signal.opened);
                CurrentState = DoorState.opened;
            }
        }

        public void Close()
        {
            CurrentState = DoorState.closed;
        }
    }
}
