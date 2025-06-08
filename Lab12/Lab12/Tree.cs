using ShapesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    public class Tree<T> where T : Circle
    {
        public TPoint<T> root;
        public static double minValue; // для поиска минимума
        public static int size = 0;
        private static int i = 0; // индекс для создания дерева поиска
        public Tree()
        {
            root = null;
            size = 0;
        }
        public Tree(TPoint<T> point)
        {
            root = point;
            size = 1;
        }


        // СОЗДАНИЕ ДЕРЕВА

        public static TPoint<T> BalancedTree(int size) // используемая функция для создания дерева
        {
            if (size <= 0)
            {
                Console.WriteLine("Created null tree\n");
                return null;
            }

            return CreateBalancedTree(size);
        }
        private static TPoint<T> CreateBalancedTree(int size) // внутренняя функция для создания дерева
        {
            if (size == 0)
                return null;
            int lSize = size / 2;
            int rSize = size - lSize - 1;

            Circle circ = new Circle();
            circ.RandomInit();
            TPoint<T> point = new TPoint<T>(circ);

            point.left = CreateBalancedTree(lSize);
            point.right = CreateBalancedTree(rSize);

            return point;
        }


        // ВЫВОД ДЕРЕВА

        public static void Print(Tree<T> tree) // используемая функция для вывода дерева
        {
            try
            {
                TreePrint(tree.root, 0);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("The tree is empty");
            }
        }
        private static void TreePrint(TPoint<T> point, int row) // внутренняя функция для вывода дерева
        {
            if (point.right != null)
                TreePrint(point.right, row + 1);

            Console.Write($"[level {row}] {new string ((' '), row * 8)}");
            Console.Write($"{point.data.Name}: {point.data.Radius}\n");

            if (point.left != null)
                TreePrint(point.left, row + 1);
        }


        // ЗАДАНИЕ ВАРИАНТА

        public static void FindMin(Tree<T> tree) // используемая функция поиска минимума
        {
            minValue = 101; // исходное состояние

            MinSearch(tree.root); ; // значение больше наибольшего возможного значения радиуса

            Console.WriteLine($"Minimal value: {minValue}\n");
        }
        private static void MinSearch(TPoint<T> point) // внутренняя функция поиска минимума
        {
            if (point.data.Radius < minValue)
                minValue = point.data.Radius;

            if (point.left != null)
                MinSearch(point.left);
            if (point.right != null)
                MinSearch(point.right);
        }


        // BINARY SEARCH TREE

        public static Tree<T> SortedTree(Tree<T> tree)
        {
            if (tree.root == null)
            {
                Console.WriteLine("Tree is empty\n");
                return tree;
            }

            string[] names = new string[size]; // два массива с данными для сортировки
            double[] radii = new double[size];

            FillArrays(tree.root, names, radii);
            i = 0; // счётчик в исходное состояние

            double tempR; // сортировка точек по значению радиусов
            string tempN;
            for (int j = 0; j <= names.Length - 2; j++)
            {
                for (int i = 0; i <= names.Length - 2; i++)
                {
                    if (radii[i] > radii[i + 1])
                    {
                        tempN = names[i + 1];
                        names[i + 1] = names[i];
                        names[i] = tempN;

                        tempR = radii[i + 1];
                        radii[i + 1] = radii[i];
                        radii[i] = tempR;
                    }
                }
            }

            Tree<T> bst = new Tree<T>(); // заполнение дерева
            bst.root = new TPoint<T>();
            FillTree(ref bst.root, 0, names.Length - 1, names, radii);

            return bst;
        }
        private static void FillArrays(TPoint<T> point, string[] names, double[] radii) // внутренняя функция заполнения массивов для сортировки
        {
            names[i] = point.data.Name;
            radii[i] = point.data.Radius;
            i++;

            if (point.left != null)
                FillArrays(point.left, names, radii);
            if (point.right != null)
                FillArrays(point.right, names, radii);
        }
        private static void FillTree(ref TPoint<T> point, int left, int right, string[] names, double[] radii) // функция заполнения дерева
        {
            if (left > right)
            {
                point = null;
                return;
            } 

            int mid = left + (right - left) / 2;

            point = new TPoint<T>(new Circle(names[mid], radii[mid]));

            FillTree(ref point.left, left, mid - 1, names, radii);
            FillTree(ref point.right, mid + 1, right, names, radii);
        }
    }
}
