using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите уровень сложности от 1 до 10:");
            int lvl = int.Parse(Console.ReadLine());
            while (lvl < 1 || lvl > 10)
            {
                Console.Clear();
                Console.WriteLine("Введите корректный уровень сложности:");
                lvl = int.Parse(Console.ReadLine());
            }


            Console.SetBufferSize(80, 25);
           
            Console.WriteLine("Выберите тип карты: 1-Коробочка, 2-Комнаты");
            int map = int.Parse(Console.ReadLine());
            Console.Clear();
        }
    }
}
