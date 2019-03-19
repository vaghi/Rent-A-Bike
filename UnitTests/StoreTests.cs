using Microsoft.VisualStudio.TestTools.UnitTesting;
using RideOnBike.Constants;
using RideOnBike.Model;
using System;
using System.Collections.Generic;

namespace StoreTests
{
    [TestClass]
    public class StoreTests
    {
        private void addBikes(Store store, int quantityOfBikes)
        {
            List<Bike> newBikes = new List<Bike>();
            for (int i = 0; i < quantityOfBikes; i++)
                newBikes.Add(new Bike());

            store.addBikes(newBikes);
        }

        [TestMethod]
        public void EmptyBikesOnNewStore()
        {
            Store newStore = new Store();
            Assert.AreEqual(newStore.getAllBikes().Count, 0);
        }

        [TestMethod]
        public void NoEarnedMoneyOnNewStore()
        {
            Store newStore = new Store();
            Assert.AreEqual(newStore.getEarnedMoney(), 0);
        }

        [TestMethod]
        public void OneBikeStore()
        {
            Store newStore = new Store();
            addBikes(newStore, 1);
            Assert.AreEqual(newStore.getAllBikes().Count, 1);
        }

        [TestMethod]
        public void AddedBikesOnNewStore()
        {
            Store newStore = new Store();
            int bikesToAdd = 3;
            addBikes(newStore, bikesToAdd);

            Assert.AreEqual(bikesToAdd, newStore.getAllBikes().Count);
        }

        [TestMethod]
        public void AddedBikesOnStore()
        {
            Store newStore = new Store();
            addBikes(newStore, 1);
            int initialBikes = newStore.getAllBikes().Count;
            int bikesToAdd = 3;

            addBikes(newStore, bikesToAdd);

            Assert.AreEqual(initialBikes + bikesToAdd, newStore.getAllBikes().Count);
        }

        [TestMethod]
        public void OneHourPrice()
        {
            Store newStore = new Store();
            addBikes(newStore, 1);

            List<Rental> newRental = new List<Rental>();
            newRental.Add(new Rental() { quantity = 1, serviceType = ServiceType.Hour });
            newStore.rentBikes(newRental);

            Assert.AreEqual((int)ServiceType.Hour, newStore.getEarnedMoney());
        }

        [TestMethod]
        public void RandomHourQuantity()
        {
            Store newStore = new Store();
            addBikes(newStore, 1);

            Random randomGenerator = new Random();
            int randomQuantity = randomGenerator.Next(2, 100);

            List<Rental> newRental = new List<Rental>();
            newRental.Add(new Rental() { quantity = randomQuantity, serviceType = ServiceType.Hour });
            newStore.rentBikes(newRental);

            Assert.AreEqual((int)ServiceType.Hour * randomQuantity, newStore.getEarnedMoney());
        }

        [TestMethod]
        public void OneDayPrice()
        {
            Store newStore = new Store();
            addBikes(newStore, 1);

            List<Rental> newRental = new List<Rental>();
            newRental.Add(new Rental() { quantity = 1, serviceType = ServiceType.Day });
            newStore.rentBikes(newRental);

            Assert.AreEqual((int)ServiceType.Day, newStore.getEarnedMoney());
        }

        [TestMethod]
        public void RandomDayQuantity()
        {
            Store newStore = new Store();
            addBikes(newStore, 1);

            Random randomGenerator = new Random();
            int randomQuantity = randomGenerator.Next(2, 100);

            List<Rental> newRental = new List<Rental>();
            newRental.Add(new Rental() { quantity = randomQuantity, serviceType = ServiceType.Day });
            newStore.rentBikes(newRental);

            Assert.AreEqual((int)ServiceType.Day * randomQuantity, newStore.getEarnedMoney());
        }

        [TestMethod]
        public void OneWeekPrice()
        {
            Store newStore = new Store();
            addBikes(newStore, 1);

            List<Rental> newRental = new List<Rental>();
            newRental.Add(new Rental() { quantity = 1, serviceType = ServiceType.Week });
            newStore.rentBikes(newRental);

            Assert.AreEqual((int)ServiceType.Week, newStore.getEarnedMoney());
        }

        [TestMethod]
        public void RandomWeekQuantity()
        {
            Store newStore = new Store();
            addBikes(newStore, 1);

            Random randomGenerator = new Random();
            int randomQuantity = randomGenerator.Next(2, 100);

            List<Rental> newRental = new List<Rental>();
            newRental.Add(new Rental() { quantity = randomQuantity, serviceType = ServiceType.Week });
            newStore.rentBikes(newRental);

            Assert.AreEqual((int)ServiceType.Week * randomQuantity, newStore.getEarnedMoney());
        }

        [TestMethod]
        public void BaseMixedRentals()
        {
            Store newStore = new Store();
            addBikes(newStore, 3);

            List<Rental> newRental = new List<Rental>();
            newRental.Add(new Rental() { quantity = 1, serviceType = ServiceType.Hour });
            newRental.Add(new Rental() { quantity = 1, serviceType = ServiceType.Day });
            newStore.rentBikes(newRental);

            Assert.AreEqual((int)ServiceType.Hour + (int)ServiceType.Day, newStore.getEarnedMoney());
        }

        [TestMethod]
        public void RandomMixedRentals()
        {
            Store newStore = new Store();
            addBikes(newStore, 2);

            Random randomGenerator = new Random();
            int randomHoursQuantity = randomGenerator.Next(2, 100);
            int randomDaysQuantity = randomGenerator.Next(2, 100);

            List<Rental> newRental = new List<Rental>();
            newRental.Add(new Rental() { quantity = randomHoursQuantity, serviceType = ServiceType.Hour });
            newRental.Add(new Rental() { quantity = randomDaysQuantity, serviceType = ServiceType.Day });
            newStore.rentBikes(newRental);

            decimal expectedMoney = (int) ServiceType.Hour * randomHoursQuantity + (int) ServiceType.Day * randomDaysQuantity;
            Assert.AreEqual(expectedMoney, newStore.getEarnedMoney());
        }

        [TestMethod]
        public void RentalMoneyAdded()
        {
            Store newStore = new Store();
            addBikes(newStore, 3);

            Random randomGenerator = new Random();
            int randomHoursQuantity = randomGenerator.Next(2, 100);
            int randomDaysQuantity = randomGenerator.Next(2, 100);
            int randomWeeksQuantity = randomGenerator.Next(2, 100);

            List<Rental> newRental = new List<Rental>();
            newRental.Add(new Rental() { quantity = randomHoursQuantity, serviceType = ServiceType.Hour });
            newStore.rentBikes(newRental);

            decimal expectedMoney = (int)ServiceType.Hour * randomHoursQuantity;
            Assert.AreEqual(newStore.getEarnedMoney(), expectedMoney);

            newRental = new List<Rental>();
            newRental.Add(new Rental() { quantity = randomDaysQuantity, serviceType = ServiceType.Day });
            newStore.rentBikes(newRental);

            expectedMoney += (int)ServiceType.Day * randomDaysQuantity;
            Assert.AreEqual(newStore.getEarnedMoney(), expectedMoney);

            newRental = new List<Rental>();
            newRental.Add(new Rental() { quantity = randomWeeksQuantity, serviceType = ServiceType.Week });
            newStore.rentBikes(newRental);

            expectedMoney += (int)ServiceType.Week * randomWeeksQuantity;
            Assert.AreEqual(expectedMoney, newStore.getEarnedMoney());
        }

        [TestMethod]
        public void FamilyDiscountApplied()
        {
            Store newStore = new Store();
            Random randomGenerator = new Random();
            decimal expectedMoney = 0;
            decimal currentRent = 0;
            List<Rental> newRental;

            for (var i = 2; i < 10; i++)
            {
                addBikes(newStore, i);
                newRental = new List<Rental>();
                currentRent = 0;

                for (int j = 0; j < i; j++) {
                    int randomQuantity = randomGenerator.Next(2, 100);
                    Array values = Enum.GetValues(typeof(ServiceType));
                    ServiceType randomServiceType = (ServiceType)values.GetValue(randomGenerator.Next(values.Length));
                    newRental.Add(new Rental() { quantity = randomQuantity, serviceType = randomServiceType });
                    currentRent += randomQuantity * (int)randomServiceType;
                }

                if (i >= newStore.getMinFamilyDiscount() && i <= newStore.getMaxFamilyDiscount())
                    currentRent = currentRent * (1 - newStore.getFamilyDiscount() / 100);

                expectedMoney += currentRent;
                
                newStore.rentBikes(newRental);
                Assert.AreEqual(expectedMoney, newStore.getEarnedMoney());
            }
        }
    }
}
