namespace Midterm
{
    public class Exam
    {
        public string date;
        public List<Location> locations;
        public Course course;

        public Exam(Course course, string date)
        {
            this.date = date;
            this.locations = new List<Location>();
            this.course = course;
        }
        
        public class LocationAlreadyRegisteredException : Exception { }

        public void RegisterLocation(Location location)
        {
            foreach (Location l in locations)
            {
                if (l.room == location.room)
                {
                    throw new LocationAlreadyRegisteredException();
                }
            }
            
            /*
            if (locations.Contains(location))
            {
                throw new LocationAlreadyRegisteredException();
            }
            */

            locations.Add(location);
        }
        
        public class StudentDidNotRegisterToCourseException : Exception { }
        public class NoExamRegisteredToGivenLocationThatStudentWantsToRegisterToException : Exception { }
        
        public class SARTEE : Exception { }

        public void RegisterStudentToExam(Student student, Location location)
        {
            bool l = false;
            foreach (Student s in course.attendees)
            {
                if (s.Equals(student))
                {
                    l = true;
                    break;
                }
            }
            if (!l)
            {
                throw new StudentDidNotRegisterToCourseException();
            }

            l = false;
            foreach (Location loc in locations)
            {
                if (loc.Equals(location))
                {
                    l = true;
                    break;
                }
            }
            if (!l)
            {
                throw new NoExamRegisteredToGivenLocationThatStudentWantsToRegisterToException();
            }

            l = false;
            foreach (Student s in location.attendees)
            {
                if (s.Equals(student))
                {
                    l = true;
                }
            }
            if (l)
            {
                throw new SARTEE();
            }
            
            location.attendees.Add(student);
        }

        public int NumberOfAttendees()
        {
            int sum = 0;
            foreach (Location location in locations)
            {
                sum += location.attendees.Count;
            }

            return sum;
        }

        public Location MostLikedLocation()
        {
            int max = 0;
            Location location = null;
            foreach (Location l in locations)
            {
                if (max < l.attendees.Count)
                {
                    max = l.attendees.Count;
                    location = l;
                }
            }

            return location!;
        }

        public virtual bool IsNormal()
        {
            return false;
        }

        public virtual bool IsPost()
        {
            return false;
        }
    }

    public class Normal : Exam
    {
        public Normal(Course course, string date) : base(course, date)
        {
            
        }

        public override bool IsNormal()
        {
            return true;
        }
    }

    public class Post : Exam
    {
        public Post(Course course, string date) : base(course, date)
        {
            
        }

        public override bool IsPost()
        {
            return true;
        }
    }
}