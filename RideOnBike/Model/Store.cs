using System.Collections.Generic;
using System.Linq;

namespace RideOnBike.Model
{
    public class Store
    {
        private int minFamilyQty = 3;
        private int maxFamilyQty = 5;
        private int familyDiscount = 30;
        private int moneyIncome = 0;
        private IList<Bike> bikes = new List<Bike>();

        public void addBikes(List<Bike> newBikes)
        {
            newBikes.ForEach(b => bikes.Add(b));
        }

        public bool rentBikes(List<Rental> rentals)
        {
            if(bikes.Count(b => b.available) < rentals.Count)
                return false;

            moneyIncome += getPrice(rentals);

            return true;
        }

        public int getPrice(List<Rental> rentals)
        {
            int totalPrice = 0;
            rentals.ForEach(r => totalPrice += (int)r.serviceType * r.quantity);

            return totalPrice;
        }
    }
}
