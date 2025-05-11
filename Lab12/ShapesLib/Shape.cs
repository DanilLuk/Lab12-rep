using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapesLib
{
    public class Shape
    {
        protected string name;
        protected static Random rand = new Random(); // для RandomInit

        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Name cannot be empty or only contain spaces"); // имя не может быть пустым
                name = value;
            }
        }

        // конструкторы
        public Shape() // без параметров
        {
            Name = "Shape";
        }

        public Shape(string name) // с параметром
        {
            Name = name;
        }

        public Shape(Shape copy) // глубокое копирование
        {
            this.name = copy.name;
        }

        // методы просмотра
        public void Show()
        {
            Console.WriteLine($"Name: {name}");
        }

        public virtual void ShowVirt() // виртуальный
        {
            Console.WriteLine($"\nName: {name}");
        }

        // метод инициализации
        public virtual void Init()
        {
            Console.WriteLine("Enter name");
            Name = Console.ReadLine();
            Console.WriteLine();
        }

        public virtual void RandomInit() // ДСЧ
        {
            string[] nameArr = { "A", "B", "C", "D", "E", "F" };
            Name = nameArr[rand.Next(nameArr.Length)];
        }

        // Equals override
        public override bool Equals(object obj)
        {
            if (GetType() != obj.GetType())
                return false;
            Shape shape = (Shape)obj;
            return string.Equals(Name, shape.Name, StringComparison.OrdinalIgnoreCase); // без учитывания регистра
        }
    }
}
