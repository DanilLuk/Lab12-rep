using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ShapesLib;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice;            

            Console.WriteLine("Choose the number of the task (1 - 4)\n Type any other symbol to exit\n");

            choice = Console.ReadLine();
            switch (choice)
            {
                case "1": // ЗАДАНИЕ 1 _______________________________________________________________________________________________________________

                    Point list = new Point();
                    Point clone = new Point();

                    // СОЗДАНИЕ СПИСКА

                    Console.WriteLine("Enter the list length:"); 
                    string buffer;
                    bool isChecked;
                    int len;

                    do
                    {
                        buffer = Console.ReadLine();
                        isChecked = int.TryParse(buffer, out len);
                        if (len <= 0)
                        {
                            Console.WriteLine("Enter a positive integer value");
                            isChecked = false;
                        }
                    } while (!isChecked);

                    list = PointList.MakeList(len);
                    Console.WriteLine("List created successfully\n");


                    // ВЫВОД СПИСКА

                    PointList.PrintList(list);
                    Console.WriteLine();


                    // ДОБАВЛЕНИЕ ТОЧКИ

                    Console.WriteLine("Enter index for the new point");
                    int place; // место для новой точки

                    do
                    {
                        buffer = Console.ReadLine();
                        isChecked = int.TryParse(buffer, out place);
                        if (place <= 0)
                        {
                            Console.WriteLine("Enter a positive integer value");
                            isChecked = false;
                        }
                    } while (!isChecked);

                    list = PointList.AddPoint(list, place);


                    // ВЫВОД СПИСКА

                    PointList.PrintList(list);
                    Console.WriteLine();


                    // УДАЛЕНИЕ ТОЧКИ

                    Console.WriteLine("Enter name to remove");
                    string name = Console.ReadLine();

                    list = PointList.RemovePoint(list, name);

                    Console.WriteLine("Points removed successfully\n");


                    // ВЫВОД СПИСКА

                    PointList.PrintList(list);
                    Console.WriteLine();


                    // КЛОНИРОВАНИЕ И ВЫВОД СПИСКА

                    clone = PointList.CloneList(list);
                    Console.WriteLine("list copied successfully\n");

                    PointList.PrintList(clone);
                    Console.WriteLine();


                    // УДАЛЕНИЕ СПИСКА И ЗАВЕРШЕНИЕ

                    Console.WriteLine("Exiting program");
                    list = null;
                    clone = null;

                    break;

                case "2": // ЗАДАНИЕ 2 __________________________________________________________________________________________________________

                    // СОЗДАНИЕ ТАБЛИЦЫ

                    HTable<Shape> table = new HTable<Shape>(10);


                    // ДОБАВЛЕНИЕ ТОЧЕК

                    Rectangle shape;

                    for (int i = 0; i < 5; i++)
                    {
                        shape = new Rectangle();
                        shape.RandomInit();

                        table.Add(shape);
                    }

                    shape = new Rectangle("Z", 1, 1); // специальная точка для поиска и удаления
                    table.Add(shape);

                    table.Print();


                    // ПОИСК И УДАЛЕНИЕ ТОЧКИ

                    Console.WriteLine("Searching for point 'Z'...");
                    table.Find(shape);

                    Console.WriteLine("Deleting point 'Z'...");
                    table.Delete(shape);

                    table.Print();

                    table.Find(shape);

                    break;

                default: 
                    break;
            }            
        }
    }
}
