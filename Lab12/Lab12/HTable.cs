using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ShapesLib;

namespace Lab12
{
    public class HTable<T> where T : Shape, IIndexInterface
    {
        public LPoint<T>[] table;
        public int Size;

        public LPoint<T> this[int index]
        {
            get => table[index];
            set => table[index] = value;
        }

        public HTable(int size)
        {
            Size = size;
            table = new LPoint<T>[Size];
        }

        public void Add(T info) // добавление точки
        {
            LPoint<T> point = new LPoint<T>(info);
            int index = Math.Abs(point.GetHashCode()) % Size;
            LPoint<T> cur = table[index];

            if (cur == null)
            {
                table[index] = point;
                return;
            }

            while (cur != null)
            {
                if (cur.next == null)
                    break;
                cur = cur.next;
            }

            cur.next = point;
        }

        public void Print()
        {
            Console.WriteLine("Current table:");

            if (table == null)
            {
                Console.WriteLine("Table is empty");
                return;
            }

            for (int i = 0; i < Size; i++)
            {
                if (table[i] == null)
                {
                    Console.WriteLine($"hash {i}: Empty\n");
                }
                else
                {
                    Console.WriteLine($"hash {i}: ");

                    LPoint<T> cur = table[i];

                    while (cur.next != null)
                    {                        
                        cur.value.ShowVirt();

                        cur = cur.next;
                    }

                    cur.value.ShowVirt();
                    Console.WriteLine();
                }
            }

            Console.WriteLine();
        }

        public void Delete(Shape shape)
        {
            LPoint<T> point = new LPoint<T>(shape);
            int hash = Math.Abs(point.GetHashCode()) % Size;

            point = table[hash];

            if (point == null)
                return;

            if (point.value.Equals(shape))
            {
                table[hash] = table[hash].next;
                Console.WriteLine("Point successfully deleted\n");
                return;
            }

            while (point.next != null && !point.next.value.Equals(shape))
                    point = point.next;
            if (point.next != null)
            {
                point.next = point.next.next;
                Console.WriteLine("Point successfully deleted\n");
                return;
            }

            Console.WriteLine("Error: no such point\n");
        }

        public void Find(Shape shape)
        {
            LPoint<T> point = new LPoint<T>(shape);
            int hash = Math.Abs(point.GetHashCode()) % Size;

            point = table[hash];

            while (point != null)
            {
                if (point.value.Equals(shape))
                {
                    Console.WriteLine($"Point found, hash: {hash}\n");
                    return;
                }
                point = point.next;
            }

            Console.WriteLine("Point not found\n");
            return;
        }
    }
}
