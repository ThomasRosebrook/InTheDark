using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game0
{
    public class Campfire
    {
        private Texture2D texture;

        private double animationTimer;

        private short animationFrame = 1;

        public Vector2 position;
        private short animationInc = 1;

        public bool IsLit = true;

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Campfire");
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (animationTimer > 0.3)
            {
                animationFrame += animationInc;
                if (animationFrame > 2) animationInc = -1;
                else if (animationFrame < 2) animationInc = 1;

                animationTimer -= 0.3;
            }

            Rectangle source = new Rectangle(0,0,512,512);
            if (!IsLit) source = new Rectangle(512, 512, 512, 512);
            else if (animationFrame == 1) source = new Rectangle(0, 0, 512, 512);
            else if (animationFrame == 2) source = new Rectangle(512, 0, 512, 512);
            else if (animationFrame == 3) source = new Rectangle(0, 512, 512, 512);

            spriteBatch.Draw(texture, position, source, Color.White);
        }
    }
}
