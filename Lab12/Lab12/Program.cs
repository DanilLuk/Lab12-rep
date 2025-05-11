using System;
using System.Collections.Generic;
using System.Linq;
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
            bool finished = false;
            Point list = new Point();
            Point clone = new Point();

            while (!finished)
            {
                Console.WriteLine("1: Create List\n" +
                "2: Print list\n" +
                "3: Add point\n" +
                "4: Remove points with specific name\n" +
                "5: Create deep copy\n" +
                "6: Print deep copy\n" +
                "Type any other value to delete the list and exit program\n");

                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
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
                        break;

                    case "2":
                        if (list == null)
                        {
                            Console.WriteLine("The list is empty\n");
                            break;
                        }

                        PointList.PrintList(list);
                        Console.WriteLine();
                        break;

                    case "3":
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
                        
                        break;

                    case "4":
                        if (list == null || list.data == null)
                        {
                            Console.WriteLine("The list is empty\n");
                            break;
                        }

                        Console.WriteLine("Enter name to remove");
                        string name = Console.ReadLine();

                        list = PointList.RemovePoint(list, name);

                        Console.WriteLine("Points removed successfully\n");
                        break;

                    case "5":
                        clone = PointList.CloneList(list);
                        Console.WriteLine("list copied successfully\n");
                        break;

                    case "6":
                        PointList.PrintList(clone);
                        Console.WriteLine();
                        break;

                    default:
                        Console.WriteLine("Exiting program");
                        list = null;
                        clone = null;
                        finished = true;
                        break;
                }
            }
        }
    }
}
