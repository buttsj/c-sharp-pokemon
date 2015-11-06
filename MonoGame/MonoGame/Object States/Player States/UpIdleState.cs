using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    class UpIdleState : IPlayerState
    {
        Player player;
        public IAnimatedSprite Sprite { get; set; }

        public UpIdleState(Player currentPlayer)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.builder(SpriteFactory.sprites.upIdlePlayer);
            player = currentPlayer;
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
            player.state = new RightIdleState(player);
        }

        public void Up()
        {
            player.state = new UpWalkingState(player);
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
