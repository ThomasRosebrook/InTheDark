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
    public class Stick
    {
        private Texture2D texture;
        public Vector2 position;

        public bool HasMarshmallow;

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("stick");
        }

        public void Update(GameTime gameTime, InputManager inputManager)
        {
            position = inputManager.Position - new Vector2(64, 64);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (HasMarshmallow) spriteBatch.Draw(texture, position, new Rectangle(128, 0, 128, 128), Color.White);
            else spriteBatch.Draw(texture, position, new Rectangle(0,0,128,128), Color.White);
        }
    }
}
