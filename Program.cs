using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Задание 10:
 Угол задан с помощью целочисленных значений gradus - градусов, min - угловых минут, sec - угловых секунд.
Реализовать класс, в котором указанные значения представлены в виде свойств.
Для свойств предусмотреть проверку корректности данных. Класс должен содержать конструктор для установки начальных значений,
а также метод ToRadians для перевода угла в радианы.
Создать объект на основе разработанного класса. Осуществить использование объекта в программе.
*/
namespace Zadanie_10
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ввод данных
            Console.WriteLine("Перевод градусов в радианы.");
            Console.Write("Введите градусы: ");
            int gradus = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите минуты:  ");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите секунды: ");
            int sec = Convert.ToInt32(Console.ReadLine());

            Ugol ugol = new Ugol(gradus,min,sec);
            if (!ugol.err)
            {
                Console.WriteLine("Угол: {0} градусов {1} минут {2} секунд = {3:f4} радиан.", ugol.Gradus, ugol.Min, ugol.Sec, ugol.ToRadians());
            }
            else
            {
                Console.WriteLine("Введены некорректные данные. Преобразование не выполнено.");
            }
            Console.ReadKey();
        }
    }

    class Ugol
    {
        double gradus;
        double min;
        double sec;
        public bool err;

        public Ugol(int gradus=0, int min=0, int sec=0)
        {
            Gradus = gradus;
            Min = min;
            Sec = sec;
        }

        public double Gradus
        {
            set
            {
                if (value >= 0)
                {
                    gradus = value;
                }
                else
                {
                    Console.WriteLine("Некорректные данные!");
                    err = true;
                }
            }
            get
            {
                return gradus;
            }
        }
        public double Min
        {
            set
            {
                if ((value >= 0)&&(value<60))
                {
                    min = value;
                }
                else
                {
                    Console.WriteLine("Некорректные данные!");
                    err = true;
                }
            }
            get
            {
                return min;
            }
        }
        public double Sec
        {
            set
            {
                if ((value >= 0) && (value < 60))
                {
                    sec = value;
                }
                else
                {
                    Console.WriteLine("Некорректные данные!");
                    err = true;
                }
            }
            get
            {
                return sec;
            }
        }

        public double ToRadians ()
        {
            double radians = ((Gradus + (Min + Sec / 60) / 60) * Math.PI) / 180;
            return radians;
        }
    }
}
