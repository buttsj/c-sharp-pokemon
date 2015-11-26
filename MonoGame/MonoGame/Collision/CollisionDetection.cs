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
        public BuildingCollisionResponse buildingResponse;
        public EnemyCollisionResponse enemyResponse;

        public CollisionDetection(Player player, Game1 game)
        {
            this.game = game;
            grassResponse = new GrassCollisionResponse(game);
            tileResponse = new TileCollisionResponse(game);
            ledgeResponse = new LedgeCollisionResponse(game);
            buildingResponse = new BuildingCollisionResponse(game);
            enemyResponse = new EnemyCollisionResponse(game);
        }

        public void Detect(Player player, List<Tile> levelTiles, List<Grass> levelGrass, List<Ledge> levelLedges, List<Building> levelBuildings, List<Enemy> levelEnemies)
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
            foreach (Building building in levelBuildings)
            {
                Rectangle buildingBox = building.GetBoundingBox();
                if (buildingBox.Intersects(playerBox))
                {
                    buildingResponse.PlayerTileCollide(player, building);
                }
            }
            foreach (Enemy enemy in levelEnemies)
            {
                Rectangle enemyBox = enemy.state.GetBoundingBox(enemy.position);
                if (enemyBox.Intersects(playerBox))
                {
                    enemyResponse.PlayerEnemyCollide(player, enemy);
                }
            }
        }
    }
}
