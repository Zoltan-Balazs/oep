using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Fisher_Contest
{
    public class Fisher
    {
        public string name { get; }
        private List<Catch> catches;

        public Fisher(string name)
        {
            this.name = name;
            this.catches = new List<Catch>();
        }

        public class AlreadyCaughtException : Exception { }

        public void Catch(DateTime time, Fish fish, double weight, Contest contest)
        {
            bool l = false;
            /*
            for (int i = 0; i < catches.Count && !l; ++i)
            {
                Catch c = catches[i];
                l = c.time.Equals(time) && c.fisher == this;
            }
            */
            foreach (Catch c in catches)
            {
                l = c.time.Equals(time) && c.fisher == this;
                if (l)
                {
                    break;
                }
            }

            if (l)
            {
                throw new AlreadyCaughtException();
            }

            catches.Add(new Catch(time, fish, weight, this, contest));
        }

        public double TotalValue(Contest contest)
        {
            double sum = 0.0;
            foreach (Catch c in catches)
            {
                if (c.contest == contest)
                {
                    sum += c.Value();
                }
            }

            return sum;
        }

        public bool CaughtCatfish(Contest contest)
        {
            foreach (Catch c in catches)
            {
                if (c.contest == contest && c.fish is Catfish)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
