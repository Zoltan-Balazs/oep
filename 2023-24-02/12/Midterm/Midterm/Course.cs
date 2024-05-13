using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Midterm
{
    public class Course
    {
        public string name;
        public List<Exam> exams;
        public List<Student> attendees;

        public Course(string name)
        {
            this.name = name;
            this.exams = new List<Exam>();
            this.attendees = new List<Student>();
        }
        
        public class StudentAlreadyRegisteredException : Exception { }
        
        public void RegisterStudent(Student student)
        {
            foreach (Student s in attendees)
            {
                if (s.Equals(student))
                {
                    throw new StudentAlreadyRegisteredException();
                }
            }
            attendees.Add(student);
        }

        public bool IsTherePostExam()
        {
            foreach (Exam exam in exams)
            {
                if (exam.IsPost())
                {
                    return true;
                }
            }

            return false;
        }

        public bool MostLocations(out string date)
        {
            date = "";
            int max = 0;
            bool l = false;

            foreach (Exam exam in exams)
            {
                if (max < exam.locations.Count)
                {
                    max = exam.locations.Count;
                    date = exam.date;
                    l = true;
                }
            }

            return l;
        }
        
        public class ExamAlreadyAnnouncedOnDateException : Exception { }
        public class InvalidExamTypeException : Exception { }

        public void AnnounceExam(Exam e)
        {
            exams.Add(e);
        }

        public Exam AnnouncesExam(string date, char examType)
        {
            foreach (Exam e in exams)
            {
                if (date.Equals(e.date))
                {
                    throw new ExamAlreadyAnnouncedOnDateException();
                }
            }

            Exam exam;
            switch (examType)
            {
                case 'N':
                    exam = new Normal(this, date);
                    break;
                case 'U':
                    exam = new Post(this, date);
                    break;
                default:
                    throw new InvalidExamTypeException();
            }

            exams.Add(exam);
            return exam;
        }

        public void TestMethod()
        {
            Trace.WriteLine("Hello, World!");
        }
    }
}