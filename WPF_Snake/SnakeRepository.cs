﻿using Snake_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WPF_Snake.GameClasses;

namespace WPF_Snake
{
    class SnakeRepository
    {

        Record rec = new Record();

        private int _level;

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        private string _mapType;

        public string MapType
        {
            get { return _mapType; }
            set { _mapType = value; }
        }



        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);

            Console.WriteLine(text);
        }

        [DllImport("Kernel32")]
        public static extern void AllocConsole();

        [DllImport("Kernel32")]
        public static extern void FreeConsole();

        public void OnClickPlay()
        {
            AllocConsole();
            // Console.WriteLine("Выберите уровень сложности от 1 до 10:");
            int lvl = _level;

            //while (lvl < 1 || lvl > 10)
            //{
            //    Console.Clear();
            //    Console.WriteLine("Введите корректный уровень сложности:");
            //    lvl = int.Parse(Console.ReadLine());
            //}



            Console.SetBufferSize(80, 25);
            Walls walls = new Walls(0, 0);
            Rooms rooms = new Rooms(0, 0);
            Tunnel tunnel = new Tunnel(0, 0);
            //Console.Clear();
            //Console.WriteLine("Выберите тип карты: 1-Коробочка, 2-Комнаты");
            string map = _mapType;


            if (map == "Box")
            {
                walls = new Walls(80, 25);
                walls.Draw();
            }
            else if (map == "Rooms")
            {

                walls = new Walls(80, 25);
                rooms = new Rooms(40, 25);
                rooms.Draw();
                walls.Draw();
            }
            else if (map == "Tunnel")
            {
                tunnel = new Tunnel(80, 25);
                walls = new Walls(80, 25);
                walls.Draw();
                tunnel.Draw();

            }


            // Отрисовка точек	
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Snake_Project.Point p = new Snake_Project.Point(4, 5, 'o');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();


            FoodCreator foodCreator = new FoodCreator(79, 25, '*');

            Snake_Project.Point food = foodCreator.CreateFood();

            if (map == "Rooms")
            {
                if ((food.x > 7 && food.x < 70) && (food.y > 5 && food.y < 19)) // промежутки стен карты
                {

                    food.x = food.x + 1;
                    food.y = food.y + 7;
                    food.Draw();
                }

                else
                {
                    food.Draw();
                }
            }

            if (map == "Tunnel")
            {
                if ((food.x > 9 && food.x < 69) && (food.y == 9 || food.y == 14)) // промежутки стен карты
                {
                    food.y = food.y + 2;
                    food.Draw();
                }
                else
                {
                    food.Draw();
                }
            }
            if (map == "Box")
            {
                food.Draw();
            }
            int score = 0;

            while (true)
            {
                if (walls.IsHit(snake) || rooms.IsHit(snake) || snake.IsHitTail() || tunnel.IsHit(snake))
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

                Thread.Sleep(500 / lvl);
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
            Console.WriteLine("Enter your name:");
            Console.SetCursorPosition(30, 17);
            rec.Result = score;
            rec.Name = Console.ReadLine();
            Console.Clear();
            FreeConsole();



        }
        static void WriteGameOver()
        {

            int xOffset = 25;
            int yOffset = 8;
            Console.SetCursorPosition(xOffset, yOffset++);
            Console.ForegroundColor = ConsoleColor.Red;
            WriteText("================================", xOffset, yOffset++);
            WriteText("G   A   M   E      O   V   E   R", xOffset + 1, yOffset++);
            WriteText("================================", xOffset, yOffset++);
            WriteText("Y  O  U  R         S  C  O  R  E", xOffset, yOffset++);


        }
    }
}
