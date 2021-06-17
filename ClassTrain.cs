using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Train
    {
        private string _direction;
        private Random _random;
        private int _trainNumber;
        private List<int> _railCars = new List<int>();

        public int NumberTickets { get; private set; }

        public Train()
        {
            _random = new Random();
            _trainNumber = _random.Next(100, 1000);
        }

        public int GetNumberRailCars()
        {
            return _railCars.Count();
        }

        public void CreateRailCars()
        {
            while (_railCars.Sum() < NumberTickets)
            {
                _railCars.Add(_random.Next(10, 20));
            }

            Console.WriteLine("Сформировано " + _railCars.Count() + " вагонов");
        }

        public void CreateDirection()
        {
            Console.WriteLine("Введите направление поезда (пункт А - пункт Б):");
            _direction = Console.ReadLine();
            Console.WriteLine("Направление " + _direction + " сформировано.");
        }

        public void SellTickets()
        {
            NumberTickets = _random.Next(50, 150);
            Console.WriteLine(NumberTickets + " билетов продано.");
        }

        public void ShowInfo()
        {
            Console.WriteLine("Поезд № - " + _trainNumber + ". Направление - " + _direction + ". Количество пассажиров  - " + NumberTickets);

            for (int i = 0; i < _railCars.Count; i++)
            {
                Console.WriteLine("Вагон номер " + (i + 1) + " Вместительность " + _railCars[i] + " пассажиров");
            }

            if (_railCars.Count() > 0)
                Console.WriteLine($"Занято {NumberTickets} мест из {_railCars.Sum()} доступных");
        }
    }
}
