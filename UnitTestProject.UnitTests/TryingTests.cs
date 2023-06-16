using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UnitTestProject.UnitTests
{
    [TestClass]
    public class TryingTests
    {
        [TestMethod]
        public void CanBecancelledBy_StudentIsStudent_ReturnTrue()
        {
            //Arrange
            var app = new Application();

            //act 
            var result = app.CanBeCancelledBy(new Student(true));

            //Assert 
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBecancelledBy_SameStudentCancellingApplication_ReturnTrue()
        {
            //Arrange
            var student = new Student();
            var app = new Application { FillBy= student };

            //act 
            var result = app.CanBeCancelledBy(student); 

            //Assert 
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBecancelledBy_AnotherStudentCancellingApplication_ReturnFalse()
        {
            //Arrange
            var app = new Application { FillBy = new Student()};

            //act 
            var result = app.CanBeCancelledBy(new Student());

            //Assert 
            Assert.IsFalse(result);
        }
    }

    public class Student
    {
        public bool IsStudent { get; set; }
        public Student(bool isStudent)
        {
            IsStudent = isStudent;
        }
        public Student()
        {

        }



    }

    public class Application
    {
        public Student FillBy { get; set; }
        public bool CanBeCancelledBy(Student student)
        {
            if (student.IsStudent)return true;
            if (FillBy.Equals(student)) return true;
            return false;
        }
    }
}
