using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using static Fisher_Contest.Organization;

namespace Fisher_Contest
{
    public class Catching
    {
        public DateTime Time { get; }

        private readonly double weight;
        public Fish Fish { get; }
        public Contest Contest { get; }
        private readonly Fisher fisher;

        public Catching(DateTime time, Fish fish, double weight, Fisher fisher, Contest contest) 
        {
            this.Time = time;  Fish = fish; this.weight = weight; this.fisher = fisher; Contest = contest; 
        }

        public double Value() { return weight * Fish.Point(); }
    }
}
