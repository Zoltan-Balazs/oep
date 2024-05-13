using System.Threading;

namespace StateMachine
{
    public class State<Signal>
    {
        public virtual State<Signal> Transition(Signal signal)
        {
            return this;
        }
    }

    public abstract class StateMachine<Signal>
    {
        private readonly Thread thread;
        private readonly MyQueue<Signal> eventQueue;
        private readonly Signal finalSignal;

        protected State<Signal> currentState;

        public StateMachine(Signal none, Signal final)
        {
            finalSignal = final;
            eventQueue = new MyQueue<Signal>(none);
            thread = new Thread(new ThreadStart(StateMachineProcess));
        }

        public void Start()
        {
            thread.Start();
        }

        public void Send(Signal signal)
        {
            eventQueue.Enqueue(signal);
        }

        private void StateMachineProcess()
        {
            while (true)
            {
                try
                {
                    Signal signal = eventQueue.Dequeue();
                    if (signal.Equals(finalSignal))
                        break;
                    else
                        currentState = currentState.Transition(signal);
                }
                catch (System.InvalidOperationException) { }
            }
        }
    }
}
