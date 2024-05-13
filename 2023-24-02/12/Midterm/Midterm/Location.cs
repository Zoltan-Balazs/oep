using System.Collections.Generic;

namespace Midterm
{
    public class Location
    {
        public string room;
        public int max;
        public List<Student> attendees;

        public Location(string room, int max)
        {
            this.room = room;
            this.max = max;
            this.attendees = new List<Student>();
        }
    }
}