namespace Main
{
    public interface IParkingLot
    {
        double availableSpots { get; set; }
        int capacity { get; set; }

        void getAvailableSpots();
    }

    public class ParkingLot : IParkingLot
    {
        public double availableSpots { get; set; }
        public int capacity { get; set; }
        public ParkingLot(int capacity = 10)
        {
            availableSpots = capacity;
            Console.WriteLine($"Current Available Spots: {availableSpots}");
        }

        public void getAvailableSpots()
        {
            Console.WriteLine($"Number of Parking Spots: {availableSpots}");
        }
    }

    public interface IVehicle
    {
        public double vehicleSize { get; }

        public void Park();

        public void Leave();
    }

    public abstract class Vehicle : IVehicle
    {
        public abstract double vehicleSize { get; }

        private readonly IParkingLot _parkingLot;

        public Vehicle(IParkingLot parkinglot)
        {
            _parkingLot = parkinglot;
        }

        public void Park()
        {

            if (_parkingLot.availableSpots <= 0)
            {
                Console.WriteLine($"Parking Spots are full.");
            }
            else
            {
                _parkingLot.availableSpots = _parkingLot.availableSpots - vehicleSize;
            }
        }

        public void Leave()
        {
            if (_parkingLot.availableSpots <= 10)
            {
                _parkingLot.availableSpots = _parkingLot.availableSpots + vehicleSize;
            } else
            {
                Console.WriteLine($"Parking Lot is empty.");
            }
        }
    }

    public class Car : Vehicle
    {
        public override double vehicleSize { get; } = 1;

        public Car(IParkingLot parkinglot) : base(parkinglot)
        {
        }
    }

    public class Motorcycle : Vehicle
    {
        public override double vehicleSize { get; } = 0.5;

        public Motorcycle(IParkingLot parkinglot) : base(parkinglot)
        {
        }
    }

    public class Truck : Vehicle
    {
        public override double vehicleSize { get; } = 2;

        public Truck(IParkingLot parkinglot) : base(parkinglot)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot parkingLot = new();
            // parkingLot.getAvailableSpots();

            Car car1 = new Car(parkingLot);
            Car car2 = new Car(parkingLot);
            Car car3 = new Car(parkingLot);
            Truck truck1 = new Truck(parkingLot);
            Truck truck2 = new Truck(parkingLot);
            // Truck truck3 = new Truck(parkingLot);
            // Motorcycle motorcycle1 = new Motorcycle(parkingLot);
            // Motorcycle motorcycle2 = new Motorcycle(parkingLot);
            // Motorcycle motorcycle3 = new Motorcycle(parkingLot);

            car1.Park();
            car2.Park();
            car3.Park();
            truck1.Park();
            truck2.Park();
            // truck3.Park();
            // motorcycle1.Park();
            // truck1.Park();

            parkingLot.getAvailableSpots();
        }
    }
}