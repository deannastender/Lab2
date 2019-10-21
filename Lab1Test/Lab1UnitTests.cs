using Lab1.Controllers;
using Lab1.Data;
using Lab1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Lab1Test
{
    [TestClass]
    class Lab1UnitTests
    {
        private static DealershipMgr _dealershipMgr = new DealershipMgr();

        [TestMethod]
        public void TestAPIGetDealerships()
        {
            //Arrange
            DealershipAPIController dealershipAPI = new DealershipAPIController();

            //Act
            var dealerships = dealershipAPI.Get();

            //Assert
            int count = dealerships.Count();
            Assert.AreEqual(2, count);
        }

        [TestMethod]
        public void TestGetDealershipByID()
        {
            //Act
            Dealership dealership1 = _dealershipMgr.GetDealership(1);
            Dealership dealership2 = _dealershipMgr.GetDealership(2);

            //Assert
            Assert.AreEqual(1, dealership1.ID);
            Assert.AreEqual("Toyota Oakville", dealership1.Name);

            Assert.AreEqual("queenston.contact@chevy.com", dealership2.Email);
            Assert.AreEqual("122-441-2214", dealership2.PhoneNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(System.NullReferenceException))]
        public void TestGetDealershipByIDNegative()
        {
            //Act
            Dealership dealership4 = _dealershipMgr.GetDealership(4);
        }

        [TestMethod]
        public void TestAddDealership()
        {
            //Act
            Dealership newDealership = new Dealership { ID = 9, Name = "Test Dealership", Email = "testdealership@test.com", PhoneNumber = "930-203-2930" };
            Dealership dealership = _dealershipMgr.AddDealership(newDealership);

            Dealership getDealership = _dealershipMgr.GetDealership(9);

            //Assert
            Assert.IsNotNull(getDealership);
            Assert.AreEqual(9, getDealership.ID);
            Assert.AreEqual("Test Dealership", getDealership.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException), "Id already exists!")]
        public void TestAddDealershipInvalid()
        {
            //Act
            Dealership newDealership = new Dealership { ID = 1, Name = "Test Dealership", Email = "deanna.test@live.com" };
            Dealership dealership = _dealershipMgr.AddDealership(newDealership);
        }
    }
}
