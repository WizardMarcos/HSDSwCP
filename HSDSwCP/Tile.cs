using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSDSwCP
{
    class Tile
    {
        private int nFrames, currentFrame, frameTime, currentFrameTime;

        public Rectangle Hitbox { get; private set; }

        public Tile(int posX, int posY, int nAnimFrames)
        {
            Hitbox = new Rectangle(posX, posY, 16, 16);
            nFrames = nAnimFrames;
            frameTime = 130;
            currentFrameTime = 0;
            currentFrame = 0;
        }

        public void Update(GameTime gametime)
        {
            // Animation part
            currentFrameTime += gametime.ElapsedGameTime.Milliseconds;
            if (currentFrameTime >= frameTime)
                currentFrameTime -= frameTime;
            if (currentFrame >= nFrames)
                currentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }
    }
}
