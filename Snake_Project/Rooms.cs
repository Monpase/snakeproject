using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Project
{
    class Rooms
    {
        List<Figure> roomList;

        public Rooms(int mapWidth, int mapHeight)
        {
            roomList = new List<Figure>();

            // Отрисовка комнат

            VerticalLine rightLine = new VerticalLine(6, mapHeight - 7, mapWidth - 2, '+');
            HorizontalLine downLine = new HorizontalLine(8, mapWidth + 29, mapHeight - 13, '+');

            roomList.Add(rightLine);
            roomList.Add(downLine);

        }

        internal bool IsHit(Figure figure)
        {
            foreach (var room in roomList)
            {
                if (room.IsHit(figure))
                {
                    return true;
                }
            }
            return false;
        }

        public void Draw()
        {
            foreach (var room in roomList)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                room.Draw();
            }
        }
    }
}
