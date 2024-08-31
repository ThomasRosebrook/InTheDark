using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game0
{
    public class InputManager
    {
        MouseState currentMouseState;
        MouseState previousMouseState;

        GamePadState currentGamePadState;
        GamePadState previousGamePadState;

        KeyboardState currentKeyboardState;

        public Vector2 Position { get; private set; }

        public bool Selected { get; private set; }

        public Vector2 SelectedPosition { get; private set; }

        public bool Exit { get; private set; } = false;

        public void Update (GameTime gameTime)
        {
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            previousGamePadState = currentGamePadState;
            currentGamePadState = GamePad.GetState(0);

            currentKeyboardState = Keyboard.GetState();

            if (currentMouseState.Position != previousMouseState.Position || currentMouseState.LeftButton == ButtonState.Pressed)
            {
                //Position += new Vector2(currentMouseState.X - previousMouseState.X, currentMouseState.Y - previousMouseState.Y);
                Position = new Vector2(currentMouseState.X, currentMouseState.Y);
            }
            else
            {
                Position += currentGamePadState.ThumbSticks.Left * 100 * (float)gameTime.ElapsedGameTime.TotalSeconds * new Vector2(1, -1);
            }

            Selected = (currentMouseState.LeftButton == ButtonState.Pressed 
                || currentGamePadState.Buttons.A == ButtonState.Pressed)
                && previousGamePadState.Buttons.A == ButtonState.Released
                && previousMouseState.LeftButton == ButtonState.Released;

            if (Selected) SelectedPosition = new Vector2(currentMouseState.X, currentMouseState.Y);

            if (currentGamePadState.Buttons.Back == ButtonState.Pressed || currentKeyboardState.IsKeyDown(Keys.Escape))
            {
                Exit = true;
            }
        }
    }
}
