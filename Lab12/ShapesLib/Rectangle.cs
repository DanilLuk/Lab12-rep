using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShapesLib
{
    public class Rectangle : Shape
    {
        private static double CheckValue() // проверка правильности ввода значений типа double
        {
            double value;
            string buffer;
            bool isDouble = false;
            do
            {
                Console.WriteLine("Enter Value (double)");
                buffer = Console.ReadLine();
                isDouble = double.TryParse(buffer, out value);
            } while (!isDouble);
            Console.WriteLine();
            return value;
        }

        private double length;
        private double width;

        public double Length
        {
            get { return length; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Value must be greater than 0"); // длина должна быть больше 0
                length = value;
            }
        }
        public double Width
        {
            get { return width; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Value must be greater than 0"); // ширина должна быть больше 0
                width = value;
            }
        }

        // конструкторы
        public Rectangle() : base() // без параметров
        {
            Length = 10;
            Width = 5;
        }

        public Rectangle(string name, double len, double wid) : base(name) // с параметрами
        {
            Length = len;
            Width = wid;
        }

        // методы просмотра
        public void RShow()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Length: {Length}");
            Console.WriteLine($"Width: {Width}\n");
        }

        public override void ShowVirt() // виртуальный
        {
            base.ShowVirt();
            Console.WriteLine($"Length: {Length}");
            Console.WriteLine($"Width: {Width}");
        }

        // методы инициализации
        public override void Init()
        {
            base.Init();
            try
            {
                Length = CheckValue();
            }
            catch (Exception exception) when (exception is ArgumentException)
            {
                Console.WriteLine($"Error: {exception.Message}\n Length will be set to 10\n");
                Length = 10;
            }

            try
            {
                Width = CheckValue();
            }
            catch (Exception exception) when (exception is ArgumentException)
            {
                Console.WriteLine($"Error: {exception.Message}\n Width will be set to 5\n");
                Width = 5;
            }
        }

        public override void RandomInit() // ДСЧ
        {
            base.RandomInit();
            Length = rand.Next(1, 100);
            Width = rand.Next(1, 100);
        }

        // Equals override
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;
            Rectangle rect = (Rectangle)obj;
            return length == rect.Length && width == rect.Width;
        }
    }
}
