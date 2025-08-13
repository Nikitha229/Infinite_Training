using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mini_Project;

namespace MiniProject.Tests
{

    [TestClass]
    public class LoginTests
    {
        [TestMethod]
        public void Authenticate_WithInvalidCredentials_ReturnsZero()
        {
            string email = "wrongemail@example.com";
            string password = "wrongpass";

            int result = Login.Authenticate(email, password);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Authenticate_WithvalidCredentials_ReturnsOne()
        {
            string email = "admin@railway.com";
            string password = "admin";

            int result = Login.Authenticate(email, password);

            Assert.AreEqual(1, result);
        }
    }
}
