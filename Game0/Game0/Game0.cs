using Game0.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game0
{
    public class Game0 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Vector2 ballPosition = new Vector2(0, 0);
        InputManager inputManager;
        Texture2D Background;
        Vector2 BackgroundLocation;
        Campfire campfire;
        Stick stick;
        Marshmallows marshmallows;
        Fly fly;
        SpriteFont lusitana;
        SpriteFont lusitanaSmall;
        int exitTimer = 0;

        public Game0()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = false;
            inputManager = new InputManager();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

            campfire = new Campfire() { position = new Vector2(GraphicsDevice.DisplayMode.Width / 2 - 300, GraphicsDevice.DisplayMode.Height / 2 - 150) };
            stick = new Stick();
            marshmallows = new Marshmallows() { position = new Vector2(1200, 700) };
            fly = new Fly() { position = new Vector2(GraphicsDevice.DisplayMode.Width / 2, GraphicsDevice.DisplayMode.Height / 2 - 256) };
            lusitana = Content.Load<SpriteFont>("Lusitana");
            lusitanaSmall = Content.Load<SpriteFont>("LusitanaSmaller");

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Background = Content.Load<Texture2D>("Background");
            BackgroundLocation = new Vector2(0,0);
            campfire.LoadContent(Content);
            stick.LoadContent(Content);
            marshmallows.LoadContent(Content);
            fly.LoadContent(Content);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {

            // TODO: Add your update logic here
            inputManager.Update(gameTime);
            campfire.Update(gameTime);
            stick.Update(gameTime, inputManager);
            marshmallows.Update(gameTime, inputManager);
            fly.Update(gameTime);

            if (marshmallows.ClickedOn) stick.HasMarshmallow = true;
            if (inputManager.Exit)
            {
                campfire.IsLit = false;
                exitTimer++;
                if (exitTimer > 50) Exit();
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            _spriteBatch.Draw(Background, BackgroundLocation, Color.White);
            campfire.Draw(gameTime, _spriteBatch);
            marshmallows.Draw(gameTime, _spriteBatch);


            _spriteBatch.DrawString(lusitana, "In The Dark", new Vector2(GraphicsDevice.DisplayMode.Width / 2 - 256, 100), Color.White);
            _spriteBatch.DrawString(lusitanaSmall, "Press ESC to exit", new Vector2(GraphicsDevice.DisplayMode.Width / 2 - 180, 200), Color.White);

            fly.Draw(gameTime, _spriteBatch);

            stick.Draw(gameTime, _spriteBatch);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}