using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame
{
    class LeftWalkingState : IPlayerState
    {
        Player player;

        public LeftWalkingState(Player currentPlayer)
        {
            player = currentPlayer;
        }

        public void Down()
        {
            player.state = new DownIdleState(player);
        }
        
        public void Left()
        {
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
