using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ClassLibrary;

namespace dotNET_module_12_homework
{
    public delegate double MathOperation(double a, double b);
    
    class Program
    {
        static void ex1to5()
        {
            Console.WriteLine("\nЗАДАНИЕ №1. ЗАДАЧА №1-5\n");

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
        }

        static void additional_ex1()
        {
            Console.WriteLine("\nДОПОЛНИТЕЛЬНАЯ РАБОТА. ЗАДАЧА №1 / ПРАКТИЧЕСКОЕ ЗАДАНИЕ №1\n");

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

        static void prac_ex2()
        {
            Console.WriteLine("\nПРАКТИЧЕСКОЕ ЗАДАНИЕ №2\n");

            Counter counter = new Counter(5); // Пороговое значение

            counter.ThresholdReached += ThresholdReachedHandler; // Подписываемся на событие

            for (int i = 0; i < 7; i++) // Увеличиваем счётчик
            {
                counter.Increment();
            }
        }

        static void prac_ex3()
        {
            Console.WriteLine("\nПРАКТИЧЕСКОЕ ЗАДАНИЕ №3\n");

            Timerr timer = new Timerr();
            timer.Tick += TimerTickHandler;

            Console.WriteLine("Таймер запущен. Нажмите любую клавишу для остановки.");

            Thread timerThread = new Thread(timer.Start);
            timerThread.Start();

            Console.ReadKey(); // Ожидание нажатия клавиши для остановки

            timer.Stop();
            timerThread.Join(); // Дождаться завершения потока таймера

            Console.WriteLine("Таймер остановлен.");
        }

        static void Main(string[] args)
        {
            ex1to5();

            additional_ex1();

            prac_ex2();

            prac_ex3();
        }

        static void TimerTickHandler(object sender, EventArgs e)
        {
            Console.WriteLine($"Текущее время: {DateTime.Now.ToLongTimeString()}");
        }

        static void ThresholdReachedHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Пороговое значение счётчика достигнуто!");
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
