using Snake_Project;
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
            int lvl = _level;
            Console.SetBufferSize(80, 25);
            Walls walls = new Walls(0, 0);
            Rooms rooms = new Rooms(0, 0);
            Tunnel tunnel = new Tunnel(0, 0);
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

                    food.x = 44;
                    food.y = 6;
                    food.Draw();
                }

                else
                {
                    food.Draw();
                }
            }

            if (map == "Tunnel")
            {
                if ((food.x > 9 && food.x < 69) && (food.y == 9 || food.y == 15)) // промежутки стен карты
                {
                    food.y = 12;
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
                    if (key.Key.ToString() == "UpArrow")
                    {
                        
                    }
                    snake.HandleKey(key.Key);
                }
            }
            Console.Clear();
            WriteGameOver();
            Console.SetCursorPosition(38, 13);
            Console.WriteLine(score * 10);
            Console.SetCursorPosition(30, 15);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Enter your name:");
            Console.SetCursorPosition(30, 16);
            rec.Result = score;
            rec.Name = Console.ReadLine();
            //Console.Clear();
            FreeConsole();



        }
        static void WriteGameOver()
        {

            int xOffset = 22;
            int yOffset = 7;
            Console.SetCursorPosition(xOffset, yOffset++);
            Console.ForegroundColor = ConsoleColor.Red;
            WriteText("==================================", xOffset, yOffset++);
            WriteText("G   A   M   E      O   V   E   R", xOffset + 1, yOffset++);
            WriteText("==================================", xOffset, yOffset++);
            WriteText(" Y  O  U  R         S  C  O  R  E", xOffset, yOffset++);


        }
    }
}
