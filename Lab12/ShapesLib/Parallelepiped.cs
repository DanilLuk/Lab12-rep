using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesLib
{
    public class Par : Rectangle
    {
        private static double CheckValue() // проверка правильности ввода значений типа double
        {
            double value;
            string buffer;
            bool isDouble = false;
            do
            {
                Console.WriteLine("Enter Height (double)");
                buffer = Console.ReadLine();
                isDouble = double.TryParse(buffer, out value);
            } while (!isDouble);
            Console.WriteLine();
            return value;
        }

        private double height;

        public double Height
        {
            get { return height; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Value must be greater than 0"); // высота должна быть больше 0
                height = value;
            }
        }

        // конструкторы
        public Par() : base() // без параметров
        {
            height = 10;
        }

        public Par(string name, double length, double width, double hght) : base(name, length, width) // с параметрами
        {
            Height = hght;
        }

        // методы просмотра
        public void PShow()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Length: {Length}");
            Console.WriteLine($"Width: {Width}");
            Console.WriteLine($"Height: {Height}\n");
        }

        public override void ShowVirt() // виртуальный
        {
            base.ShowVirt();
            Console.WriteLine($"Height: {Height}");
        }

        // методы инициализации
        public override void Init()
        {
            base.Init();
            try
            {
                Height = CheckValue();
            }
            catch (Exception exception) when (exception is ArgumentException)
            {
                Console.WriteLine($"Error: {exception.Message}\n Height will be set to 10\n");
                Height = 10;
            }
        }

        public override void RandomInit() // ДСЧ
        {
            base.RandomInit();
            Height = rand.Next(1, 100);
        }

        // Equals override
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;
            Par par = (Par)obj;
            return height == par.Height;
        }
    }
}
