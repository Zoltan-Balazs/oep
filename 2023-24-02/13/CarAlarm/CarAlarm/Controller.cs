namespace CarAlarm
{
    class Controller
    {
        private AlarmSet alarmSet;

        public void Connect(AlarmSet alarmSet)
        {
            this.alarmSet = alarmSet;
        }

        public void TurnOn()
        {
            alarmSet.Send(Signal.on);
        }

        public void TurnOff()
        {
            alarmSet.Send(Signal.off);
        }
    }
}
