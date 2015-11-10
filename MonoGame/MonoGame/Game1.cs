using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

namespace MonoGame
{

    public sealed class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static ContentManager gameContent;

        // interfaces
        public IController keyboard;
        public IGameState gameState;

        // important items
        public Level level;
        public Camera camera;

        private static Game1 sInstance = new Game1();
        public bool isPaused = false, isTitle = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            gameContent = Content;
        }
        
        protected override void Initialize()
        {
            level = new Level("Levels/Level.csv", this);
            keyboard = new KeyboardController(level.player, this);
            gameState = new PlayingGameState(this);
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
        }
        
        protected override void UnloadContent()
        {
        }
        
        protected override void Update(GameTime gameTime)
        {
            gameState.Update(gameTime);
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.WhiteSmoke);

            spriteBatch.Begin();
            gameState.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        public static Game1 GetInstance()
        {
            return sInstance;
        }
    }
}
