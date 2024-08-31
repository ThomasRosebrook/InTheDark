using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game0
{
    public class Fly
    {
        private Texture2D texture;
        public Vector2 position;
        Random random;

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Fly");
            random = new Random();
        }

        public void Update(GameTime gameTime)
        {
            position += new Vector2((float)random.NextDouble() * 200 * (float)gameTime.ElapsedGameTime.TotalSeconds * random.Next(-1, 2), (float)random.NextDouble() * 200 * (float)gameTime.ElapsedGameTime.TotalSeconds * random.Next(-1, 2));
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
