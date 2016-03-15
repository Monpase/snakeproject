using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Walls walls = new Walls(0, 0);
            Rooms rooms = new Rooms(0, 0);
            Console.Clear();
            Console.WriteLine("Выберите тип карты: 1-Коробочка, 2-Комнаты");
            int map = int.Parse(Console.ReadLine());


            if (map == 1)
            {
                walls = new Walls(80, 25);
                walls.Draw();
            }
            else if (map == 2)
            {

                walls = new Walls(80, 25);
                rooms = new Rooms(40, 25);
                rooms.Draw();
                walls.Draw();
            }

            // Отрисовка точек	
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Point p = new Point(4, 5, 'o');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();


            FoodCreator foodCreator = new FoodCreator(60, 25, '*');

            Point food = foodCreator.CreateFood();
            food.Draw();


            while (true)
            {
                if (walls.IsHit(snake) || rooms.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();


                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(350 / lvl);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            WriteGameOver();
            Console.ReadLine();
        }


        static void WriteGameOver()
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.SetCursorPosition(xOffset, yOffset++);
            Console.ForegroundColor = ConsoleColor.Red;
            WriteText("============================", xOffset, yOffset++);
            WriteText("И Г Р А    О К О Н Ч Е Н А", xOffset + 1, yOffset++);
            WriteText("============================", xOffset, yOffset++);
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
         
    }
}
