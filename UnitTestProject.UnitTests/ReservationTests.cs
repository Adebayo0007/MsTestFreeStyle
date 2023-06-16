using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace UnitTestProject.UnitTests
{
    [TestClass]
    public class ReservationTests
    {
        [TestMethod]
        public void CanBecancelledBy_UserIsAdmin_ReturnTrue()
        {
            //Arrange
            var reservation = new Reservation();

            //act 
          var result = reservation.CanBeCancelledBy(new User(true));

            //Assert 
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBecancelledBy_SameUserCancellingReservation_ReturnTrue()
        {
            //Arrange
            var user = new User();
            var reservation = new Reservation { MadeBy= user };

            //act 
            var result = reservation.CanBeCancelledBy(user);

            //Assert 
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void CanBecancelledBy_AnotherUserCancellingReservation_RetuenFalse()
        {
            //Arrange
            var reservation = new Reservation { MadeBy = new User() };

            //act 
            var result = reservation.CanBeCancelledBy(new User());

            //Assert 
            Assert.IsFalse(result);
        }
    }

    public class User
    {
        public bool IsAdmin { get; set; }
        public User(bool isAdmin)
        {
            IsAdmin = isAdmin;
        }
        public User()
        {
           
        }



    }

    public class Reservation
    {
        public User MadeBy { get; set; }
        public bool CanBeCancelledBy(User user)
        {
            if (user.IsAdmin)return true;
            if (MadeBy.Equals(user)) return true;
            return false;
        }
    }
}
