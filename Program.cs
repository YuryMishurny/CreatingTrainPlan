using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            Train train = new Train();
            Queue<Train> trains = new Queue<Train>();
            bool isOpen = true;

            while (isOpen)
            {
                if (trains.Count > 0)
                    trains.Peek().ShowInfo();
                else
                    Console.WriteLine("Рейс отсувствует");

                Console.WriteLine("\nСоставление плана поезда\n1 - Создать направление\n2 - Продать билеты\n3 - Сформировать поезд\n" +
                    "4 - Отправить поезд\n5 - Exit");

                switch (Console.ReadLine())
                {
                    case "1":
                        if (trains.Count <= 0)
                        {
                            train.CreateDirection();
                            trains.Enqueue(train);
                        }
                        else
                        {
                            Console.WriteLine("Направление уже создано");
                        }
                        break;
                    case "2":
                        if (trains.Count > 0)
                        {
                            if (train.NumberTickets == 0)
                                train.SellTickets();
                            else
                                Console.WriteLine("Все билеты проданы");
                        }
                        else
                        {
                            Console.WriteLine("Направление не создано, невозможно осуществить продажу билетов");
                        }
                        break;
                    case "3":
                        if (train.NumberTickets > 0)
                        {
                            if (train.GetNumberRailCars() <= 0)
                                train.CreateRailCars();
                            else
                                Console.WriteLine("Поезд уже сформирован");
                        }
                        else
                        {
                            Console.WriteLine("Для начала необходимо создать направление и продать билеты");
                        }
                        break;
                    case "4":
                        if (train.GetNumberRailCars() > 0)
                        {
                            trains.Dequeue();
                            Console.WriteLine("Поезд ушел");
                        }
                        else
                        {
                            Console.WriteLine("Поезд не готов к отправке");
                        }
                        break;
                    case "5":
                        isOpen = false;
                        break;
                    default:
                        Console.WriteLine("Такой команды не существует...");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу для продолжения...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}