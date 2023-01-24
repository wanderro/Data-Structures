using System;

namespace DataStructures
{
    class Program
    {
        public static int TestPeek;
        public static int TestPop;

        static void Main()
        {
            var test = new StackInt();
            Requests(test);
            Console.WriteLine("Ёмкость стэка: " + test.Count + " Последнее число: " + TestPeek);
        }

        private static void Requests(StackInt test)
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
                        Console.WriteLine($"Метод Pop! Число: {test.LastNumber} удалено!\n");
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
    public class StackInt
    {
        private List<int> _numbers = new List<int>(10);
        public int Count;
        public int LastNumber;

        public void Push(int number)
        {
            _numbers.Add(number);
            LastNumber = number;
            Count = _numbers.Count;
        }

        public int Pop()
        {
            var thisNumber = LastNumber;
            _numbers.Remove(LastNumber);
            LastNumber = _numbers[^1];
            Count = _numbers.Count;

            return thisNumber;
        }

        public int Peek()
        {
            var thisNumber = LastNumber;

            return thisNumber;
        }
    }
}