using System;

namespace DataStructures
{
    class Program
    {
        public static int TestPeek;
        public static int TestPop;

        static void Main()
        {
            var test = new Stack<int>();
            Requests(test);
            Console.WriteLine("Ёмкость стэка: " + test.Count + " Последнее число: " + TestPeek);
        }

        private static void Requests(Stack<int> test)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Выберите действие: ");
                Console.Write("1 - Push \n" +
                              "2 - Pop \n" +
                              "3 - Peek \n" +
                              "4 - Остановить цикл\n" +
                              "Ввод: ");
                var command = Convert.ToInt32(Console.ReadLine());
                switch (command)
                {
                    case 1:
                    {
                        Console.Write("Метод Push! Сколько чисел вы хотите добавить в стэк? ");
                        var number = Convert.ToInt32(Console.ReadLine());
                        switch (number)
                        {
                            case 0:
                            {
                                Console.WriteLine("Ошибка! Нельзя добавить ноль чисел");
                                break;
                            }
                            case 1:
                            {
                                Console.WriteLine("Какое число вы хотите добавить?");
                                break;
                            }
                            default:
                            {
                                Console.WriteLine("Какие числа вы хотите добавить?");
                                break;
                            }
                        }

                        for (int i = 0; i < number; i++)
                        {
                            test.Push(Convert.ToInt32(Console.ReadLine()));
                        }

                        Console.WriteLine();
                        break;
                    }
                    case 2:
                    {
                        Console.WriteLine($"Метод Pop! Число: {test.LastItem} удалено!\n");
                        TestPop = test.Pop();
                        break;
                    }
                    case 3:
                    {
                        Console.WriteLine("Метод Peek! Посмотрели на последний элемент стэка\n");
                        TestPeek = test.Peek();
                        break;
                    }
                    case 4:
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

    // реализация стека
    public class Stack<T>
    {
        private List<int> _items = new List<int>(10);
        public int Count;
        public int LastItem;

        public void Push(int number)
        {
            _items.Add(number);
            LastItem = number;
            Count = _items.Count;
        }

        public int Pop()
        {
            var thisItem = LastItem;
            _items.Remove(LastItem);
            LastItem = _items[^1];
            Count = _items.Count;

            return thisItem;
        }

        public int Peek()
        {
            var thisItem = LastItem;

            return thisItem;
        }
    }
}