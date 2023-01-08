namespace Lab1
{
    internal static class Program
    {
        static void Main()
        {
            Figure cube = new Cube(20);
            cube.Notify += Message;
            cube.InformationEvent += MessageEventHandler;
            cube.Perimeter();
            cube.Area();
            cube.Volume();
            cube.Notify -= Message;
            cube.InformationEvent -= MessageEventHandler;

            Figure square = new Square<double>(20);
            square.Notify += Message;
            square.InformationEvent += MessageEventHandler;
            square.Area();
            square.Perimeter();
            square.Notify -= Message;
            square.InformationEvent -= MessageEventHandler;

            void Message(string message, double value) => Console.WriteLine($"{message}: {value}");

            void MessageEventHandler(object? sender, InformationEventArgs e)
            {
                Console.WriteLine(e.Message);
            }

            (double sideCube, string infoCube) = cube;
            (double sideSquare, string infoSquare) = square;
        }
    }
}