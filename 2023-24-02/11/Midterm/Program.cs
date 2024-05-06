namespace Midterm
{
    class Program
    {
        public static void Main(string[] args)
        {
            Course c = new Course("OEP");
            Exam e = new Exam(c, "tegnap");
            Location l = e.MostLikedLocation();
            Console.WriteLine(l == null);

            try
            {
                c.AnnouncesExam("ma", 'N');
            }
            catch (Course.InvalidExamTypeException)
            {
                
            }
        }
    }
}