using Microsoft.Xna.Framework;

namespace MonoGame
{
    class LedgeCollisionResponse
    {
        Game1 game;

        public LedgeCollisionResponse(Game1 game)
        {
            this.game = game;
        }

        public void PlayerTileCollide(Player player, Ledge ledge)
        {
            Rectangle playerBox = player.state.GetBoundingBox(player.position);
            Rectangle ledgeBox = ledge.GetBoundingBox();
            Rectangle intersection = Rectangle.Intersect(playerBox, ledgeBox);

            if (intersection.Height > intersection.Width)
            {
                if (playerBox.Right > ledgeBox.Left && playerBox.Right < ledgeBox.Right)
                {
                    player.position.X -= intersection.Width;
                }
                else
                {
                    player.position.X += intersection.Width;
                }
            }
            else if (intersection.Height < intersection.Width)
            {
                if (playerBox.Bottom > ledgeBox.Top && playerBox.Bottom < ledgeBox.Bottom)
                {
                    if (intersection.Height > 1)
                    {
                        //player.position.Y -= intersection.Height;
                    }
                }
                else
                {
                    player.position.Y += intersection.Height;
                }
            }
        }
    }
}
