using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    public class Camera : ICamera
    {
        private Vector2 position;
        protected float viewportHeight;
        protected float viewportWidth;

        public Camera(Game1 game)
        {
            viewportWidth = game.GraphicsDevice.Viewport.Width;
            viewportHeight = game.GraphicsDevice.Viewport.Height;

            ScreenCenter = new Vector2(viewportWidth / 2, viewportHeight / 2);
            Scale = 1;
            MoveSpeed = 1.25f;
        }

        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
        }

        public float Rotation { get; set; }
        public Vector2 Origin { get; set; }
        public float Scale { get; set; }
        public Vector2 ScreenCenter { get; protected set; }
        public Matrix Transform { get; set; }
        public IFocusable Focus { get; set; }
        public float MoveSpeed { get; set; }

        public void Update(GameTime gameTime)
        {
            Transform = Matrix.Identity *
                    Matrix.CreateTranslation(-Position.X, -Position.Y, 0) *
                    Matrix.CreateRotationZ(Rotation) *
                    Matrix.CreateTranslation(Origin.X, Origin.Y, 0) *
                    Matrix.CreateScale(new Vector3(Scale, Scale, Scale));

            Origin = ScreenCenter / Scale;

            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position.X += (Focus.Position.X - Position.X) * MoveSpeed * delta;
            position.Y += (Focus.Position.Y - Position.Y) * MoveSpeed * delta;
        }

        public bool IsInView(Vector2 position, Texture2D texture)
        {
            if ((position.X + texture.Width) < (Position.X - Origin.X) || (position.X) > (Position.X + Origin.X))
            {
                return false;
            }
            if ((position.Y + texture.Height) < (Position.Y - Origin.Y) || (position.Y) > (Position.Y + Origin.Y))
            {
                return false;
            }
            return true;
        }
    
    }
}
