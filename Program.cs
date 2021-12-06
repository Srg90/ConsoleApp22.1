using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp22._1
{
    internal class Program
    {
        static int[] number;

        static void Main(string[] args)
        {
            Action action1 = new Action(Array);
            Action<Task, object> action2 = new Action<Task, object>(SumArray);
            Action<Task, object> action3 = new Action<Task, object>(MinMax);
            Task task1 = new Task(action1);
            Task task2 = task1.ContinueWith(action2, 100);
            Task task3 = task2.ContinueWith(action3, 100);
            task1.Start();
            task1.Wait();


            Console.ReadKey();
        }

        static void Array()
        {
            Console.Write("Задайте значение размера массива чисел: ");
            int N = Convert.ToInt32(Console.ReadLine());
            number = new int[N];
            Random randomArray = new Random();
            Console.WriteLine("Формируем массив целых чисел...");
            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine($"Массив сформируется через: {i} сек");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
            for (int i = 0; i < N; i++)
            {
                number[i] = randomArray.Next(10, 100);
                Console.Write("{0, 2} ", number[i]);
            }
            Console.WriteLine();
            Console.WriteLine("Массив успешно сформирован!");
            Console.WriteLine();
        }

        static void SumArray(Task task, object a)
        {
            int n = (int)a;
            int Sum = 0;
            int Num = 0;
            Console.WriteLine("Подсчет суммы целых чисел массива...");
            for (int i = 0; i < number.Length; i++)
            {
                Num += 1;
                Sum += number[i];
                Console.WriteLine("Число {0} = {1}", Num, number[i]);
                Thread.Sleep(500);

            }
            Console.WriteLine("Сумма целых чисел массива: {0}", Sum);
            Console.WriteLine();
        }

        static void MinMax(Task task, object c)
        {
            int n1 = (int)c;
            Console.WriteLine("Получение максимального и минимального значений...");
            for (int i = 3; i > 0; i--)
            {
                Console.WriteLine($"Подсчет завершится через: {i} сек");
                Thread.Sleep(1000);
            }
            int max = number[0];
            foreach (int a in number)
            {
                if (a > max)
                    max = a;
            }
            int min = number[0];
            foreach (int b in number)
            {
                if (b < min)
                    min = b;
            }
            Console.WriteLine();
            Console.WriteLine("Максимальное число массива: {0}", max);
            Console.WriteLine("Минимальное число массива: {0}", min);
        }
    }
}
