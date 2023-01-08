using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Cube : Figure, IDisposable
    {
        private double res = 0;

        public Cube(double side) : base(side)
        {
            Side = side;
        }

        public Cube(int side) : base(side)
        {
            Side = side;
        }

        public override void Deconstruct(out double cubeSide, out string cubeInfo)
        {
            cubeSide = Side;
            cubeInfo = "Длина стороны куба";
            Console.WriteLine($"{cubeInfo}: {cubeSide}");
        }

        public override void Perimeter()
        {
            res = Side * 12;
            string info = $"Периметр куба: {res}"; 
            OnInfoEvent(info);

        }

        public override void Area()
        {
            res = 6 * Math.Pow(Side, 2);
            string info = $"Площадь куба: {res}";
            OnInfoEvent(info);
        }

        public override void Volume()
        {
            res = Math.Pow(Side, 3);
            string info = $"Объем куба: {res}";
            OnInfoEvent(info);
        }

        public void Dispose()
        {
            Console.WriteLine($"Объект -Куб- был удалён");
        }
    }
}
