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
    class Tile
    {
        private int nFrames, currentFrame, frameTime, currentFrameTime;
        private Texture2D texture;
        private Point sprtLoc;

        public Rectangle Hitbox { get; private set; }

        public Tile(ContentManager content, int posX, int posY, int nAnimFrames, string textureName, Point spriteLocation)
        {
            Hitbox = new Rectangle(posX, posY, 16, 16);
            nFrames = nAnimFrames;
            frameTime = 130;
            currentFrameTime = 0;
            currentFrame = 0;
            texture = content.Load<Texture2D>("Tiles/" + textureName);
            sprtLoc = spriteLocation;
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
            spriteBatch.Draw(
                texture: texture,
                position: Hitbox.Location.ToVector2(),
                color: Color.White,
                sourceRectangle: new Rectangle(sprtLoc.X, sprtLoc.Y + (currentFrame * 16), 16, 16));
        }
    }
}
