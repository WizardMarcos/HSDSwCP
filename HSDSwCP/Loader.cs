using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSDSwCP
{
    class Loader
    {
        public Loader() { }

        public Tile[,] LoadTileImage(ContentManager content, string name)
        {
            Texture2D map = content.Load<Texture2D>("Maps/" + name);
            Color[] data1D = new Color[map.Width * map.Height];
            Color[,] data2D = new Color[map.Width, map.Height];
            Tile[,] tilemap = new Tile[map.Width, map.Height];

            map.GetData(data1D);

            for (int x = 0; x < map.Width; x++)
            {
                for (int y = 0; y < map.Height; y++)
                {
                    data2D[x, y] = data1D[x + y * map.Width];

                    if (data2D[x, y].R == 255)
                        tilemap[x, y] = new Tile(content, x * 16, y * 16, 1, name, new Point(data2D[x, y].G, data2D[x, y].B));
                }
            }

            return tilemap;
        }
    }
}
