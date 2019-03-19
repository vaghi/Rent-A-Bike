using System.Collections.Generic;
using System.Linq;

namespace RideOnBike.Model
{
    public class Store
    {
        private const int minFamilyQty = 3;
        private const int maxFamilyQty = 5;
        private const decimal familyDiscount = 30;
        private decimal earnedMoney;
        private IList<Bike> bikes;

        public Store()
        {
            earnedMoney = 0;
            bikes = new List<Bike>();
        }

        public void addBikes(List<Bike> newBikes)
        {
            newBikes.ForEach(b => bikes.Add(b));
        }

        public bool rentBikes(List<Rental> rentals)
        {
            if (bikes.Count(b => b.available) < rentals.Count)
                return false;

            List<Bike> bikesToRent = bikes.Where(b => b.available).Take(rentals.Count).ToList();
            bikesToRent.ForEach(b => b.available = false);

            decimal price = getPrice(rentals);

            if (rentals.Count >= minFamilyQty && rentals.Count <= maxFamilyQty)
                price *= 1 - familyDiscount / 100;

            earnedMoney += price;

            return true;
        }

        public int getPrice(List<Rental> rentals)
        {
            int totalPrice = 0;
            rentals.ForEach(r => totalPrice += (int)r.serviceType * r.quantity);

            return totalPrice;
        }

        public IList<Bike> getAllBikes()
        {
            return this.bikes;
        }

        public decimal getEarnedMoney()
        {
            return this.earnedMoney;
        }

        public int getMinFamilyDiscount()
        {
            return minFamilyQty;
        }

        public int getMaxFamilyDiscount()
        {
            return maxFamilyQty;
        }

        public decimal getFamilyDiscount()
        {
            return familyDiscount;
        }
    }
}
