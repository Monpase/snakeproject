using Snake_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Snake.GameClasses
{
    class Tunnel
    {
        List<Figure> tunnelList;

        public Tunnel (int mapWidth, int mapHeight)
        {
            tunnelList = new List<Figure>();

            // Отрисовка туннеля

            HorizontalLine downSide = new HorizontalLine(10, mapWidth - 11, mapHeight - 10, '+');
            HorizontalLine upSide = new HorizontalLine(10, mapWidth - 11, mapHeight - 16, '+');

            tunnelList.Add(downSide);
            tunnelList.Add(upSide);
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var room in tunnelList)
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
            foreach (var room in tunnelList)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                room.Draw();
            }
        }
    }
}
