using System;
using System.Collections.Generic;

namespace Fisher_Contest
{
    public class Organization
    {
        public List<Fisher> members;
        public List<Contest> contests;

        public Organization()
        {
            this.members = new List<Fisher>();
            this.contests = new List<Contest>();
        }

        public class DoubleJoinException : Exception { }

        public void Join(Fisher fisher)
        {
            if (members.Contains(fisher))
            {
                throw new DoubleJoinException();
            }
            members.Add(fisher);
        }

        public class ExistingContestException : Exception { }

        public Contest Organize(string place, DateTime start)
        {
            bool l = false;
            foreach (Contest c in contests)
            {
                l = (c.place == place) && (c.start.Equals(start));
                if (l)
                {
                    throw new ExistingContestException();
                }
            }

            Contest contest = new Contest(this, place, start);
            contests.Add(contest);
            return contest;
        }

        public bool BestContest(out Contest contest)
        {
            bool l = false;
            contest = null;
            double max = 0.0;

            foreach (Contest c in contests)
            {
                if (!c.AllCaughtCatfish())
                {
                    continue;
                }

                double total = c.TotalValue();
                if (l)
                {
                    if (max < total)
                    {
                        contest = c;
                        max = total;
                    }
                }
                else
                {
                    l = true;
                    contest = c;
                    max = total;
                }
            }

            return l;
        }

        public bool IsMember(Fisher fisher)
        {
            return members.Contains(fisher);
        }

        public Fisher Search(string name)
        {
            foreach (Fisher fisher in members)
            {
                if (fisher.name == name)
                {
                    return fisher;
                }
            }

            return null;
        }
    }
}
