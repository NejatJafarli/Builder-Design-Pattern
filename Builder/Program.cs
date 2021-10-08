using System;

namespace Builder
{
    interface IBuilder
    {
        IBuilder Reset();
        IBuilder SetSeats(int number);
        IBuilder SetEngine(double Engine);
        IBuilder SetTripComputer();
        IBuilder SetGps();
    }


    class Car
    {
        public int Seats { get; set; }
        public double Engine { get; set; }
        public bool TripComputer { get; set; }
        public bool GPS { get; set; }
        public override string ToString()
        {
            return $"\tAutomatic Car \n\tSeats:{Seats}\n\tEngine:{Engine}\n\tTripComputer:{TripComputer}\n\tGPS:{GPS}";
        }
    }
    class Manual
    {
        public int Seats { get; set; }
        public double Engine { get; set; }
        public bool TripComputer { get; set; }
        public bool GPS { get; set; }

        public override string ToString()
        {
            return $"\tManual Car \n\tSeats:{Seats}\n\tEngine:{Engine}\n\tTripComputer:{TripComputer}\n\tGPS:{GPS}";
        }
    }

    class CarBuilder : IBuilder
    {
        private Car MyCar { get; set; }
        public IBuilder Reset()
        {
            MyCar = new Car();
            return this;
        }

        public IBuilder SetEngine(double Engine)
        {
            MyCar.Engine = Engine;
            return this;
        }

        public IBuilder SetGps()
        {
            MyCar.GPS = true;
            return this;
        }

        public IBuilder SetSeats(int number)
        {
            MyCar.Seats = number;
            return this;
        }

        public IBuilder SetTripComputer()
        {
            MyCar.TripComputer = true;
            return this;
        }
        public Car GetResult() => MyCar;
    }
    class ManualCarBuilder : IBuilder
    {
        private Manual MyCar { get; set; }
        public IBuilder Reset()
        {
            MyCar = new Manual();
            return this;
        }

        public IBuilder SetEngine(double Engine)
        {
            MyCar.Engine = Engine;
            return this;
        }

        public IBuilder SetGps()
        {
            MyCar.GPS = true;
            return this;
        }

        public IBuilder SetSeats(int number)
        {
            MyCar.Seats = number;
            return this;
        }

        public IBuilder SetTripComputer()
        {
            MyCar.TripComputer = true;
            return this;
        }
        public Manual GetResult() => MyCar;
    }

    class Director
    {
        public void MakeSuv(IBuilder builder)
        {
            builder.Reset();
            builder.SetSeats(4);
            builder.SetEngine(2.4);
        }
        public void MakeSportCar(IBuilder builder)
        {
            builder.Reset();
            builder.SetSeats(2);
            builder.SetEngine(5.0);
            builder.SetTripComputer();
            builder.SetGps();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            CarBuilder builder = new CarBuilder();
            ManualCarBuilder builder2 = new ManualCarBuilder();
            director.MakeSuv(builder);
            director.MakeSportCar(builder2);

            Console.WriteLine(builder.GetResult());
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(builder2.GetResult());

        }
    }
}
