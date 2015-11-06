using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    class RightWalkingState : IPlayerState
    {
        Player player;

        public RightWalkingState(Player currentPlayer)
        {
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
