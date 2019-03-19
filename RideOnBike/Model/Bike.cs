namespace RideOnBike.Model
{
    public class Bike
    {
        public Bike()
        {
            available = true;
        }

        public int Id { get; set; }
        public bool available { get; set; }
    }
}
