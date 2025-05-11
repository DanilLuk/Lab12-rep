using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesLib
{
    public class Circle : Shape
    {
        private static double CheckValue() // проверка правильности ввода значений типа double
        {
            double value;
            string buffer;
            bool isDouble = false;
            do
            {
                Console.WriteLine("Enter Radius (double)");
                buffer = Console.ReadLine();
                isDouble = double.TryParse(buffer, out value);
            } while (!isDouble);
            Console.WriteLine();
            return value;
        }

        protected double radius;

        public double Radius
        {
            get { return radius; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Value must be greater than 0"); // радиус должен быть больше 0
                radius = value;
            }
        }

        // конструкторы
        public Circle() : base() // без параметров
        {
            Radius = 1;
        }

        public Circle(string name, double rad) : base(name) // с параметром
        {
            Radius = rad;
        }

        // метод просмотра 
        public void CShow()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Radius: {Radius}\n");
        }

        public override void ShowVirt() // виртуальный
        {
            base.ShowVirt();
            Console.WriteLine($"Radius: {Radius}");
        }

        // метод инициализации
        public override void Init()
        {
            base.Init();
            try
            {
                Radius = CheckValue();
            }
            catch (Exception exception) when (exception is ArgumentException)
            {
                Console.WriteLine($"Error: {exception.Message}\n Radius will be set to 1\n");
                Radius = 1;
            }
        }

        public override void RandomInit() // ДСЧ
        {
            base.RandomInit();
            Radius = rand.Next(1, 100);
        }

        // Equals override
        public override bool Equals(object obj)
        {
            if (!base.Equals(obj))
                return false;
            Circle circle = (Circle)obj;
            return radius == circle.Radius;
        }
    }
}
