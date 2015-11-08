using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoGame
{
    class CollisionDetection
    {
        Game1 game;
        ISpriteFactory factory = new SpriteFactory();
        public TileCollisionResponse tileResponse;

        public CollisionDetection(Player player, Game1 game)
        {
            this.game = game;
            tileResponse = new TileCollisionResponse(game);
        }

        public void Detect(Player player, List<Tile> levelTiles)
        {
            Rectangle playerBox = player.state.GetBoundingBox(player.position);
            foreach (Tile tile in levelTiles)
            {
                Rectangle tileBox = tile.GetBoundingBox();
                if (tileBox.Intersects(playerBox))
                {
                    tileResponse.PlayerTileCollide(player, tile);
                }
            }
        }
    }
}
