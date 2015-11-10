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
        public GrassCollisionResponse grassResponse;
        public LedgeCollisionResponse ledgeResponse;

        public CollisionDetection(Player player, Game1 game)
        {
            this.game = game;
            grassResponse = new GrassCollisionResponse(game);
            tileResponse = new TileCollisionResponse(game);
            ledgeResponse = new LedgeCollisionResponse(game);
        }

        public void Detect(Player player, List<Tile> levelTiles, List<Grass> levelGrass, List<Ledge> levelLedges)
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
            foreach (Grass grass in levelGrass)
            {
                Rectangle grassBox = grass.GetBoundingBox();
                if (grassBox.Intersects(playerBox) && !grass.intersected)
                {
                    grass.intersected = true;
                    grassResponse.PlayerTileCollide(grass);
                }
                if (!grassBox.Intersects(playerBox))
                {
                    grass.intersected = false;
                }
            }
            foreach (Ledge ledge in levelLedges)
            {
                Rectangle ledgeBox = ledge.GetBoundingBox();
                if (ledgeBox.Intersects(playerBox))
                {
                    ledgeResponse.PlayerTileCollide(player, ledge);
                }
            }
        }
    }
}
