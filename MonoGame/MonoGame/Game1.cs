using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System;

namespace MonoGame
{

    public sealed class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;
        public static ContentManager gameContent;

        // interfaces
        public IController keyboard;
        public IGameState gameState;

        // important items
        public Level level;
        public Camera camera;
        public Color background;

        private static Game1 sInstance = new Game1();
        public bool isPaused = false, isTitle = true, transition = false;
        private Texture2D faderTexture;
        private float faderAlpha;
        private float faderAlphaIncrement = 15;

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
            camera = new Camera(GraphicsDevice.Viewport, this);
            gameState = new PlayingGameState(this);
            faderTexture = new Texture2D(GraphicsDevice, 1, 1);
            var colors = new Color[] { Color.White };
            faderTexture.SetData<Color>(colors);
            background = Color.Black;
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
            GraphicsDevice.Clear(background);

            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, camera.GetViewMatrix());
            if (!transition)
            {
                gameState.Draw(spriteBatch);
            }
            if (transition)
            {
                spriteBatch.Draw(faderTexture, GraphicsDevice.Viewport.Bounds, new Color(Color.Black, (byte)MathHelper.Clamp(faderAlpha, 0, 255)));
                faderAlpha += faderAlphaIncrement;
                if (faderAlpha >= 255)
                {
                    transition = false;
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }

        public static Game1 GetInstance()
        {
            return sInstance;
        }
    }
}
