using System;

namespace Fisher_Contest
{
    public class Catch
    {
        private double weight;
        public DateTime time { get; }
        public Fish fish { get; }
        public Contest contest { get; }
        public Fisher fisher { get; }

        public Catch(DateTime time, Fish fish, double weight, Fisher fisher, Contest contest)
        {
            this.time = time;
            this.fish = fish;
            this.weight = weight;
            this.fisher = fisher;
            this.contest = contest;
        }

        public double Value()
        {
            return weight * fish.Multiplier();
        }
    }
}
