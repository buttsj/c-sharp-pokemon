using Microsoft.Xna.Framework;

namespace MonoGame
{
    class BuildingCollisionResponse
    {
        Game1 game;

        public BuildingCollisionResponse(Game1 game)
        {
            this.game = game;
        }

        public void PlayerTileCollide(Player player, Building building)
        {
            Rectangle playerBox = player.state.GetBoundingBox(player.position);
            Rectangle buildingBox = building.GetBoundingBox();
            int middle = buildingBox.Left + buildingBox.Width / 2;
            int right = buildingBox.Right;

            Rectangle intersection = Rectangle.Intersect(playerBox, buildingBox);

            if (intersection.Height > intersection.Width)
            {
                if (playerBox.Right > buildingBox.Left && playerBox.Right < buildingBox.Right)
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
                if (playerBox.Bottom > buildingBox.Top && playerBox.Bottom < buildingBox.Bottom)
                {
                    if (intersection.Height > 1)
                    {
                        player.position.Y -= intersection.Height;
                    }
                }
                else if (playerBox.Location.X > middle && playerBox.Location.X < right && building.isDoor)
                {
                    game.level = new Level(building.destination, game);
                    game.keyboard = new KeyboardController(game.level.player, game);
                }
                else
                {
                    player.position.Y += intersection.Height;
                }
            }
        }
    }
}
