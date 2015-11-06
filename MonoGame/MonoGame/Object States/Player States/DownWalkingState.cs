using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    class DownWalkingState : IPlayerState
    {
        Player player;

        public DownWalkingState(Player currentPlayer)
        {
            player = currentPlayer;
        }

        public void Down()
        {
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
            player.state = new UpIdleState(player);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }
    }
}
