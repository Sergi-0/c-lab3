using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_2
{
    public class Car //: IEquatable<Car>
    {
        public Car(String a, string b, int c) {
            Name = a;
            Engine = b;
            MaxSpeed = c;
        }
        public string Name { get; set; }
        public string Engine { get; set; }
        public int MaxSpeed { get; set; }

        public override string ToString() => Name;

        public bool Equals(Car other)
        {
            if (other == null) return false;
            return this.Name == other.Name && this.Engine == other.Engine && this.MaxSpeed == other.MaxSpeed;
        }
    }

    public class CarsCatalog
    {
        private List<Car> cars = new List<Car>();

        public string this[int a]
        {
            get
            {
                if (a >= 0 && a < cars.Count)
                {
                    return $"{cars[a].Name} - {cars[a].Engine}";
                }
                return "Invalid index";
            }
        }

        public void AddCar(Car car)
        {
            cars.Add(car);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        CarsCatalog Catalog = new CarsCatalog();
        Catalog.AddCar(new Car("BMV", "v8", 325));
        Catalog.AddCar(new Car("BMV", "v8", 325));
        Catalog.AddCar(new Car("Mers", "v8", 400));
        Catalog.AddCar(new Car("Audy", "v6", 230));
        Catalog.AddCar(new Car("Volga", "v228", 1999));
        Console.WriteLine(Catalog[4]);
        Console.WriteLine(Catalog[0].Equals(Catalog[1]));
        }
    }
}
