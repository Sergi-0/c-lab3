using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_1
{
    struct Vector
    {
        public double x, y, z;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public static Vector operator +(Vector v, Vector t)
        {
            return new Vector(v.x + t.x, v.y + t.y, v.z + t.z);
        }

        public static Vector operator *(Vector v, Vector t)
        {
            return new Vector(v.x * t.x, v.y * t.y, v.z * t.z);
        }

        public static Vector operator *(Vector v, double t)
        {
            return new Vector(v.x * t, v.y * t, v.z * t);
        }

        public static bool operator !=(Vector v, Vector t)
        {
            return (Math.Sqrt(v.x*v.x + v.y* v.y + v.z * v.z) != Math.Sqrt(t.x * t.x + t.y * t.y + t.z * t.z));
        }
        public static bool operator ==(Vector v, Vector t)
        {
            return (Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z) == Math.Sqrt(t.x * t.x + t.y * t.y + t.z * t.z));
        }

        public static bool operator >(Vector v, Vector t)
        {
            return (Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z) > Math.Sqrt(t.x * t.x + t.y * t.y + t.z * t.z));
        }

        public static bool operator <(Vector v, Vector t)
        {
            return (Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z) < Math.Sqrt(t.x * t.x + t.y * t.y + t.z * t.z));
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Vector v1 = new Vector(2,3,4);
            Vector v2 = new Vector(3,4,5);
            Vector v3 = v1 + v2;
            Vector v4 = v1 * v2;
            Vector v5 = v1 * 2;
            Vector v6 = new Vector(3,4,5);

            Console.WriteLine(v6 == v1);
            Console.WriteLine(v6 == v2);
            Console.WriteLine(v2 > v1);
            Console.WriteLine(v2 < v1);
            Console.WriteLine(v2 != v1);
            Console.WriteLine($"{v3.x} {v3.y} {v3.z}");
        }
    }
}
