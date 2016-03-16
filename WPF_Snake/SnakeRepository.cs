﻿using Snake_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WPF_Snake
{
    class SnakeRepository
    {
        Record rec = new Record();
        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);

            Console.WriteLine(text);
        }

        [DllImport("Kernel32")]
        public static extern void AllocConsole();

        public void OnClickPlay()
        {
            AllocConsole();
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

            Snake_Project.Point p = new Snake_Project.Point(4, 5, 'o');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();


            FoodCreator foodCreator = new FoodCreator(60, 25, '*');

            Snake_Project.Point food = foodCreator.CreateFood();
            food.Draw();

            int score = 0;

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
                    score++;

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
            Console.Clear();
            WriteGameOver();
            Console.SetCursorPosition(38, 14);
            Console.WriteLine(score * 10);

            Console.SetCursorPosition(30, 16);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Введите ваше имя:");
            Console.SetCursorPosition(30, 17);
            rec.Result = score;
            rec.Name = Console.ReadLine();
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
            WriteText("В   А   Ш      С   Ч   Е   Т", xOffset, yOffset++);


        }
    }
}