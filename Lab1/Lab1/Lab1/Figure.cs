using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public delegate void MessageEvent(string message, double value);

    public class InformationEventArgs : EventArgs
    {
        public string Message { get; }

        public InformationEventArgs(string message)
        {
            Message = message;
        }
    }
    public abstract class Figure : IVolume, IPerimeter, IArea 
    {
        public event MessageEvent? Notify;

        public event EventHandler<InformationEventArgs>? InformationEvent;
        protected virtual void OnInfoEvent(string message)
        {
            InformationEvent?.Invoke(this, new InformationEventArgs(message));
        }
        protected virtual void OnCalcEvent(string message)
        {
            InformationEvent?.Invoke(this, new InformationEventArgs(message));
        }

        public readonly double side;
        public double Side { get; set; }

        public Figure(double side)
        {
            if (side < 1)
            {
                throw new Exception("Число должно быть положительным и не ровнятся нулю");
            }

            Side = side;
        }

        public abstract void Deconstruct(out double squareSide, out string squareInfo);
        public abstract void Perimeter();
        public abstract void Area();
        public abstract void Volume();

    }
}
