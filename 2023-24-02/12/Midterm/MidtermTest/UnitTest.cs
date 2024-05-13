using System.Diagnostics;
using System.Text;
using Midterm;

namespace MidtermTest;

[TestClass]
public class UnitTest
{
    private Course course;
        
    [TestInitialize]
    public void Initialize()
    {
        course = new Course("Objektumelvű Programozás");
    }
    
    [TestMethod]
    public void IsExamNormal()
    {
        Normal exam = new Normal(null, "");
        Assert.IsTrue(exam.IsNormal());
        Assert.IsFalse(exam.IsPost());
    }

    [TestMethod]
    public void PostExamAnnouncedForCourse()
    {
        course.AnnouncesExam("2024.05.06.", 'U');
        Assert.IsTrue(course.IsTherePostExam());
    }
    
    [TestMethod]
    public void NoPostExamAnnouncedForCourse()
    {
        course.AnnouncesExam("2024.05.06.", 'N');
        Assert.IsFalse(course.IsTherePostExam());
    }
    
    [TestMethod]
    public void NoExamAnnouncedForCourse()
    {
        Assert.IsFalse(course.IsTherePostExam());
    }

    [TestMethod]
    public void StudentCannotRegisterToCourseMoreThanOnce()
    {
        Assert.ThrowsException<Course.StudentAlreadyRegisteredException>(() =>
        {
            Student student = new Student("Teszt Jóska");
            course.RegisterStudent(student);
            course.RegisterStudent(student);
        });
    }

    [TestMethod]
    public void MostLocationIsCorrect()
    {
        Exam a = new Exam(course, "2024.05.27.");
        a.RegisterLocation(new Location("Lovi", 100));
        a.RegisterLocation(new Location("00-411", 20));

        Exam b = new Exam(course, "2024.05.29.");
        b.RegisterLocation(new Location("Lovi", 100));

        course.AnnounceExam(a);
        course.AnnounceExam(b);
        
        Assert.IsTrue(course.MostLocations(out string date));
        Assert.AreEqual("2024.05.27.", date);
    }

    [TestMethod]
    public void Test()
    {
        StringBuilder stringBuilder = new StringBuilder();
        StringWriter stringWriter = new StringWriter(stringBuilder);
        
        Console.SetOut(stringWriter);
        Course.TestMethod();
        Assert.AreEqual("Hello, World!\n", stringBuilder.ToString());

        stringBuilder.Clear();
        Course.TestMethod();
        Assert.AreEqual("Hello, World!\n", stringBuilder.ToString());
        
        var standardOutput = new StreamWriter(Console.OpenStandardOutput());
        standardOutput.AutoFlush = true;
        Console.SetOut(standardOutput);
    }
}