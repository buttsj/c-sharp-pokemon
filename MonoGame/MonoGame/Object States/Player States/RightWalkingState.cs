using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    class RightWalkingState : IPlayerState
    {
        Player player;
        public IAnimatedSprite Sprite { get; set; }

        public RightWalkingState(Player currentPlayer)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.builder(SpriteFactory.sprites.rightWalkingPlayer);
            player = currentPlayer;
        }

        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }
        public void Down()
        {
            player.state = new DownIdleState(player);
        }
        
        public void Left()
        {
            player.state = new LeftIdleState(player);
        }

        public void Right()
        {
        }

        public void Up()
        {
            player.state = new UpIdleState(player);
        }

        public void Idle()
        {
            player.state = new RightIdleState(player);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Sprite.Draw(spriteBatch, location, color);
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
    }
}
