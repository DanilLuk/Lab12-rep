using ShapesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class PointList
    {
        public static Point MakeList(int len) // создание списка с добавлением новых элементов в начало
        {
            if (len <= 0)
            {
                Console.WriteLine("Invalid length value");
                return null;
            }

            Circle obj = new Circle();
            obj.RandomInit();
            Point beg = new Point(obj);

            for (int i = 1; i < len; i++)
            {
                obj = new Circle();
                obj.RandomInit();
                Point p = new Point(obj);
                p.next = beg;
                beg.prev = p;
                beg = p;
            }
            return beg;
        }

        public static void PrintList(Point beg) // печать списка
        {
            if (beg == null)
                throw new NullReferenceException();
            try
            {
                Point p = beg;
                p.data.ShowVirt();

                while (p.next != null) // работает, пока не достигнет null
                {
                    p.next.data.ShowVirt();
                    p = p.next;
                }
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("The list is empty");
            }            
        }

        public static Point AddPoint(Point list, int place) // принимает список, номер места новой точки
        {
            Circle obj = new Circle();
            obj.RandomInit();
            Point newPoint = new Point(obj);
            
            if (list == null)
                return newPoint;

            if (place == 1)
            {
                newPoint.next = list;
                Console.WriteLine("Point added successfully\n");
                return newPoint;
            }

            Point temp = list; // вспомогательный объект

            for (int i = 1; i < place - 1 && temp != null; i++)
                temp = temp.next;
            if (temp == null)
            {
                Console.WriteLine("Invalid index value\n");
                return list;
            }

            newPoint.next = temp.next;
            temp.next = newPoint;
            Console.WriteLine("Point added successfully\n");
            return list;
        }

        public static Point RemovePoint(Point list, string name)
        {
            Point beg = null;

            if (list.data.Name != name)
                beg = list;
            else
            {
                while (list.next != null) // удаление всех удаляемых точек из начала
                {
                    if (list.data.Name != name)
                    {
                        beg = list;
                        break;
                    }
                    list = list.next;
                }
                if (beg == null)
                    return beg;
            }
            list = beg; // переставляем указатель на новое начало

            while (list.next.next != null) // цикл удаляет остальные элементы (которые не в начале)
            {
                if (list.next.data.Name == name)
                {
                    list.next = list.next.next;
                    continue;
                }        
                list = list.next;
            }
            if (list.next.data.Name == name)
                list.next = null;

            return beg;
        }

        public static Point CloneList(Point list)
        {
            while (list.next != null) // перевод курсора в конец (чтобы в конце получаемый клон был началом списка)
                list = list.next;

            Point clone = (Point)list.Clone(); // алгоритм такой же, как и в создании списка

            while (list.prev != null)
            {
                Point p = (Point)list.prev.Clone();
                
                p.next = clone;
                clone.prev = p;
                clone = p;

                list = list.prev;
            }
            return clone;
        }
    }
}
