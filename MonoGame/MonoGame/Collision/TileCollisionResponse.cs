using Microsoft.Xna.Framework;


namespace MonoGame
{
    class TileCollisionResponse
    {
        Game1 game;

        public TileCollisionResponse(Game1 game)
        {
            this.game = game;
        }

        public void PlayerTileCollide(Player player, Tile tile)
        {
            Rectangle playerBox = player.state.GetBoundingBox(player.position);
            Rectangle tileBox = tile.GetBoundingBox();
            Rectangle intersection = Rectangle.Intersect(playerBox, tileBox);

            if (intersection.Height > intersection.Width)
            {
                if (playerBox.Right > tileBox.Left && playerBox.Right < tileBox.Right)
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
                if (playerBox.Bottom > tileBox.Top && playerBox.Bottom < tileBox.Bottom)
                {
                    if (intersection.Height > 1)
                    {
                        player.position.Y -= intersection.Height;
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
