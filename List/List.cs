using System;

namespace DataStructures
{
    class Program
    {
        public static int TestList;

        static void Main()
        {
            var test = new ListInt();
            Requests(test);
            Console.WriteLine("Ёмкость стэка: " + test.GetCapacity() + " Количество чисел: " + test.GetCount());
        }

        private static void Requests(ListInt test)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Выберите действие: ");
                Console.Write("1 - Add \n" +
                              "2 - Clear \n" +
                              "3 - GetCount \n" +
                              "4 - Print\n" +
                              "5 - Остановить цикл \n" +
                              "Ввод: ");
                var command = Convert.ToInt32(Console.ReadLine());
                switch (command)
                {
                    case 1:
                    {
                        Console.Write("Метод Add! Какое число вы хотите добавить? ");
                        test.Add(Convert.ToInt32(Console.ReadLine()));
                        Console.WriteLine();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine($"Метод Clear! Массив очищен!\n");
                        test.Clear();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("Метод GetCount! Взяли количество элементов\n");
                        Console.WriteLine(test.GetCount());
                        break;
                    }
                    case 4:
                    {
                        Console.WriteLine("Распечатываем все элементы\n");
                        test.Print();
                        break;
                    }
                    case 5:
                    {
                        flag = false;
                        break;
                    }
                    default:
                    {
                        Console.WriteLine("Такого запроса не существует! Повторите попытку!");
                        break;
                    }
                }
            }
        }
    }

    // реализация динамического массива
    public class ListInt
    {
        private const int DEFAULT_COUNT_ELEMENTS = 4;

        private int[] _array;
        private int _indexOfNumber = 0;
        private int _capacity = 4;
        private int _count = 0;

        public ListInt()
        {
            _array = new int[DEFAULT_COUNT_ELEMENTS];
        }

        public void Add(int number)
        {
            _count++;
            if (_count >= _capacity)
            {
                Resize();
            }

            _array[(_indexOfNumber)] = number;
            _indexOfNumber++;
        }

        private void Resize()
        {
            var enlargedArray = new int[_array.Length * 2];

            for (var j = 0; j < _array.Length; j++)
            {
                enlargedArray[j] = _array[j];
            }

            _array = enlargedArray;
            _capacity = enlargedArray.Length;
        }

        public void Clear()
        {
            _array = new int[4];
            _capacity = 4;
            _count = 0;
        }

        public int GetCount()
        {
            return _count;
        }

        public int GetCapacity()
        {
            return _capacity;
        }

        public void Print()
        {
            for (int j = 0; j < _count; j++)
            {
                Console.WriteLine(_array[j]);
            }
        }

        public int Get(int index)
        {
            return _array[index];
        }
    }
}