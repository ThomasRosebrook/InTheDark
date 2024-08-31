using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game0.Content
{
    public class Marshmallows
    {
        private const int WIDTH = 128;
        private const int HEIGHT = 128;

        private Texture2D texture;
        public Vector2 position;

        public bool ClickedOn { get; private set; }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Marshmallows");
        }

        public void Update(GameTime gameTime, InputManager inputManager)
        {
            if (inputManager.Selected)
            {
                if (inputManager.Selected
                && inputManager.SelectedPosition.X < position.X + WIDTH
                && inputManager.SelectedPosition.X > position.X
                && inputManager.SelectedPosition.Y < position.Y + HEIGHT
                && inputManager.SelectedPosition.Y > position.Y)
                {
                    ClickedOn = true;
                }
            }
            
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
