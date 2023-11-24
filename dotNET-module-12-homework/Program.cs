using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace dotNET_module_12_homework
{
    public delegate double MathOperation(double a, double b);

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ЗАДАНИЕ №1. ЗАДАЧА №1-5\n");

            SportsCar sportsCar = new SportsCar("Спортивный автомобиль", 10);
            PassengerCar passengerCar = new PassengerCar("Легковой автомобиль", 8);
            Truck truck = new Truck("Грузовик", 6);
            Bus bus = new Bus("Автобус", 5);

            RaceGame game = new RaceGame();
            Car[] cars = { sportsCar, passengerCar, truck, bus };

            RaceDelegate raceDelegate = new RaceDelegate(Console.WriteLine);

            foreach (var car in cars)
            {
                car.RaceEvent += raceDelegate;
            }

            game.RaceInfo += raceDelegate;

            game.StartRace(cars);

            Console.WriteLine("\nДОПОЛНИТЕЛЬНАЯ РАБОТА. ЗАДАЧА №1\n");

            Console.WriteLine("Введите два числа:");
            double number1 = Convert.ToDouble(Console.ReadLine());
            double number2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Выберите операцию:");
            Console.WriteLine("1 - Сложение");
            Console.WriteLine("2 - Вычитание");
            Console.WriteLine("3 - Умножение");

            int choice = Convert.ToInt32(Console.ReadLine());

            MathOperation operation = null;

            switch (choice)
            {
                case 1:
                    operation = Addition;
                    break;
                case 2:
                    operation = Subtraction;
                    break;
                case 3:
                    operation = Multiplication;
                    break;
                default:
                    Console.WriteLine("Неверный выбор операции.");
                    return;
            }

            double result = operation(number1, number2);
            Console.WriteLine($"Результат операции: {result}");
        }

        static double Addition(double a, double b)
        {
            return a + b;
        }

        static double Subtraction(double a, double b)
        {
            return a - b;
        }

        static double Multiplication(double a, double b)
        {
            return a * b;
        }
    }
}
