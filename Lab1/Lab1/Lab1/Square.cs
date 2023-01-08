using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class Square<T> : Figure where T : new()
    {
        private double res = 0;

        private const double No = 0;
        public Square(double side) : base(side)
        {
            Side = side;
        }

        public Square(int side) : base(side)
        {
            Side = side;
        }

        public override void Deconstruct(out double squareSide, out string squareInfo)
        {
            squareSide = Side;
            squareInfo = "Длина стороны квадрата";
            Console.WriteLine($"{squareInfo}: {squareSide}");
        }

        
        public override void Perimeter()
        {
            res = Side * 4;
            string info = $"Периметр квадрата {res}";
            OnInfoEvent(info);
        }

        public override void Area()
        {
            res = Side * Side;
            string info = $"Площадь квадрата {res}";
            OnInfoEvent(info);
        }
        public override void Volume()
        {
            string info = $"Объём квадрата не существует {No}";
            OnInfoEvent(info);
        }

        public void Dispose()
        {
            Console.WriteLine($"Объект -Квадрат- был удалён");
        }
    }
}
